using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DumpImageToCode
{
    /// <summary>
    /// Dumps an image to a text file which can be used as inline code.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select Image file";
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Image files (*.jpg,*.png)|*.jpg;*.png";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.FileName = string.Empty;
            openFileDialog1.InitialDirectory = Application.StartupPath;         // Open in current directory

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Convert Image to byte array and save as hex code in text file.
        /// Test by loading the file and displaying the image.
        /// </summary>
        /// <param name="imageFilename">The image file name</param>
        private void DumpToCode(string imageFilename)
        {
            byte[] arr;
            Image image = Image.FromFile(imageFilename);
            Image testImage;
            string dumpFilename = string.Empty;

            using (MemoryStream ms = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(image);

                if (imageFilename.EndsWith(".png"))
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    dumpFilename = imageFilename.Replace(".png", ".txt");
                }
                if (imageFilename.EndsWith(".jpg"))
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    dumpFilename = imageFilename.Replace(".jpg", ".txt");
                }

                arr = ms.ToArray();
            }

            if (!string.IsNullOrEmpty(dumpFilename))
            {
                string hex = string.Join(" ", arr.Select(x => x.ToString("X2")));

                //Debug.Print(hex);
                File.WriteAllText(dumpFilename, hex);

                // Test: load image from hex file and display in picturebox
                testImage = LoadImageFromDump(dumpFilename);
                this.pictureBox1.Image = testImage;
            }
        }

        private Image LoadImageFromDump(string fileName)
        {
            string hex2 = File.ReadAllText(fileName);
            var hexArr = hex2.Split(' ');
            byte[] arr2 = new byte[hexArr.Length];

            for (int i = 0; i < hexArr.Length; i++)
            {
                arr2[i] = Convert.ToByte(hexArr[i], 16);
            }

            using (var ms2 = new MemoryStream(arr2))
            {
                return Image.FromStream(ms2);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DumpToCode(this.textBox1.Text);
        }
    }
}