using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UdacityDownloader.Udacity
{
    class UdacityParser
    {
        public static string ParseCourseId(string courseUrl)
        {
            if (string.IsNullOrEmpty(courseUrl))
                throw new Exception("Empty course URL.");

            var match = Regex.Match(courseUrl, "c-([a-zA-Z]{2}[0-9]+)");
            if (match.Success)
            {
                string courseID = match.Groups[1].Value;

                Log.Verbose("Course ID: " + courseID);
                return courseID;
            }

            throw new Exception("Invalid course URL.");
        }

        public static Course ParseData(string json, string courseID)
        {
            Log.Verbose("PARSING DATA...");

            if (json.StartsWith(")]}'"))
                json = json.Substring(4);

            dynamic data = JsonConvert.DeserializeObject(json);

            try
            {
                var course = ParseCourseData(data, courseID);
                Log.Verbose("DONE!");
                return course;
            }
            catch (Exception ex)
            {
                Log.Handle(ex);
            }

            return null;
        }

        private static Course ParseCourseData(object data, string courseID)
        {
            var courseData = JsonHelper.TryGet(data, "references.Node." + courseID);
            var course = new Course(courseData);

            if (course != null)
            {
                Log.Verbose("  COURSE: " + course.Title);
                Log.Verbose("    Video package URL: " + course.VideoDownloadUri);
                Log.Verbose("    Transcript package URL: " + course.TranscriptDownloadUri);
            }

            int lessionIndex = 0;
            var lessonSteps = JsonHelper.TryGet<JArray>(courseData, "steps_refs");
            foreach (dynamic lessonStep in lessonSteps)
            {
                string stepKey = JsonHelper.TryGet<string>(lessonStep, "key");
                var stepData = JsonHelper.TryGet(data, "references.Node." + stepKey);

                var lesson = Lesson.Parse(stepData);
                if (lesson != null)
                {
                    lesson.Index = ++lessionIndex;
                    course.Lessons.Add(lesson);

                    Log.Verbose("    LESSON " + lesson.Index);
                    Log.Verbose("      Key: " + lesson.Key);
                    Log.Verbose("      Title: " + lesson.Title);
                }

                int videoIndex = 0;
                var chapterSteps = JsonHelper.TryGet<JArray>(stepData, "steps_refs");
                foreach (dynamic chapterStep in chapterSteps)
                {
                    stepKey = JsonHelper.TryGet<string>(chapterStep, "key");
                    stepData = JsonHelper.TryGet(data, "references.Node." + stepKey);

                    var video = Video.Parse(stepData);
                    if (video != null)
                    {
                        video.Index = ++videoIndex;

                        var chapter = new Chapter(video);
                        lesson.Steps.Add(chapter);

                        Log.Verbose("      CHAPTER " + video.Index);
                        Log.Verbose("        Key: " + video.Key);
                        Log.Verbose("        Title: " + video.Title);
                        Log.Verbose("        Video: " + video.VideoDownloadUrl);
                    }
                    else
                    {
                        var exercise = Exercise.Parse(stepData);
                        if (exercise != null)
                        {
                            exercise.Index = ++videoIndex;
                            lesson.Steps.Add(exercise);

                            Log.Verbose("      EXERCISE");

                            var lectureKey = JsonHelper.TryGet<string>(stepData, "lecture_ref.key");
                            if (lectureKey != null)
                            {
                                var lectureData = JsonHelper.TryGet(data, "references.Node." + lectureKey);
                                var lecture = Video.Parse(lectureData);
                                if (lecture.Key != null)
                                {
                                    lecture.Index = videoIndex;
                                    exercise.Lecture = lecture;

                                    Log.Verbose("        LECTURE " + lecture.Index);
                                    Log.Verbose("          Key: " + lecture.Key);
                                    Log.Verbose("          Title: " + lecture.Title);
                                    Log.Verbose("          Lecture: " + lecture.VideoDownloadUrl);
                                }
                            }

                            var answerKey = JsonHelper.TryGet<string>(stepData, "answer_ref.key");
                            if (answerKey != null)
                            {
                                var answerData = JsonHelper.TryGet(data, "references.Node." + answerKey);
                                var answer = Video.Parse(answerData);
                                if (answer.Key != null)
                                {
                                    answer.Index = ++videoIndex;
                                    exercise.Answer = answer;

                                    Log.Verbose("        ANSWER " + answer.Index);
                                    Log.Verbose("          Key: " + answer.Key);
                                    Log.Verbose("          Title: " + answer.Title);
                                    Log.Verbose("          Answer: " + answer.VideoDownloadUrl);
                                }
                            }
                        }
                        else
                        {
                            Log.Verbose("      NOT A CHAPTER: " + stepKey);
                        }
                    }
                }
                //Log.Verbose("    Steps: " + chapterSteps.Count);
            }

            return course;
        }
    }
}
