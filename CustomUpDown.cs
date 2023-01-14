using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WinForms_NumUpDown
{
    /// <summary>
    /// Custom Numeric UpDown Control.
    /// Button color can be set with ForeColor and BackColor.
    /// </summary>
    public class CustomUpDown : Control
    {
        public event EventHandler ValueChanged;

        public int Value { get; set; }

        public int Maximum { get; set; } = 100;

        public int Minimum { get; set; } = 0;

        /// <summary>
        /// Button repeat delay in milliseconds.
        /// </summary>
        public int RepeatDelayMs { get; set; } = 100;

        public enum ButtonDisplay { Arrows, PlusMinus };

        public ButtonDisplay ButtonStyle { get; set; }

        private TextBox textBox;

        private Button buttonUp;

        private Button buttonDown;

        /// <summary>
        /// Control height is determined by Font size.
        /// </summary>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            Debug.Print($"Font Size = {Font.Size}  Height = {Font.Height}");
            height = Font.Height + 8;
            base.SetBoundsCore(x, y, width, height, specified);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomUpDown"/> class.
        /// </summary>
        public CustomUpDown()
        {
            ForeColor = Color.Gray;
            textBox = new TextBox();
            Value = Minimum;
            textBox.KeyPress += TextBox_KeyPress;
            Controls.Add(textBox);
            buttonUp = new Button();
            AddButtonUp();
            buttonDown = new Button();
            AddbuttonDown();
        }

        /// <summary>
        /// Allow only digits and backspace key.
        /// </summary>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void AddButtonUp()
        {
            buttonUp.Name = "ButtonUp";
            buttonUp.FlatStyle = FlatStyle.Flat;
            buttonUp.FlatAppearance.BorderSize = 0;
            buttonUp.TextAlign = ContentAlignment.TopCenter;
            buttonUp.MouseDown += ButtonUpClick;
            Controls.Add(buttonUp);
        }

        private void AddbuttonDown()
        {
            buttonDown.Name = "buttonDown";
            buttonDown.FlatStyle = FlatStyle.Flat;
            buttonDown.FlatAppearance.BorderSize = 0;
            buttonDown.TextAlign = ContentAlignment.TopCenter;
            buttonDown.MouseDown += ButtonDownClick;
            Controls.Add(buttonDown);
        }

        /// <summary>
        /// Custom OnPaint() draws TextBox and two Buttons.
        /// </summary>
        /// <param name="e">The PaintEventArgs</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (ButtonStyle == ButtonDisplay.PlusMinus)
            {
                buttonUp.Text = "+";
                buttonDown.Text = "-";
            }
            else
            {
                buttonUp.Text = "▲";
                buttonDown.Text = "▼";
            }

            int buttonHeight = textBox.Height - 2;
            textBox.Width = Width - 2 * buttonHeight;
            textBox.Location = new Point(0, 0);
            buttonUp.Size = new Size(buttonHeight, buttonHeight);
            buttonDown.Size = buttonUp.Size;
            buttonUp.Location = new Point(Width - 2 * buttonHeight, 0);
            buttonDown.Location = new Point(Width - buttonHeight, 0);
            textBox.Text = Value.ToString();
            base.OnPaint(e);
        }

        /// <summary>
        /// Button Up click, increment textBox value.
        /// Repeat when left button is kept pressed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ButtonUpClick(object sender, MouseEventArgs e)
        {
            int delayMs = 300;      // Initial delay before repeating

            while ((MouseButtons & MouseButtons.Left) != 0)
            {
                if (AddValue(1))
                {
                    Application.DoEvents();
                    Thread.Sleep(delayMs);
                    delayMs = RepeatDelayMs;
                }

                Application.DoEvents();
            }

            ValueChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Button Down click, decrement textBox value.
        /// Repeat when left button is kept pressed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ButtonDownClick(object sender, MouseEventArgs e)
        {
            int delayMs = 300;

            while ((MouseButtons & MouseButtons.Left) != 0)
            {
                if (AddValue(-1))
                {
                    Application.DoEvents();
                    Thread.Sleep(delayMs);
                    delayMs = RepeatDelayMs;
                }

                Application.DoEvents();
            }

            ValueChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Increment or decrement the TextBox value.
        /// </summary>
        /// <param name="value">The value</param>
        private bool AddValue(int value)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {

                Value = Minimum;
                textBox.Text = Value.ToString();
                return false;
            }

            int num = Value + value;

            if (num < Minimum)
            {
                Value = Minimum;
            }
            else if (num > Maximum)
            {
                Value = Maximum;
            }
            else
            {
                Value = num;
                textBox.Text = Value.ToString();
                return true;
            }

            textBox.Text = Value.ToString();
            return false;
        }
    }
}
