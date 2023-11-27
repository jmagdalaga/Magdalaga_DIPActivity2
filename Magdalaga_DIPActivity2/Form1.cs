using WebCamLib;
using System.ComponentModel;
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
            firstImg = new Bitmap(1, 1);
            secImg = new Bitmap(1, 1);

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

                // Save the processed image from pictureBox2.Image
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
            openFileDialog1.ShowDialog();
        }

        private void btnloadbg_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            firstImg = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = firstImg;
        }

        private void btnsubtract_Click(object sender, EventArgs e)
        {
            if (firstImg == null || secImg == null)
            {
                MessageBox.Show("Ensure both images are loaded before subtracting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (timer1.Enabled && pictureBox2 != null && pictureBox2.Image != null)
            {
                timer2.Start();
            }
            else
            {
                subtractImages(secImg);
            }
        }

        public void subtractImages(Bitmap frame)
        {
            processed = new Bitmap(firstImg.Width, firstImg.Height);
            Color targetColor = Color.FromArgb(0, 255, 0);
            int targetGrey = (int)(targetColor.R + targetColor.G + targetColor.B) / 3;
            int threshold = 10;

            for (int x = 0; x < firstImg.Width; x++)
            {
                for (int y = 0; y < firstImg.Height; y++)
                {
                    Color fColor = firstImg.GetPixel(x, y);
                    Color bColor = frame.GetPixel(x, y);
                    int greyValue = (int)(fColor.R + fColor.G + fColor.B) / 3;

                    bool isCloseToTarget = Math.Abs(greyValue - targetGrey) < threshold;

                    processed.SetPixel(x, y, isCloseToTarget ? bColor : fColor);
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
            if (firstDevice == null)
            {
                try
                {
                    allDevices = DeviceManager.GetAllDevices();
                    firstDevice = allDevices[0];
                    if (allDevices.Length > 0)
                    {
                        string deviceInfo = "Available Devices:\n\n";

                        for (int i = 0; i < allDevices.Length; i++)
                        {
                            deviceInfo += $"Device {i + 1}: {allDevices[i].Name} - Version: {allDevices[i].Version}\n";
                        }
                        MessageBox.Show(deviceInfo, "Available Devices");

                        firstDevice.ShowWindow(pictureBox1);
                    }
                    else
                    {
                        MessageBox.Show("No webcam devices found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error initializing webcam: {ex.Message}");
                }
            }

        }

        private void btncloseWebcam_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null && timer1.Enabled)
            {
                timer1.Stop();
                pictureBox2.Image.Dispose();
                pictureBox2.Image = null;
                secImg = null;
            }
            if (pictureBox3.Image != null && timer2.Enabled)
            {
                timer2.Stop();
                pictureBox3.Image.Dispose();
                pictureBox3.Image = null;
            }
            if (firstDevice != null)
            {
                firstDevice.Stop();
                firstDevice = null;
            }

        }     
    }
}
