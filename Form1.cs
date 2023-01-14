using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinForms_NumUpDown
{
    /// <summary>
    /// Test with Arial font.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDownFontsize_ValueChanged(object sender, EventArgs e)
        {
            var fontsize = (float)this.numericUpDownFontsize.Value;
            this.Font = new Font(this.Font.FontFamily, fontsize);
        }

        private void customUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var fontsize = (float)this.customUpDown1.Value;
            this.Font = new Font(this.Font.FontFamily, fontsize);
        }
    }
}