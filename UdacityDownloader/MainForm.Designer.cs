namespace UdacityDownloader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null ))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtCourseUrl = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblConsole = new System.Windows.Forms.TextBox();
            this.lstLessions = new System.Windows.Forms.TreeView();
            this.menuCourse = new System.Windows.Forms.ContextMenu();
            this.menuCourse_Enqueue = new System.Windows.Forms.MenuItem();
            this.menuCourse_Download = new System.Windows.Forms.MenuItem();
            this.menuLesson = new System.Windows.Forms.ContextMenu();
            this.menuLesson_Enqueue = new System.Windows.Forms.MenuItem();
            this.menuLesson_Download = new System.Windows.Forms.MenuItem();
            this.menuChapter = new System.Windows.Forms.ContextMenu();
            this.menuChapter_Enqueue = new System.Windows.Forms.MenuItem();
            this.menuChapter_Download = new System.Windows.Forms.MenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCourseTitle = new System.Windows.Forms.Label();
            this.lblCourseTranscriptZip = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCourseVideoZip = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCourseSummary = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course URL";
            // 
            // txtCourseUrl
            // 
            this.txtCourseUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCourseUrl.Location = new System.Drawing.Point(83, 12);
            this.txtCourseUrl.Name = "txtCourseUrl";
            this.txtCourseUrl.Size = new System.Drawing.Size(956, 20);
            this.txtCourseUrl.TabIndex = 1;
            this.txtCourseUrl.Text = "";
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(1045, 10);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Get Info";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(15, 166);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblConsole);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstLessions);
            this.splitContainer1.Size = new System.Drawing.Size(1105, 489);
            this.splitContainer1.SplitterDistance = 539;
            this.splitContainer1.TabIndex = 3;
            // 
            // lblConsole
            // 
            this.lblConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConsole.Font = new System.Drawing.Font("Luculent", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsole.ForeColor = System.Drawing.Color.White;
            this.lblConsole.Location = new System.Drawing.Point(0, 0);
            this.lblConsole.Multiline = true;
            this.lblConsole.Name = "lblConsole";
            this.lblConsole.ReadOnly = true;
            this.lblConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblConsole.Size = new System.Drawing.Size(539, 489);
            this.lblConsole.TabIndex = 0;
            this.lblConsole.TabStop = false;
            // 
            // lstLessions
            // 
            this.lstLessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLessions.Location = new System.Drawing.Point(0, 0);
            this.lstLessions.Name = "lstLessions";
            this.lstLessions.Size = new System.Drawing.Size(562, 489);
            this.lstLessions.TabIndex = 0;
            this.lstLessions.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstLessions_MouseUp);
            // 
            // menuCourse
            // 
            this.menuCourse.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuCourse_Enqueue,
            this.menuCourse_Download});
            // 
            // menuCourse_Enqueue
            // 
            this.menuCourse_Enqueue.Index = 0;
            this.menuCourse_Enqueue.Text = "En&queue Course";
            // 
            // menuCourse_Download
            // 
            this.menuCourse_Download.Index = 1;
            this.menuCourse_Download.Text = "&Download Course";
            // 
            // menuLesson
            // 
            this.menuLesson.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuLesson_Enqueue,
            this.menuLesson_Download});
            // 
            // menuLesson_Enqueue
            // 
            this.menuLesson_Enqueue.Index = 0;
            this.menuLesson_Enqueue.Text = "En&queue Lesson";
            // 
            // menuLesson_Download
            // 
            this.menuLesson_Download.Index = 1;
            this.menuLesson_Download.Text = "&Download Lesson";
            // 
            // menuChapter
            // 
            this.menuChapter.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuChapter_Enqueue,
            this.menuChapter_Download});
            // 
            // menuChapter_Enqueue
            // 
            this.menuChapter_Enqueue.Index = 0;
            this.menuChapter_Enqueue.Text = "En&queue Video";
            // 
            // menuChapter_Download
            // 
            this.menuChapter_Download.Index = 1;
            this.menuChapter_Download.Text = "&Download Video";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Title:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblCourseSummary);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblCourseVideoZip);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblCourseTranscriptZip);
            this.groupBox1.Controls.Add(this.lblCourseTitle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1105, 122);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Course info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Transcript zip:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCourseTitle
            // 
            this.lblCourseTitle.AutoSize = true;
            this.lblCourseTitle.Location = new System.Drawing.Point(89, 21);
            this.lblCourseTitle.Name = "lblCourseTitle";
            this.lblCourseTitle.Size = new System.Drawing.Size(0, 13);
            this.lblCourseTitle.TabIndex = 6;
            // 
            // lblCourseTranscriptZip
            // 
            this.lblCourseTranscriptZip.AutoSize = true;
            this.lblCourseTranscriptZip.Location = new System.Drawing.Point(89, 69);
            this.lblCourseTranscriptZip.Name = "lblCourseTranscriptZip";
            this.lblCourseTranscriptZip.Size = new System.Drawing.Size(0, 13);
            this.lblCourseTranscriptZip.TabIndex = 7;
            this.lblCourseTranscriptZip.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCourseTranscriptZip_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Video zip:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCourseVideoZip
            // 
            this.lblCourseVideoZip.AutoSize = true;
            this.lblCourseVideoZip.Location = new System.Drawing.Point(89, 93);
            this.lblCourseVideoZip.Name = "lblCourseVideoZip";
            this.lblCourseVideoZip.Size = new System.Drawing.Size(0, 13);
            this.lblCourseVideoZip.TabIndex = 9;
            this.lblCourseVideoZip.Click += new System.EventHandler(this.lblCourseVideoZip_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Summary:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCourseSummary
            // 
            this.lblCourseSummary.AutoEllipsis = true;
            this.lblCourseSummary.AutoSize = true;
            this.lblCourseSummary.Location = new System.Drawing.Point(89, 45);
            this.lblCourseSummary.Name = "lblCourseSummary";
            this.lblCourseSummary.Size = new System.Drawing.Size(0, 13);
            this.lblCourseSummary.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnDownload;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 667);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtCourseUrl);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Udacity Downloader";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCourseUrl;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox lblConsole;
        private System.Windows.Forms.TreeView lstLessions;
        private System.Windows.Forms.ContextMenu menuCourse;
        private System.Windows.Forms.MenuItem menuCourse_Enqueue;
        private System.Windows.Forms.MenuItem menuCourse_Download;
        private System.Windows.Forms.ContextMenu menuLesson;
        private System.Windows.Forms.ContextMenu menuChapter;
        private System.Windows.Forms.MenuItem menuLesson_Enqueue;
        private System.Windows.Forms.MenuItem menuLesson_Download;
        private System.Windows.Forms.MenuItem menuChapter_Enqueue;
        private System.Windows.Forms.MenuItem menuChapter_Download;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel lblCourseTranscriptZip;
        private System.Windows.Forms.Label lblCourseTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lblCourseVideoZip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCourseSummary;
        private System.Windows.Forms.Label label5;
    }
}

