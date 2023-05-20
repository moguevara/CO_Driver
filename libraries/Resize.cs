using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace CO_Driver
{
    public class Resize
    {
        public class InitialSize
        {
            public string ControlName { get; set; }
            public float InitialFontSize { get; set; }
        }
        public class InitialRecord
        {
            public Size InitialScreenSize { get; set; }
            public List<InitialSize> InitialSizes { get; set; }
        }

        public InitialRecord InitialScreenState = new InitialRecord { };

        public void RecordInitialSizes(UserControl userControl)
        {
            InitialScreenState.InitialSizes = new List<InitialSize> { };
            InitialScreenState.InitialScreenSize = userControl.Size;
            AddInitialSizes(userControl);
        }

        public void AddInitialSizes(Control controls)
        {
            foreach (Control control in controls.Controls)
            {
                if (control is Label)
                    InitialScreenState.InitialSizes.Add(new InitialSize { ControlName = control.Name, InitialFontSize = control.Font.Size });

                if (control is TextBox)
                    InitialScreenState.InitialSizes.Add(new InitialSize { ControlName = control.Name, InitialFontSize = control.Font.Size });

                AddInitialSizes(control);
            }
        }

        public void ResizeUserControl(UserControl UserControl)
        {
            double size_modifier = 1;
            double width_modifier = UserControl.Size.Width / (double)InitialScreenState.InitialScreenSize.Width;
            double height_modifier = UserControl.Size.Height / (double)InitialScreenState.InitialScreenSize.Height;

            if (width_modifier > height_modifier)
                size_modifier = height_modifier;
            else
                size_modifier = width_modifier;

            UpdateFontSizes(UserControl, size_modifier);
        }

        public void UpdateFontSizes(Control controls, double size_modifier)
        {
            foreach (Control control in controls.Controls)
            {
                if (control is Label || control is TextBox)
                {
                    float new_font_size = (float)(InitialScreenState.InitialSizes.FirstOrDefault(x => x.ControlName == control.Name).InitialFontSize * size_modifier);

                    if (new_font_size < 5)
                        new_font_size = 8f;

                    Font new_font = new Font(control.Font.FontFamily, new_font_size, control.Font.Style);
                    Size new_size = TextRenderer.MeasureText(control.Text, new_font);

                    if (new_size.Height < control.Height && new_size.Width < control.Width)
                        control.Font = new Font(control.Font.FontFamily, new_font_size, control.Font.Style);
                }

                UpdateFontSizes(control, size_modifier);
            }
        }

    }
}
