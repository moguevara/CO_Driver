using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace CO_Driver
{
    public class Resize
    {
        public class initial_size
        {
            public string control_name { get; set; }
            public float initial_font_size { get; set; }
        }
        public class initial_record
        {
            public Size initial_screen_size { get; set; }
            public List<initial_size> initial_sizes { get; set; }
        }

        public initial_record initial_screen_state = new initial_record { };

        public void record_initial_sizes(UserControl user_control)
        {
            initial_screen_state.initial_sizes = new List<initial_size> { };
            initial_screen_state.initial_screen_size = user_control.Size;
            add_initial_sizes(user_control);
        }

        public void add_initial_sizes(Control controls)
        {
            foreach (Control control in controls.Controls)
            {
                if (control is Label)
                    initial_screen_state.initial_sizes.Add(new initial_size { control_name = control.Name, initial_font_size = control.Font.Size });

                if (control is TextBox)
                    initial_screen_state.initial_sizes.Add(new initial_size { control_name = control.Name, initial_font_size = control.Font.Size });

                add_initial_sizes(control);
            }
        }

        public void resize(UserControl user_control)
        {
            double size_modifier = 1;
            double width_modifier = (double)user_control.Size.Width / (double)initial_screen_state.initial_screen_size.Width;
            double height_modifier = (double)user_control.Size.Height / (double)initial_screen_state.initial_screen_size.Height;

            if (width_modifier > height_modifier)
                size_modifier = height_modifier;
            else
                size_modifier = width_modifier;

            update_font_sizes(user_control, size_modifier);
        }

        public void update_font_sizes(Control controls, double size_modifier)
        {
            foreach (Control control in controls.Controls)
            {
                if (control is Label || control is TextBox)
                {
                    float new_font_size = (float)(initial_screen_state.initial_sizes.FirstOrDefault(x => x.control_name == control.Name).initial_font_size * size_modifier);

                    if (new_font_size < 5)
                        new_font_size = 8f;

                    Font new_font = new Font(control.Font.FontFamily, new_font_size, control.Font.Style);
                    Size new_size = TextRenderer.MeasureText(control.Text, new_font);

                    if (new_size.Height < control.Height && new_size.Width < control.Width)
                        control.Font = new Font(control.Font.FontFamily, new_font_size, control.Font.Style);
                }

                update_font_sizes(control, size_modifier);
            }
        }

    }
}
