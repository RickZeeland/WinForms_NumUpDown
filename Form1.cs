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

        /// <summary>
        /// Toggle the enabled state of the groupbox with the custom NumUpDown controls.
        /// </summary>
        private void buttonDisable_Click(object sender, EventArgs e)
        {
            this.groupBox3.Enabled = !this.groupBox3.Enabled;
            this.buttonDisable.Text = this.groupBox3.Enabled ? "Disable" : "Enable";
        }
    }
}