namespace Magdalaga_DIPActivity2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openImageToolStripMenuItem = new ToolStripMenuItem();
            openWebcamToolStripMenuItem = new ToolStripMenuItem();
            closeWebcamToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            processImageToolStripMenuItem = new ToolStripMenuItem();
            basicCopyToolStripMenuItem = new ToolStripMenuItem();
            greyscaleToolStripMenuItem = new ToolStripMenuItem();
            colorInversionToolStripMenuItem = new ToolStripMenuItem();
            histogramToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            btnloadimage = new Button();
            btnloadbg = new Button();
            btnsubtract = new Button();
            openFileDialog = new OpenFileDialog();
            openFileDialog1 = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, processImageToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1354, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openImageToolStripMenuItem, openWebcamToolStripMenuItem, closeWebcamToolStripMenuItem, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // openImageToolStripMenuItem
            // 
            openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            openImageToolStripMenuItem.Size = new Size(224, 26);
            openImageToolStripMenuItem.Text = "Open Image";
            openImageToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // openWebcamToolStripMenuItem
            // 
            openWebcamToolStripMenuItem.Name = "openWebcamToolStripMenuItem";
            openWebcamToolStripMenuItem.Size = new Size(224, 26);
            openWebcamToolStripMenuItem.Text = "Open Webcam";
            openWebcamToolStripMenuItem.Click += openWebcamToolStripMenuItem_Click;
            // 
            // closeWebcamToolStripMenuItem
            // 
            closeWebcamToolStripMenuItem.Name = "closeWebcamToolStripMenuItem";
            closeWebcamToolStripMenuItem.Size = new Size(224, 26);
            closeWebcamToolStripMenuItem.Text = "Close Webcam";
            closeWebcamToolStripMenuItem.Click += closeWebcamToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(224, 26);
            saveToolStripMenuItem.Text = "Save";
            // 
            // processImageToolStripMenuItem
            // 
            processImageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { basicCopyToolStripMenuItem, greyscaleToolStripMenuItem, colorInversionToolStripMenuItem, histogramToolStripMenuItem, sepiaToolStripMenuItem });
            processImageToolStripMenuItem.Name = "processImageToolStripMenuItem";
            processImageToolStripMenuItem.Size = new Size(118, 24);
            processImageToolStripMenuItem.Text = "Process Image";
            // 
            // basicCopyToolStripMenuItem
            // 
            basicCopyToolStripMenuItem.Name = "basicCopyToolStripMenuItem";
            basicCopyToolStripMenuItem.Size = new Size(191, 26);
            basicCopyToolStripMenuItem.Text = "Basic Copy";
            basicCopyToolStripMenuItem.Click += basicCopyToolStripMenuItem_Click;
            // 
            // greyscaleToolStripMenuItem
            // 
            greyscaleToolStripMenuItem.Name = "greyscaleToolStripMenuItem";
            greyscaleToolStripMenuItem.Size = new Size(191, 26);
            greyscaleToolStripMenuItem.Text = "Greyscale";
            // 
            // colorInversionToolStripMenuItem
            // 
            colorInversionToolStripMenuItem.Name = "colorInversionToolStripMenuItem";
            colorInversionToolStripMenuItem.Size = new Size(191, 26);
            colorInversionToolStripMenuItem.Text = "Color Inversion";
            // 
            // histogramToolStripMenuItem
            // 
            histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            histogramToolStripMenuItem.Size = new Size(191, 26);
            histogramToolStripMenuItem.Text = "Histogram";
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(191, 26);
            sepiaToolStripMenuItem.Text = "Sepia";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(52, 73);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(381, 290);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(486, 73);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(381, 290);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(924, 73);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(381, 290);
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // btnloadimage
            // 
            btnloadimage.Location = new Point(155, 386);
            btnloadimage.Name = "btnloadimage";
            btnloadimage.Size = new Size(136, 29);
            btnloadimage.TabIndex = 4;
            btnloadimage.Text = "Load Image";
            btnloadimage.UseVisualStyleBackColor = true;
            btnloadimage.Click += button1_Click;
            // 
            // btnloadbg
            // 
            btnloadbg.Location = new Point(599, 386);
            btnloadbg.Name = "btnloadbg";
            btnloadbg.Size = new Size(140, 29);
            btnloadbg.TabIndex = 5;
            btnloadbg.Text = "Load Background";
            btnloadbg.UseVisualStyleBackColor = true;
            btnloadbg.Click += btnloadbg_Click;
            // 
            // btnsubtract
            // 
            btnsubtract.Location = new Point(1094, 386);
            btnsubtract.Name = "btnsubtract";
            btnsubtract.Size = new Size(94, 29);
            btnsubtract.TabIndex = 6;
            btnsubtract.Text = "Subtract";
            btnsubtract.UseVisualStyleBackColor = true;
            btnsubtract.Click += btnsubtract_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1354, 450);
            Controls.Add(btnsubtract);
            Controls.Add(btnloadbg);
            Controls.Add(btnloadimage);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openImageToolStripMenuItem;
        private ToolStripMenuItem openWebcamToolStripMenuItem;
        private ToolStripMenuItem closeWebcamToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem processImageToolStripMenuItem;
        private ToolStripMenuItem basicCopyToolStripMenuItem;
        private ToolStripMenuItem greyscaleToolStripMenuItem;
        private ToolStripMenuItem colorInversionToolStripMenuItem;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button btnloadimage;
        private Button btnloadbg;
        private Button btnsubtract;
        private OpenFileDialog openFileDialog;
        private OpenFileDialog openFileDialog1;
    }
}