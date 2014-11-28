using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using UdacityDownloader.Downloader;
using UdacityDownloader.Udacity;

namespace UdacityDownloader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Font = SystemFonts.MessageBoxFont;

            Log.AttachObserver(WriteLog);

            menuCourse_Enqueue.Click += menuItem_Enqueue;
            menuCourse_Download.Click += menuItem_Download;

            menuLesson_Enqueue.Click += menuItem_Enqueue;
            menuLesson_Download.Click += menuItem_Download;

            menuChapter_Enqueue.Click += menuItem_Enqueue;
            menuChapter_Download.Click += menuItem_Download;

            Log.Info("Udacity Downloader v0.1");
            Log.Info("Author: huynhminhdang@gmail.com");
            Log.Info("Date: Nov 28, 2014");
            Log.Info("--------------------");
        }

        private void WriteLog(object sender, LogEventArgs args)
        {
            lblConsole.AppendText(args.Message);
        }

        private void btnDownload_Click(object sender, EventArgs args)
        {
            try
            {
                string courseUrl = txtCourseUrl.Text;
                string courseId = UdacityParser.ParseCourseId(courseUrl);

                string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string file = Path.Combine(directory, courseId + ".json");
                if (File.Exists(file))
                {
                    Log.Verbose("Load data from " + file);
                    string json = File.ReadAllText(file);

                    Course course = UdacityParser.ParseData(json, courseId);
                    BindData(course);
                    return;
                }

                var fetch = new JsonDownloader();

                fetch.OnFetchCompleted += (s, e) =>
                {
                    Log.Verbose("Save data to " + file);
                    File.WriteAllText(file, e.Json);
                    
                    Course course = UdacityParser.ParseData(e.Json, courseId);
                    BindData(course);
                };

                fetch.OnFetchFailed += (s, e) =>
                {
                    BindData(new Course());
                };

                string jsonUrl = string.Format("https://www.udacity.com/api/nodes/{0}?depth=3&fresh=false", courseId);
                fetch.Get(jsonUrl);
            }
            catch (Exception ex)
            {
                Log.Handle(ex);
            }
        }

        private void menuItem_Enqueue(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var dlObj = lstLessions.SelectedNode.Tag as IDownloadable;
                if (dlObj != null)
                    IDMan.Enqueue(dlObj, dlg.SelectedPath);
            }
        }

        private void menuItem_Download(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var dlObj = lstLessions.SelectedNode.Tag as IDownloadable;
                if (dlObj != null)
                    IDMan.Download(dlObj, dlg.SelectedPath);
            }
        }

        private void lstLessions_MouseUp(object sender, MouseEventArgs e)
        {
            lstLessions.SelectedNode = lstLessions.GetNodeAt(e.X, e.Y);
        }

        private void lblCourseTranscriptZip_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var link = lblCourseTranscriptZip.Text;
            if (string.IsNullOrWhiteSpace(link))
                return;

            var dlg = new SaveFileDialog();
            dlg.FileName = Path.GetFileName(link);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                IDMan.Download(new DownloadTask(link, dlg.FileName));
            }
        }

        private void lblCourseVideoZip_Click(object sender, EventArgs e)
        {
            var link = lblCourseVideoZip.Text;
            if (string.IsNullOrWhiteSpace(link))
                return;

            var dlg = new SaveFileDialog();
            dlg.FileName = Path.GetFileName(link);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                IDMan.Download(new DownloadTask(link, dlg.FileName));
            }
        }

        private void BindData(Course course)
        {
            lstLessions.ContextMenu = menuCourse;
            lstLessions.Nodes.Clear();

            var courseNode = new TreeNode(course.Title);
            courseNode.Tag = course;
            courseNode.ContextMenu = menuCourse;
            lstLessions.Nodes.Add(courseNode);

            foreach (var lesson in course.Lessons)
            {
                var lessonNode = new TreeNode(lesson.Title);
                lessonNode.Tag = lesson;
                lessonNode.ContextMenu = menuLesson;
                courseNode.Nodes.Add(lessonNode);

                foreach (var step in lesson.Steps)
                {
                    var chapterNode = new TreeNode(step.Title);
                    chapterNode.Tag = step;
                    chapterNode.ContextMenu = menuChapter;
                    lessonNode.Nodes.Add(chapterNode);
                }
            }

            courseNode.ExpandAll();

            lblCourseTitle.Text = course.Title;
            lblCourseSummary.Text = course.Summary;
            lblCourseVideoZip.Text = HttpUtility.UrlDecode(course.VideoDownloadUri);
            lblCourseTranscriptZip.Text = HttpUtility.UrlDecode(course.TranscriptDownloadUri);
        }
    }
}
