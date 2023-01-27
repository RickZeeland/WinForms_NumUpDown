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
            this.buttonDisable = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.customUpDown2 = new WinForms_NumUpDown.CustomUpDown();
            this.customUpDown1 = new WinForms_NumUpDown.CustomUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelFontsize = new System.Windows.Forms.Label();
            this.numericUpDownFontsize = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.customUpDown6 = new WinForms_NumUpDown.CustomUpDown();
            this.customUpDown5 = new WinForms_NumUpDown.CustomUpDown();
            this.customUpDown4 = new WinForms_NumUpDown.CustomUpDown();
            this.customUpDown3 = new WinForms_NumUpDown.CustomUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontsize)).BeginInit();
            this.tabPage2.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(325, 277);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.buttonDisable);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(317, 249);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // buttonDisable
            // 
            this.buttonDisable.Location = new System.Drawing.Point(210, 212);
            this.buttonDisable.Name = "buttonDisable";
            this.buttonDisable.Size = new System.Drawing.Size(75, 23);
            this.buttonDisable.TabIndex = 1;
            this.buttonDisable.Text = "Disable";
            this.buttonDisable.UseVisualStyleBackColor = true;
            this.buttonDisable.Click += new System.EventHandler(this.buttonDisable_Click);
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
            this.customUpDown2.ButtonForeColor = System.Drawing.Color.Chocolate;
            this.customUpDown2.ButtonStyle = WinForms_NumUpDown.CustomUpDown.ButtonDisplay.Arrows;
            this.customUpDown2.DecimalPlaces = 0;
            this.customUpDown2.ForeColor = System.Drawing.Color.Chocolate;
            this.customUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.customUpDown1.ButtonForeColor = System.Drawing.Color.Blue;
            this.customUpDown1.ButtonStyle = WinForms_NumUpDown.CustomUpDown.ButtonDisplay.Arrows;
            this.customUpDown1.DecimalPlaces = 2;
            this.customUpDown1.ForeColor = System.Drawing.Color.Blue;
            this.customUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
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
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.customUpDown6);
            this.tabPage2.Controls.Add(this.customUpDown5);
            this.tabPage2.Controls.Add(this.customUpDown4);
            this.tabPage2.Controls.Add(this.customUpDown3);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(317, 263);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "ButtonStyles";
            // 
            // customUpDown6
            // 
            this.customUpDown6.BackColor = System.Drawing.Color.White;
            this.customUpDown6.ButtonBackColor = System.Drawing.Color.Empty;
            this.customUpDown6.ButtonForeColor = System.Drawing.Color.Gray;
            this.customUpDown6.ButtonStyle = WinForms_NumUpDown.CustomUpDown.ButtonDisplay.PlusMinus3;
            this.customUpDown6.DecimalPlaces = 0;
            this.customUpDown6.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customUpDown6.Location = new System.Drawing.Point(60, 142);
            this.customUpDown6.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.customUpDown6.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.customUpDown6.Name = "customUpDown6";
            this.customUpDown6.RepeatDelayMs = 100;
            this.customUpDown6.Size = new System.Drawing.Size(164, 23);
            this.customUpDown6.TabIndex = 3;
            this.customUpDown6.Text = "PlusMinus3";
            this.customUpDown6.TextBackColor = System.Drawing.Color.White;
            this.customUpDown6.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // customUpDown5
            // 
            this.customUpDown5.BackColor = System.Drawing.Color.White;
            this.customUpDown5.ButtonBackColor = System.Drawing.Color.Empty;
            this.customUpDown5.ButtonForeColor = System.Drawing.Color.Gray;
            this.customUpDown5.ButtonStyle = WinForms_NumUpDown.CustomUpDown.ButtonDisplay.PlusMinus2;
            this.customUpDown5.DecimalPlaces = 0;
            this.customUpDown5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customUpDown5.Location = new System.Drawing.Point(60, 113);
            this.customUpDown5.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.customUpDown5.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.customUpDown5.Name = "customUpDown5";
            this.customUpDown5.RepeatDelayMs = 100;
            this.customUpDown5.Size = new System.Drawing.Size(164, 23);
            this.customUpDown5.TabIndex = 2;
            this.customUpDown5.Text = "PlusMinus2";
            this.customUpDown5.TextBackColor = System.Drawing.Color.White;
            this.customUpDown5.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // customUpDown4
            // 
            this.customUpDown4.BackColor = System.Drawing.Color.White;
            this.customUpDown4.ButtonBackColor = System.Drawing.Color.Empty;
            this.customUpDown4.ButtonForeColor = System.Drawing.Color.Gray;
            this.customUpDown4.ButtonStyle = WinForms_NumUpDown.CustomUpDown.ButtonDisplay.PlusMinus;
            this.customUpDown4.DecimalPlaces = 0;
            this.customUpDown4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customUpDown4.Location = new System.Drawing.Point(60, 84);
            this.customUpDown4.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.customUpDown4.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.customUpDown4.Name = "customUpDown4";
            this.customUpDown4.RepeatDelayMs = 100;
            this.customUpDown4.Size = new System.Drawing.Size(164, 23);
            this.customUpDown4.TabIndex = 1;
            this.customUpDown4.Text = "PlusMinus";
            this.customUpDown4.TextBackColor = System.Drawing.Color.White;
            this.customUpDown4.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // customUpDown3
            // 
            this.customUpDown3.BackColor = System.Drawing.Color.White;
            this.customUpDown3.ButtonBackColor = System.Drawing.Color.Empty;
            this.customUpDown3.ButtonForeColor = System.Drawing.Color.Gray;
            this.customUpDown3.ButtonStyle = WinForms_NumUpDown.CustomUpDown.ButtonDisplay.Arrows;
            this.customUpDown3.DecimalPlaces = 0;
            this.customUpDown3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customUpDown3.Location = new System.Drawing.Point(60, 55);
            this.customUpDown3.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.customUpDown3.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.customUpDown3.Name = "customUpDown3";
            this.customUpDown3.RepeatDelayMs = 100;
            this.customUpDown3.Size = new System.Drawing.Size(164, 23);
            this.customUpDown3.TabIndex = 0;
            this.customUpDown3.Text = "Arrows";
            this.customUpDown3.TextBackColor = System.Drawing.Color.White;
            this.customUpDown3.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(325, 277);
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
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label labelFontsize;
        private NumericUpDown numericUpDownFontsize;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private CustomUpDown customUpDown1;
        private CustomUpDown customUpDown2;
        private Label label1;
        private CustomUpDown customUpDown6;
        private CustomUpDown customUpDown5;
        private CustomUpDown customUpDown4;
        private CustomUpDown customUpDown3;
        private Button buttonDisable;
    }
}