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
    /// Note: the Directory.Build.props file is used for versioning in .NET Core and is not needed for .NET 4.8. 
    /// Also see: https://www.codeproject.com/Tips/1231820/NET-Core-Versioning-Demystified
    /// </summary>
    public class CustomUpDown : Control
    {
        public event EventHandler? ValueChanged;

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

        public enum ButtonDisplay { Arrows, PlusMinus, PlusMinus2, PlusMinus3 };

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
                    buttonUp.BackgroundImage = emptyIcon;
                    buttonDown.BackgroundImage = emptyIcon;
                }
                else if (buttonstyle == ButtonDisplay.PlusMinus2)
                {
                    // Buttons with icons
                    if (plus2Icon == null)
                    {
                        plus2Icon = GetImageFromHexString(plus2IconCode);
                    }

                    if (minus2Icon == null)
                    {
                        minus2Icon = GetImageFromHexString(minus2IconCode);
                    }

                    buttonUp.Text = "";
                    buttonDown.Text = "";
                    buttonUp.BackgroundImage = plus2Icon;
                    buttonUp.BackgroundImageLayout = ImageLayout.Zoom;
                    buttonDown.BackgroundImage = minus2Icon;
                    buttonDown.BackgroundImageLayout = ImageLayout.Zoom;
                }
                else if (buttonstyle == ButtonDisplay.PlusMinus3)
                {
                    // Buttons with icons
                    if (plus3Icon == null)
                    {
                        plus3Icon = GetImageFromHexString(plus3IconCode);
                    }

                    if (minus3Icon == null)
                    {
                        minus3Icon = GetImageFromHexString(minus3IconCode);
                    }

                    buttonUp.Text = "";
                    buttonDown.Text = "";
                    buttonUp.BackgroundImage = plus3Icon;
                    buttonUp.BackgroundImageLayout = ImageLayout.Zoom;
                    buttonDown.BackgroundImage = minus3Icon;
                    buttonDown.BackgroundImageLayout = ImageLayout.Zoom;
                }
                else
                {
                    // Standard Arrow buttons
                    buttonUp.Text = "▲";
                    buttonDown.Text = "▼";
                    buttonUp.BackgroundImage = emptyIcon;
                    buttonDown.BackgroundImage = emptyIcon;
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
        /// An empty Image (used when switching to a text style button)
        /// </summary>
        private Image? emptyIcon;

        /// <summary>
        /// Code for plus2 icon generated by DumpImageToCode tool
        /// </summary>
        private string plus2IconCode = "89 50 4E 47 0D 0A 1A 0A 00 00 00 0D 49 48 44 52 00 00 00 1A 00 00 00 1A 08 06 00 00 00 A9 4A 4C CE 00 00 00 01 73 52 47 42 00 AE CE 1C E9 00 00 00 04 67 41 4D 41 00 00 B1 8F 0B FC 61 05 00 00 00 09 70 48 59 73 00 00 0E C3 00 00 0E C3 01 C7 6F A8 64 00 00 00 58 49 44 41 54 48 4B ED 93 51 0A 00 21 08 44 BD FF C5 6A F7 52 E5 C2 06 11 1A 31 62 5F F3 E0 FD 88 3A 5F 23 E4 16 AF DA 7E EB 37 C8 62 84 0C D3 60 10 0C 83 5C E6 9E 44 DD F6 CC 3A 88 E8 62 2D 47 74 79 54 EB 00 B1 A8 30 EB B3 34 18 04 C3 20 98 B9 67 A1 9E 90 43 44 3A 27 6F 8D BD 18 59 7F D5 00 00 00 00 49 45 4E 44 AE 42 60 82";

        private Image? plus2Icon;

        /// <summary>
        /// Code for minus2 icon generated by DumpImageToCode tool
        /// </summary>
        private string minus2IconCode = "89 50 4E 47 0D 0A 1A 0A 00 00 00 0D 49 48 44 52 00 00 00 1A 00 00 00 1A 08 06 00 00 00 A9 4A 4C CE 00 00 00 01 73 52 47 42 00 AE CE 1C E9 00 00 00 04 67 41 4D 41 00 00 B1 8F 0B FC 61 05 00 00 00 09 70 48 59 73 00 00 0E C3 00 00 0E C3 01 C7 6F A8 64 00 00 00 38 49 44 41 54 48 4B ED CB BB 0D 00 20 0C 03 D1 EC BF 18 9F A5 C0 03 38 0D 41 82 E2 9E 74 9D 1D 00 F0 8F A9 D6 A5 BA 4A B9 43 A5 94 1B 57 4A 0D E5 0E 27 35 05 00 EF 45 6C 09 E6 4E D7 AD BA 2E B0 00 00 00 00 49 45 4E 44 AE 42 60 82";

        private Image? minus2Icon;

        /// <summary>
        /// Code for plus3 icon generated by DumpImageToCode tool
        /// </summary>
        private string plus3IconCode = "89 50 4E 47 0D 0A 1A 0A 00 00 00 0D 49 48 44 52 00 00 00 28 00 00 00 28 08 06 00 00 00 8C FE B8 6D 00 00 00 01 73 52 47 42 00 AE CE 1C E9 00 00 00 04 67 41 4D 41 00 00 B1 8F 0B FC 61 05 00 00 00 09 70 48 59 73 00 00 0E C3 00 00 0E C3 01 C7 6F A8 64 00 00 03 4B 49 44 41 54 58 47 ED 58 4D 6B DB 40 10 9D 9A D0 53 29 A5 84 D0 43 7E 41 E9 A9 07 53 7A 31 04 1F 7A F2 A1 C4 21 B6 64 FB 50 28 A5 90 D6 92 56 3E D6 35 39 04 D3 3F DD 79 33 3B D6 07 AA 22 3B 32 A8 E0 07 83 E4 DD 99 37 E3 9D D9 0F 2D 9D 70 C2 7F 86 9E 7F D2 98 BE BF 98 50 D4 0F 28 0A E7 E4 DC 8C E2 FB 39 25 5B 88 BE 3B 37 97 BE A8 0F 5D 6F 06 EC 38 DA 04 48 85 38 A4 E4 22 A0 E5 0D 07 B0 59 50 FA A7 89 40 37 A0 E4 06 B6 E0 60 EC F8 DA 80 10 0D 68 7D 16 50 3C 9A 53 BA CD 1C A7 DB 90 62 17 52 74 3B A5 E5 90 DF 3F 42 F0 CE 23 C9 01 C5 3C 8A 45 7D 70 BC A5 F1 73 61 6E 21 48 21 98 50 7C 0E 67 E6 68 46 8E 53 18 8F 16 E4 DE 88 56 0D A0 83 A0 60 93 05 1A 3B 70 7A 95 83 83 14 C3 80 EE 2E F3 E9 44 5D 71 DB 4B D1 F0 58 D3 BA 87 11 1E D0 C0 CB FA 0C 6D BE 5B 00 1B D4 6B C6 83 B4 AF 2E 7D F7 DE 41 8A 41 48 DF 2E 66 CF 92 DF 4A 88 F4 44 1F A4 57 01 9D 26 C4 05 3D 70 58 DA C1 5D AA CB E6 18 73 9D F0 6C 8C 35 B8 84 6B 2D 79 87 76 3F 32 05 B2 09 7D 3D 67 9D EB BC A0 CD 77 1B 7A 36 AA E0 02 A7 04 C9 3E E0 4B 34 1A 42 48 50 37 20 80 D8 C8 21 7D 78 66 50 87 E8 D7 3F 92 F2 32 A3 A3 93 8D 76 31 D5 C6 61 36 AA 1B 8F A4 B3 E9 28 A2 B0 D9 D1 03 8C B9 B8 A7 DA 5A 74 E4 51 0E F0 C1 EC B2 00 AB 9C 2A D7 8C A2 A9 D9 35 99 70 3B 20 45 6A E8 36 D7 F4 E5 B5 6F AE C0 FE 23 98 07 B8 6D 02 C2 A7 6F AE 07 66 DB 82 92 5F EA E4 B1 A1 7F 52 80 DE 56 4B 09 13 A6 BC 3A 54 02 DB 97 18 50 C2 4E EE 4A CB 80 38 63 C1 13 4B 8B D6 13 16 E7 72 80 68 43 9F EA A8 7E 66 2B 90 27 7C C0 97 DA 47 7D E9 A9 03 6A 4E 03 74 B1 6F AA 81 3A 3B 34 C5 06 F8 F2 3E 7D BD D7 00 AB 3C 94 79 29 B8 D5 16 75 80 65 03 A3 02 C7 26 FA 7B F9 3E FB 53 89 88 39 43 5F 95 4D B6 8B 28 37 B6 4A D8 70 3D 3A 69 AE 83 15 2D 3B 18 E2 37 76 05 3C D9 F1 67 25 D1 11 3A 44 CC 16 5C 45 EE E5 50 FB DD 06 BF 6B C1 C6 15 35 94 9F D9 B2 94 48 2A 4D 6C D4 F2 82 B6 B2 1E 8B 2C 41 36 63 CB 35 0C DF F8 5D 8B CE 07 D8 F9 14 FF 7B 92 C8 91 AB 62 92 A4 35 93 24 6D 7F 92 64 CE 3A BB CC 74 7C A1 C6 76 C3 CA DD DD EA 80 6C C6 1E F7 B0 B0 A0 9F AF 6C 52 DA CC 6E 84 E2 71 2B EA DC 71 CB 3B ED F0 81 15 D8 F7 C8 AF DF CA 7A DC C7 7B EE AB CD 90 3B F2 FF 78 D2 91 1F F0 44 49 EB 1F 4D 73 5A F5 77 C1 31 37 7C F8 AE 26 5C 05 88 01 3E 0D AD 90 21 1C 64 27 3E 3B 0D 62 88 74 D9 0E 03 E1 05 F5 5E 6B 74 9F 0F F7 38 F7 E1 EE 5A F9 70 37 08 01 AE 2B E0 C8 26 81 3A D2 AB 0F 4E 19 EE 5D AE 16 52 F8 D8 CE 92 2B B4 61 87 28 EB 83 A3 CD AB 0F 03 88 84 0C 35 83 8B A0 7C DA 1F 13 4D E7 F1 2E 8F F2 D8 91 E2 4A 0D 5B 13 AE 42 78 14 57 48 3B 8A 1F 82 77 B4 71 60 72 FD F6 89 82 7C CD 1E 25 B0 13 4E 38 0E 88 FE 02 F6 44 9F 27 3E C7 F6 74 00 00 00 00 49 45 4E 44 AE 42 60 82";

        private Image? plus3Icon;

        /// <summary>
        /// Code for minus3 icon generated by DumpImageToCode tool
        /// </summary>
        private string minus3IconCode = "89 50 4E 47 0D 0A 1A 0A 00 00 00 0D 49 48 44 52 00 00 00 28 00 00 00 28 08 06 00 00 00 8C FE B8 6D 00 00 00 01 73 52 47 42 00 AE CE 1C E9 00 00 00 04 67 41 4D 41 00 00 B1 8F 0B FC 61 05 00 00 00 09 70 48 59 73 00 00 0E C3 00 00 0E C3 01 C7 6F A8 64 00 00 03 03 49 44 41 54 58 47 ED 98 4D 6B DB 40 10 86 A7 21 F4 54 4A 29 25 F4 90 5F 50 72 36 25 97 40 C8 A1 27 1F 4A 1C 92 F8 EB 50 28 A5 90 D6 92 D6 3E D6 35 39 04 D3 3F DD 79 66 77 2D CB 49 14 C5 96 A9 0A 7E 61 90 B4 9A 7D 67 76 77 66 47 5A D9 61 87 FF 0C 7B E1 2A 1D F9 FE EA 4A 92 56 57 92 DE 40 9C EB 4B 7A 3B 90 6C 8E F8 7B E7 06 F6 2E 69 A1 1B BA 81 05 47 9D 80 D4 88 7B 92 1D 74 65 74 A1 0E CC 86 32 FE 53 45 D0 ED 4A 76 41 5F 38 14 0B BE 3A 60 44 27 32 DD EF 4A DA 1E C8 78 9E 1B 1E CF 7B 92 BA 9E 24 97 D7 32 3A D3 FB 63 84 7B 9D 49 75 28 D5 59 2C EA C3 F1 41 3A 2F 8D B9 06 27 8D E0 4A D2 77 18 8B 86 FA E2 74 09 D3 F6 50 DC 7B D3 2A 01 3A 38 45 9F DC D1 D4 C1 19 54 D6 76 D2 3A 76 E5 E6 70 79 39 89 2B 6D 7B 6D 1A 39 54 77 BA 22 45 C3 F4 21 5E 73 1E 96 7D 72 18 5E 17 74 AB C0 3A F4 E4 DB 41 FF 45 F6 DB 13 B2 3C C9 47 7B EB 71 CF 89 47 50 D0 83 23 2E 3B DC 2B 71 59 1D 1D 8D 13 CD C6 D4 3B 97 69 AC 65 47 B4 4F 1F 98 9D 8A D8 0B 7D 49 B4 23 38 CD 49 B5 81 2D D3 A8 08 23 21 6E 20 40 E2 CC 9D C8 C9 3E D7 4D 10 39 E0 CC F9 D3 B6 BD AC 3A 70 02 5B 97 E1 CE 8F D0 5D FB 56 3F FA 7A E0 B9 FA 92 5C 63 C3 DB 7A 3A E1 16 D0 E9 3F F7 1D DD EC 5C BE BC 0D CD B5 03 EE 98 80 D8 0C CD E5 20 DB 86 92 FD 5A 6B EA 9F 87 42 28 91 30 0F EC 0E F7 41 F9 B2 0E 92 A9 83 37 2B DB 40 4C 10 AE EB 48 EC 6B B0 2B 36 B0 E5 67 31 69 D9 9B 32 10 73 DE 41 97 86 A6 AD 03 5B C1 66 88 F7 12 B0 CB A3 AC 5B C1 A5 6F F1 23 BE 92 AF 54 93 63 B2 6F 13 81 23 AF 22 9E 9B 52 E9 67 D0 39 6B 2E 43 0C 5A 1D CD 19 CF D4 60 AE BA 0C 9F 3D 49 5E 5B 9F 2B 8B 0D 5A B9 8A DC A3 33 FF DE CD 78 2E 85 76 36 12 46 CA 73 DC B7 F2 CC 1E DF 61 68 4D B1 AD 2B 66 6C E4 C6 56 70 7C CE 73 29 1A EF 60 E3 97 F8 F1 24 B1 4F AE 7F 9F 24 A4 BA 1F 65 63 B7 99 86 6F D4 94 1B 55 6E 6E A9 03 79 C6 6E F7 63 61 28 3F DF C4 A4 8C 99 5D 09 C5 CF AD A4 71 9F 5B 85 A9 47 C8 3E DA E2 BE B5 09 22 07 9C 39 FF 1A A1 B4 DD 4F FE 1F 1B 7D F2 83 40 94 D5 FE D3 34 90 49 6B E1 9C 72 63 23 BC AA C2 55 80 75 E0 D7 30 06 32 A2 4E 36 E2 B7 33 C2 3A B2 F3 C7 0A 83 E8 86 7A EB 63 F4 39 3F EE E9 D2 8F BB AB E5 C7 3D C2 08 38 AE C0 D0 72 2D E6 5E 4B 97 D3 25 E3 DC E5 74 68 81 4F 39 CB 4E 69 A3 42 AC EA C3 51 E7 D1 47 04 44 46 46 CC 70 10 B4 BC EC 4F 89 5F CE ED 1D 1E 2D 63 41 CA 91 1A A5 89 A3 10 9D C5 09 CB 4E F0 23 DC D3 A6 8E D9 F1 DB 27 E9 2E C7 EC 56 1C DB 61 87 ED 40 E4 2F CA D3 30 3D C3 2A 06 23 00 00 00 00 49 45 4E 44 AE 42 60 82";

        private Image? minus3Icon;

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
            emptyIcon = null;
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
        private void TextBox_KeyPress(object? sender, KeyPressEventArgs e)
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
        private void ButtonUpClick(object? sender, MouseEventArgs e)
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
        private void ButtonDownClick(object? sender, MouseEventArgs e)
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
