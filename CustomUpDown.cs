using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WinForms_NumUpDown
{
    /// <summary>
    /// Custom Numeric UpDown Control.
    /// </summary>
    public class CustomUpDown : Control
    {
        public event EventHandler ValueChanged;

        [Category("CustomUpDown"), Description("Gets or sets the default value in textBox"), RefreshProperties(RefreshProperties.Repaint)]
        public decimal Value 
        {
            get
            {
                return valueLocal;
            }

            set
            {
                if (DecimalPlaces == 0)
                {
                    valueLocal = value;
                }
                else if (DecimalPlaces > 0 && DecimalPlaces < 7)         // Allow max 6 decimals
                {
                    valueLocal = Math.Round(value, DecimalPlaces);
                }

                Invalidate();
            }
        }

        [Category("CustomUpDown"), Description("Gets or sets the decimal places (max 6)")]
        public int DecimalPlaces { get; set; } = 0;

        [Category("CustomUpDown"), Description("Gets or sets the increment value")]
        public decimal Increment { get; set; } = 1;

        [Category("CustomUpDown"), Description("Gets or sets the Maximum value")]
        public decimal Maximum { get; set; } = 100;

        [Category("CustomUpDown"), Description("Gets or sets the Minimum value")]
        public decimal Minimum { get; set; } = 0;

        [Category("CustomUpDown"), Description("Gets or sets the button repeat delay in milliseconds")]
        public int RepeatDelayMs { get; set; } = 100;

        [Category("CustomUpDown"), Description("Gets or sets the button fore color"), RefreshProperties(RefreshProperties.Repaint)]
        public Color ButtonForeColor
        {
            get { return buttonForeColor; }

            set
            {
                buttonForeColor = value;
                Invalidate();
            }
        }

        [Category("CustomUpDown"), Description("Gets or sets the button back color"), RefreshProperties(RefreshProperties.Repaint)]
        public Color ButtonBackColor
        {
            get { return buttonBackColor; }

            set
            {
                buttonBackColor = value;
                Invalidate();
            }
        }

        [Category("CustomUpDown"), Description("Gets or sets the textbox back color (default White), use ForeColor for the text color"), RefreshProperties(RefreshProperties.Repaint)]
        public Color TextBackColor
        {
            get { return textBackColor; }

            set
            {
                textBackColor = value;
                Invalidate();
            }
        }

        public enum ButtonDisplay { Arrows, PlusMinus };

        [Category("CustomUpDown"), Description("Gets or sets the Button display style"), RefreshProperties(RefreshProperties.Repaint)]
        public ButtonDisplay ButtonStyle
        {
            get { return buttonstyle; }

            set 
            { 
                buttonstyle = value; 
                Invalidate();
            }
        }

        [Category("CustomUpDown"), Description("Gets or sets the optional label text (with ForeColor as the color)"), RefreshProperties(RefreshProperties.Repaint)]
        public new string Text
        {
            get { return base.Text; }

            set
            {
                if (!value.StartsWith("customUpDown"))      // Ignore default designer text
                {
                    label1.Text = value;
                    base.Text = value;  
                }

                Invalidate();
            }
        }

        private ButtonDisplay buttonstyle;

        private Label label1;

        private TextBox textBox;

        private Button buttonUp;

        private Button buttonDown;

        private Color buttonForeColor;

        private Color buttonBackColor;

        private Color textBackColor;

        private decimal valueLocal;

        ///// <summary>
        ///// Control height is determined by Font size.
        ///// </summary>
        //protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        //{
        //    Debug.Print($"Font Size = {Font.Size}  Height = {Font.Height}");
        //    height = Font.Height + 8;
        //    base.SetBoundsCore(x, y, width, height, specified);
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomUpDown"/> class.
        /// </summary>
        public CustomUpDown()
        {
            buttonForeColor = Color.Gray;
            textBackColor = Color.White;
            label1 = new Label();
            Controls.Add(label1);
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
        /// Allow only digits, Enter and Backspace key.
        /// </summary>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddValue(0);
                e.Handled = false;
                ValueChanged?.Invoke(this, e);
            }
            else if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                e.Handled = !(DecimalPlaces > 0);
            }
            else
            {
                e.Handled = true;
            }
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
        /// Custom OnPaint() draws Label, TextBox and two Buttons.
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

            textBox.Text = Value.ToString();
            textBox.BackColor = TextBackColor;
            textBox.ForeColor = ForeColor;
            int buttonHeight = textBox.Height;
            int buttonWidth = (int)(textBox.Height * 0.8);

            if (string.IsNullOrEmpty(label1.Text))
            {
                label1.Visible = false;
                textBox.Width = Width - 2 * buttonWidth;
                textBox.Location = new Point(0, 0);
            }
            else
            {
                label1.BackColor = BackColor;
                textBox.Width = (int)(Math.Max(3, textBox.Text.Length) * Font.Size);
                label1.Width = Width - textBox.Width - 2 * buttonWidth;
                label1.Location = new Point(0, 2);
                textBox.Location = new Point(label1.Width, 0);
            }

            buttonUp.ForeColor = ButtonForeColor;
            buttonDown.ForeColor = ButtonForeColor;
            buttonUp.BackColor = ButtonBackColor;
            buttonDown.BackColor = ButtonBackColor;
            buttonUp.Size = new Size(buttonWidth, buttonHeight);
            buttonDown.Size = buttonUp.Size;
            buttonUp.Location = new Point(Width - 2 * buttonWidth, 0);
            buttonDown.Location = new Point(Width - buttonWidth, 0);
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
                if (AddValue(Increment))
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
                if (AddValue(-Increment))
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
        private bool AddValue(decimal value)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {

                Value = Minimum;
                textBox.Text = Value.ToString();
                return false;
            }
            else if (textBox.TextLength > 25)
            {
                Debug.Print("Too many significant digits for decimal");
                Value = Maximum;
                textBox.Text = Value.ToString();
                return false;
            }

            Value = Math.Round(Convert.ToDecimal(textBox.Text) + value, DecimalPlaces);

            if (Value < Minimum)
            {
                Value = Minimum;
            }
            else if (Value > Maximum)
            {
                Value = Maximum;
            }
            else
            {
                textBox.Text = Value.ToString();
                return true;
            }

            textBox.Text = Value.ToString();
            return false;
        }
    }
}
