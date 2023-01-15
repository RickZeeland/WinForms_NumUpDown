using System.Windows.Forms;

namespace WinForms_NumUpDown
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.customUpDown2 = new WinForms_NumUpDown.CustomUpDown();
            this.customUpDown1 = new WinForms_NumUpDown.CustomUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelFontsize = new System.Windows.Forms.Label();
            this.numericUpDownFontsize = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontsize)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(333, 243);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(325, 215);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.customUpDown2);
            this.groupBox3.Controls.Add(this.customUpDown1);
            this.groupBox3.Location = new System.Drawing.Point(18, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 93);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Custom";
            // 
            // customUpDown2
            // 
            this.customUpDown2.ButtonBackColor = System.Drawing.Color.Empty;
            this.customUpDown2.ButtonForeColor = System.Drawing.Color.Gray;
            this.customUpDown2.ButtonStyle = WinForms_NumUpDown.CustomUpDown.ButtonDisplay.Arrows;
            this.customUpDown2.DecimalPlaces = 0;
            this.customUpDown2.ForeColor = System.Drawing.Color.Chocolate;
            this.customUpDown2.Location = new System.Drawing.Point(16, 50);
            this.customUpDown2.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.customUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customUpDown2.Name = "customUpDown2";
            this.customUpDown2.RepeatDelayMs = 100;
            this.customUpDown2.Size = new System.Drawing.Size(189, 24);
            this.customUpDown2.TabIndex = 1;
            this.customUpDown2.Text = "Repeat delay in ms";
            this.customUpDown2.TextBackColor = System.Drawing.Color.White;
            this.customUpDown2.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.customUpDown2.ValueChanged += new System.EventHandler(this.customUpDown2_ValueChanged);
            // 
            // customUpDown1
            // 
            this.customUpDown1.ButtonBackColor = System.Drawing.Color.Empty;
            this.customUpDown1.ButtonForeColor = System.Drawing.Color.Gray;
            this.customUpDown1.ButtonStyle = WinForms_NumUpDown.CustomUpDown.ButtonDisplay.Arrows;
            this.customUpDown1.DecimalPlaces = 0;
            this.customUpDown1.ForeColor = System.Drawing.Color.Blue;
            this.customUpDown1.Location = new System.Drawing.Point(72, 20);
            this.customUpDown1.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.customUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.customUpDown1.Name = "customUpDown1";
            this.customUpDown1.RepeatDelayMs = 100;
            this.customUpDown1.Size = new System.Drawing.Size(133, 24);
            this.customUpDown1.TabIndex = 0;
            this.customUpDown1.Text = "Font size";
            this.customUpDown1.TextBackColor = System.Drawing.Color.White;
            this.customUpDown1.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.customUpDown1.ValueChanged += new System.EventHandler(this.customUpDown1_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelFontsize);
            this.groupBox1.Controls.Add(this.numericUpDownFontsize);
            this.groupBox1.Location = new System.Drawing.Point(18, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 62);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Standard";
            // 
            // labelFontsize
            // 
            this.labelFontsize.AutoSize = true;
            this.labelFontsize.Location = new System.Drawing.Point(16, 27);
            this.labelFontsize.Name = "labelFontsize";
            this.labelFontsize.Size = new System.Drawing.Size(56, 15);
            this.labelFontsize.TabIndex = 1;
            this.labelFontsize.Text = "Font size";
            // 
            // numericUpDownFontsize
            // 
            this.numericUpDownFontsize.Location = new System.Drawing.Point(106, 25);
            this.numericUpDownFontsize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownFontsize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownFontsize.Name = "numericUpDownFontsize";
            this.numericUpDownFontsize.Size = new System.Drawing.Size(42, 21);
            this.numericUpDownFontsize.TabIndex = 0;
            this.numericUpDownFontsize.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownFontsize.ValueChanged += new System.EventHandler(this.numericUpDownFontsize_ValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(325, 215);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Location = new System.Drawing.Point(40, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 68);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Font size";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(110, 29);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(64, 21);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDownFontsize_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(333, 243);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test NumericUpDown control";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontsize)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label labelFontsize;
        private NumericUpDown numericUpDownFontsize;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private GroupBox groupBox3;
        private CustomUpDown customUpDown1;
        private CustomUpDown customUpDown2;
    }
}