using WebCamLib;
using System.ComponentModel;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Magdalaga_DIPActivity2
{
    public partial class Form1 : Form
    {
        Bitmap loaded;
        Bitmap processed;
        Bitmap img;
        Bitmap firstImg;
        Bitmap secImg;
        Device firstDevice;
        Device[] allDevices;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

            loaded = new Bitmap(1, 1);
            processed = new Bitmap(1, 1);
            img = new Bitmap(1, 1);
        }

        private void basicCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pxl;
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    pxl = loaded.GetPixel(i, j);
                    processed.SetPixel(i, j, pxl);
                }
            }
            pictureBox2.Image = processed;
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pxl;
            byte gray;
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int i = 0; i < processed.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    pxl = loaded.GetPixel(i, j);
                    gray = (byte)((pxl.R + pxl.G + pxl.B) / 3);
                    processed.SetPixel(i, j, Color.FromArgb(gray, gray, gray));

                }
            }
            pictureBox2.Image = processed;
        }

        private void colorInversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pxl;
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    pxl = loaded.GetPixel(i, j);
                    processed.SetPixel(i, j, Color.FromArgb(255 - pxl.R, 255 - pxl.G, 255 - pxl.B));
                }
            }
            pictureBox2.Image = processed;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] histogram = new int[256];

            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    Color pxl = loaded.GetPixel(i, j);
                    int grayValue = (int)((pxl.R + pxl.G + pxl.B) / 3);
                    histogram[grayValue]++;
                }
            }

            int maxCount = histogram.Max();
            for (int i = 0; i < histogram.Length; i++)
            {
                histogram[i] = (int)((double)histogram[i] / maxCount * 100);
            }

            processed = new Bitmap(256, 100);
            using (Graphics g = Graphics.FromImage(processed))
            {
                for (int i = 0; i < histogram.Length; i++)
                {
                    g.DrawLine(Pens.Black, i, 100, i, 100 - histogram[i]);
                }
            }
            pictureBox2.Image = processed;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pxl;
            processed = new Bitmap(loaded.Width, loaded.Height);

            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    pxl = loaded.GetPixel(i, j);

                    int newR = (int)(0.393 * pxl.R + 0.769 * pxl.G + 0.189 * pxl.B);
                    int newG = (int)(0.349 * pxl.R + 0.686 * pxl.G + 0.168 * pxl.B);
                    int newB = (int)(0.272 * pxl.R + 0.534 * pxl.G + 0.131 * pxl.B);

                    newR = (newR > 255) ? 255 : (newR < 0) ? 0 : newR;
                    newG = (newG > 255) ? 255 : (newG < 0) ? 0 : newG;
                    newB = (newB > 255) ? 255 : (newB < 0) ? 0 : newB;

                    processed.SetPixel(i, j, Color.FromArgb(newR, newG, newB));
                }
            }
            pictureBox2.Image = processed;
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            loaded = new Bitmap(openFileDialog.FileName);
            pictureBox1.Image = loaded;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp|GIF Image|*.gif";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                if (pictureBox2.Image != null)
                {
                    processed.Save(filePath);
                    MessageBox.Show("The image has been successfully saved!");
                }
                else
                {
                    MessageBox.Show("There is no processed image to be saved!");
                }
            }
        }

        private void btnloadimg_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
        }

        private void btnloadbg_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog(this);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            firstImg = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = firstImg;
        }

        private void btnsubtract_Click(object sender, EventArgs e)
        {
            if (secImg == null || firstImg == null)
            {
                MessageBox.Show("Ensure to have both images before subtracting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(timer1.Enabled && pictureBox2 != null && pictureBox2.Image != null))
            {
                subtractImages(secImg);
            }
            else
            {
                timer2.Start();
            }
        }

        public void subtractImages(Bitmap frame)
        {
            processed = new Bitmap(firstImg.Width, firstImg.Height);
            Color myGreen = Color.FromArgb(0, 255, 0);
            int greyGreen = (myGreen.R + myGreen.G + myGreen.B) / 3;
            int threshold = 10;

            for (int x = 0; x < firstImg.Width; x++)
            {
                for (int y = 0; y < firstImg.Height; y++)
                {
                    Color fColor = firstImg.GetPixel(x, y);

                    int frameY = Math.Min(y, frame.Height - 1);
                    Color bColor = frame.GetPixel(x, frameY);

                    int grey = (fColor.R + fColor.G + fColor.B) / 3;
                    bool isGreen = Math.Abs(grey - greyGreen) < threshold;

                    processed.SetPixel(x, y, isGreen ? bColor : fColor);
                }
            }

            pictureBox3.Image = processed;
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            secImg = new Bitmap(openFileDialog2.FileName);
            pictureBox2.Image = secImg;
        }

        private void btnopenWebcam_Click(object sender, EventArgs e)
        {
            try
            {
                Device[] allDevices = DeviceManager.GetAllDevices();

                if (allDevices.Length > 0)
                {
                    firstDevice = allDevices[0];
                    firstDevice.ShowWindow(pictureBox2);

                    pictureBox3?.Image?.Dispose();

                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("There is no webcam devices found.", "No Devices", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Try again, there is an error initializing the webcam.", "Webcam Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (firstDevice == null)
            {
                MessageBox.Show("There is no device selected.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncloseWebcam_Click(object sender, EventArgs e)
        {
            StopAndDisposeTimerAndImage(pictureBox2, timer1);
            StopAndDisposeTimerAndImage(pictureBox3, timer2);

            firstDevice?.Stop();
        }

        private void StopAndDisposeTimerAndImage(PictureBox pictureBox, System.Windows.Forms.Timer timer)
        {
            if (pictureBox.Image != null && timer.Enabled)
            {
                timer.Stop();
                pictureBox.Image?.Dispose();
                pictureBox.Image = null;
            }
        }
        private Bitmap CaptureAndRetrieveImage()
        {
            if (firstDevice == null)
            {
                MessageBox.Show("Please select a device, there is no device selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            firstDevice.Sendmessage();

            if (Clipboard.GetDataObject() is IDataObject data && data.GetData("System.Drawing.Bitmap", true) is Image bmap)
            {
                return new Bitmap(bmap);
            }

            return null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (firstDevice != null)
            {
                secImg = CaptureAndRetrieveImage();
                if (secImg != null)
                {
                    if (pictureBox2 != null && pictureBox2.Image != null)
                    {
                        pictureBox2.Image.Dispose();
                    }
                    pictureBox2.Image = secImg;
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            Bitmap newFrame = CaptureAndRetrieveImage();
            if (newFrame != null)
            {
                subtractImages(newFrame);
            }
        }
    }
}
