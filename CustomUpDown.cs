﻿using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Griffid.Customization
{
    /// <summary>
    /// Custom Numeric UpDown Control.
    /// </summary>
    public class CustomUpDown : Control
    {
        public int Value { get; set; }

        public int Maximum { get; set; } = 100;

        public int Minimum { get; set; } = 0;

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
            height = (int)(this.Font.Size * 2) + 3;
            base.SetBoundsCore(x, y, width, height, specified);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomUpDown"/> class.
        /// </summary>
        public CustomUpDown()
        {
            textBox = new TextBox();
            this.Value = Minimum;
            textBox.KeyPress += this.TextBox_KeyPress;
            this.Controls.Add(textBox);
            buttonUp = new Button();
            this.AddButtonUp();
            buttonDown = new Button();
            this.AddbuttonDown();
        }

        /// <summary>
        /// Allow only digits and backspace key.
        /// </summary>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back));
        }

        private void AddButtonUp()
        {
            buttonUp.Name = "ButtonUp";
            buttonUp.FlatStyle = FlatStyle.Flat;
            buttonUp.FlatAppearance.BorderSize = 0;
            buttonUp.BackColor = Color.Transparent;
            buttonUp.ForeColor = Color.DarkGray;
            buttonUp.TextAlign = ContentAlignment.TopCenter;
            buttonUp.MouseDown += this.ButtonUpClick;
            this.Controls.Add(buttonUp);
        }

        private void AddbuttonDown()
        {
            buttonDown.Name = "buttonDown";
            buttonDown.FlatStyle = FlatStyle.Flat;
            buttonDown.FlatAppearance.BorderSize = 0;
            buttonDown.BackColor = Color.Transparent;
            buttonDown.ForeColor = Color.DarkGray;
            buttonDown.TextAlign = ContentAlignment.TopCenter;
            buttonDown.MouseDown += this.ButtonDownClick;
            this.Controls.Add(buttonDown);
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
            textBox.Width = this.Width - (2 * buttonHeight);
            textBox.Location = new Point(0, 0);
            buttonUp.Size = new Size(buttonHeight, buttonHeight);
            buttonDown.Size = buttonUp.Size;
            buttonUp.Location = new Point(this.Width - (2 * buttonHeight), 0);
            buttonDown.Location = new Point(this.Width - buttonHeight, 0);
            textBox.Text = this.Value.ToString();
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
            int delayMs = 300;

            while ((MouseButtons & MouseButtons.Left) != 0)
            {
                if (this.AddValue(1))
                {
                    Application.DoEvents();
                    Thread.Sleep(delayMs);
                    delayMs = 100;
                }

                Application.DoEvents();
            }
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
                if (this.AddValue(-1))
                {
                    Application.DoEvents();
                    Thread.Sleep(delayMs);
                    delayMs = 100;
                }

                Application.DoEvents();
            }
        }

        /// <summary>
        /// Increment or decrement the TextBox value.
        /// </summary>
        /// <param name="value">The value</param>
        private bool AddValue(int value)
        {
            if (string.IsNullOrEmpty(this.textBox.Text))
            {

                this.Value = this.Minimum;
                this.textBox.Text = this.Value.ToString(); 
                return false;
            }

            int num = this.Value + value;

            if (num < Minimum)
            {
                this.Value = this.Minimum;
            }
            else if (num > Maximum)
            {
                this.Value = this.Maximum;
            }
            else
            {
                this.Value = num;
                this.textBox.Text = this.Value.ToString();
                return true;
            }

            this.textBox.Text = this.Value.ToString();
            return false;
        }
    }
}