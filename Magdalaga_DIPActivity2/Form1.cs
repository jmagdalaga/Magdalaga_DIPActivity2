using WebCamLib;
using System.ComponentModel;
using System.Windows.Forms;

namespace Magdalaga_DIPActivity2
{
    public partial class Form1 : Form
    {
        Bitmap loaded;
        Bitmap processed;
        Bitmap img;
        Bitmap output;
        Bitmap bg;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

            loaded = new Bitmap(1, 1);
            processed = new Bitmap(1, 1);
            img = new Bitmap(1, 1);
            output = new Bitmap(1, 1);
            bg = new Bitmap(1, 1);
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            img = new Bitmap(openFileDialog.FileName);
            pictureBox1.Image = img;
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

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            img = new Bitmap(openFileDialog.FileName);
            pictureBox1.Image = img;
        }

        private void btnloadbg_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            img = new Bitmap(openFileDialog1.FileName);
            pictureBox2.Image = img;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox2.Image = loaded;
        }

        private void btnsubtract_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                output = new Bitmap(img.Width, img.Height);
                Color bgGreen = Color.FromArgb(0, 0, 255);
                int green = (int)(bgGreen.R + bgGreen.G + bgGreen.B) / 3;
                int greenThreshold = 10;

                for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        Color imageColor = img.GetPixel(i, j);
                        Color backgroundColor = bg.GetPixel(i, j);
                        int grey = (int)(imageColor.R + imageColor.G + imageColor.B) / 3;
                        int subtract = Math.Abs(grey - green);

                        if (subtract < greenThreshold)
                        {
                            output.SetPixel(i, j, backgroundColor);
                        }
                        else
                        {
                            output.SetPixel(i, j, imageColor);
                        }
                    }
                }
                pictureBox3.Image = output;
            }
            else
            {
                MessageBox.Show("Please put an image on Picture Box 2 to continue Subtraction", "Image Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openWebcamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Device[] allDevices = DeviceManager.GetAllDevices();

                if (allDevices.Length > 0)
                {
                    Device firstDevice = allDevices[0];
                    firstDevice.ShowWindow(pictureBox1);
                }
                else
                {
                    MessageBox.Show("There is no webcam device!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Try again, there is an error opening the webcam!", "Webcam Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeWebcamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Device[] allDevices = DeviceManager.GetAllDevices();

                if (allDevices.Length > 0)
                {
                    Device firstDevice = allDevices[0];
                    firstDevice.Stop();
                }
                else
                {
                    MessageBox.Show("There is no webcam device!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Try again, there is an error closing the webcam!", "Webcam Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
