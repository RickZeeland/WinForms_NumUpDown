using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        [Category("CustomUpDown"), Description("Gets or sets the Maximum value (max 25 significant digits)")]
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

        public enum ButtonDisplay { Arrows, PlusMinus, PlusMinus2 };

        [Category("CustomUpDown"), Description("Gets or sets the Button display style"), RefreshProperties(RefreshProperties.Repaint)]
        public ButtonDisplay ButtonStyle
        {
            get { return buttonstyle; }

            set 
            { 
                buttonstyle = value;

                if (buttonstyle == ButtonDisplay.PlusMinus)
                {
                    // Simple text buttons
                    buttonUp.Text = "+";
                    buttonDown.Text = "-";
                    buttonUp.BackgroundImage?.Dispose();
                    buttonDown.BackgroundImage?.Dispose();
                }
                else if (buttonstyle == ButtonDisplay.PlusMinus2)
                {
                    // Buttons with icons
                    if (plusIcon == null)
                    {
                        plusIcon = GetImageFromHexString(plusIconCode);
                    }

                    if (minusIcon == null)
                    {
                        minusIcon = GetImageFromHexString(minusIconCode);
                    }

                    buttonUp.Text = "";
                    buttonDown.Text = "";
                    buttonUp.BackgroundImage = plusIcon;
                    buttonUp.BackgroundImageLayout = ImageLayout.Zoom;
                    buttonDown.BackgroundImage = minusIcon;
                    buttonDown.BackgroundImageLayout = ImageLayout.Zoom;
                }
                else
                {
                    // Standard Arrow buttons
                    buttonUp.Text = "▲";
                    buttonDown.Text = "▼";
                    buttonUp.BackgroundImage?.Dispose();
                    buttonDown.BackgroundImage?.Dispose();
                }

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
                }

                base.Text = value;
                Invalidate();
            }
        }

        private ButtonDisplay buttonstyle;

        private Label label1;

        private bool label1Init;

        private TextBox textBox;

        private Button buttonUp;

        private Button buttonDown;

        private Color buttonForeColor;

        private Color buttonBackColor;

        private Color textBackColor;

        private decimal valueLocal;

        /// <summary>
        /// Code for plus icon generated by DumpImageToCode tool
        /// </summary>
        private string plusIconCode = "89 50 4E 47 0D 0A 1A 0A 00 00 00 0D 49 48 44 52 00 00 00 1A 00 00 00 1A 08 06 00 00 00 A9 4A 4C CE 00 00 00 01 73 52 47 42 00 AE CE 1C E9 00 00 00 04 67 41 4D 41 00 00 B1 8F 0B FC 61 05 00 00 00 09 70 48 59 73 00 00 0E C3 00 00 0E C3 01 C7 6F A8 64 00 00 00 58 49 44 41 54 48 4B ED 93 51 0A 00 21 08 44 BD FF C5 6A F7 52 E5 C2 06 11 1A 31 62 5F F3 E0 FD 88 3A 5F 23 E4 16 AF DA 7E EB 37 C8 62 84 0C D3 60 10 0C 83 5C E6 9E 44 DD F6 CC 3A 88 E8 62 2D 47 74 79 54 EB 00 B1 A8 30 EB B3 34 18 04 C3 20 98 B9 67 A1 9E 90 43 44 3A 27 6F 8D BD 18 59 7F D5 00 00 00 00 49 45 4E 44 AE 42 60 82";

        private Image plusIcon;

        /// <summary>
        /// Code for minus icon generated by DumpImageToCode tool
        /// </summary>
        private string minusIconCode = "89 50 4E 47 0D 0A 1A 0A 00 00 00 0D 49 48 44 52 00 00 00 1A 00 00 00 1A 08 06 00 00 00 A9 4A 4C CE 00 00 00 01 73 52 47 42 00 AE CE 1C E9 00 00 00 04 67 41 4D 41 00 00 B1 8F 0B FC 61 05 00 00 00 09 70 48 59 73 00 00 0E C3 00 00 0E C3 01 C7 6F A8 64 00 00 00 38 49 44 41 54 48 4B ED CB BB 0D 00 20 0C 03 D1 EC BF 18 9F A5 C0 03 38 0D 41 82 E2 9E 74 9D 1D 00 F0 8F A9 D6 A5 BA 4A B9 43 A5 94 1B 57 4A 0D E5 0E 27 35 05 00 EF 45 6C 09 E6 4E D7 AD BA 2E B0 00 00 00 00 49 45 4E 44 AE 42 60 82";

        private Image minusIcon;

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
        /// Clear the default designer Text / resize when user enters Text.
        /// </summary>
        /// <param name="e">The EventArgs</param>
        protected override void OnTextChanged(EventArgs e)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                if (Text.StartsWith("customUpDown"))    // default designer Text
                {
                    Text = string.Empty;
                    label1Init = true;
                }
                else if (label1Init)                    // User entered Text for label1
                {
                    int buttonWidth = (int)(textBox.Height * 0.8);
                    Width = (int)(Text.Length * Font.Size + textBox.Width + 2 * buttonWidth);
                    label1Init = false;
                }
            }

            base.OnTextChanged(e);
        }

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
            buttonstyle = ButtonDisplay.Arrows;
            buttonUp.Text = "▲";
            buttonDown.Text = "▼";
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
                label1.Visible = true;
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

            if (decimal.TryParse(textBox.Text, out var result))
            {
                Value = Math.Round(result + value, DecimalPlaces);

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
            }

            textBox.Text = Value.ToString();
            return false;
        }

        /// <summary>
        /// Get an image from a string generated by the DumpImageToCode tool.
        /// </summary>
        /// <param name="hexString">The string with hex codes</param>
        /// <returns>An image</returns>
        private Image GetImageFromHexString(string hexString)
        {
            var hexArr = hexString.Split(' ');
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
    }
}
