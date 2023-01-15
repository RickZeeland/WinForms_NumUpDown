using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinForms_NumUpDown
{
    /// <summary>
    /// Test Custom Numeric UpDown Control with Arial font.
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

        private void customUpDown2_ValueChanged(object sender, EventArgs e)
        {
            this.customUpDown1.RepeatDelayMs = (int)this.customUpDown2.Value;
            this.customUpDown2.RepeatDelayMs = (int)this.customUpDown2.Value;
        }
    }
}