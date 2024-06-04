using Microsoft.VisualBasic;
using System.Data.Common;
using System.Drawing.Design;
using System.Drawing.Drawing2D;

namespace _4_in_a_row
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int i = 0;
        int a = 0;
        int lowest = 0;
        int row = 0;
        int column = 0;
        int coloredred = 0;
        int coloredyellow = 0;

        List<Button> button1 = new List<Button>();
        List<Button> button2 = new List<Button>();
        List<Button> button3 = new List<Button>();
        List<Button> button4 = new List<Button>();
        List<Button> button5 = new List<Button>();
        List<Button> button6 = new List<Button>();

        void butt1()
        {
            Button button = new Button();
            button.BackColor = Color.Gray;
            button.Size = new Size(100, 100);
            button.Location = new Point(12, 12 + (106 * a));
            button.Name = "button1:" + a.ToString();
            Controls.Add(button);
            button1.Add(button);
            button.MouseHover += button_MouseEnter;
            button.MouseLeave += button_MouseLeave;
            button.Click += button_Click;
        }

        void butt2()
        {
            Button button = new Button();
            button.BackColor = Color.Gray;
            button.Size = new Size(100, 100);
            button.Location = new Point(118, 12 + (106 * a));
            button.Name = "button2:" + a.ToString();
            Controls.Add(button);
            button2.Add(button);
            button.MouseHover += button_MouseEnter;
            button.MouseLeave += button_MouseLeave;
            button.Click += button_Click;
        }

        void butt3()
        {
            Button button = new Button();
            button.BackColor = Color.Gray;
            button.Size = new Size(100, 100);
            button.Location = new Point(224, 12 + (106 * a));
            button.Name = "button3:" + a.ToString();
            Controls.Add(button);
            button3.Add(button);
            button.MouseHover += button_MouseEnter;
            button.MouseLeave += button_MouseLeave;
            button.Click += button_Click;
        }

        void butt4()
        {
            Button button = new Button();
            button.BackColor = Color.Gray;
            button.Size = new Size(100, 100);
            button.Location = new Point(330, 12 + (106 * a));
            button.Name = "button4:" + a.ToString();
            Controls.Add(button);
            button4.Add(button);
            button.MouseHover += button_MouseEnter;
            button.MouseLeave += button_MouseLeave;
            button.Click += button_Click;
        }

        void butt5()
        {
            Button button = new Button();
            button.BackColor = Color.Gray;
            button.Size = new Size(100, 100);
            button.Location = new Point(436, 12 + (106 * a));
            button.Name = "button5:" + a.ToString();
            Controls.Add(button);
            button5.Add(button);
            button.MouseHover += button_MouseEnter;
            button.MouseLeave += button_MouseLeave;
            button.Click += button_Click;
        }

        void butt6()
        {
            Button button = new Button();
            button.BackColor = Color.Gray;
            button.Size = new Size(100, 100);
            button.Location = new Point(542, 12 + (106 * a));
            button.Name = "button6:" + a.ToString();
            Controls.Add(button);
            button6.Add(button);
            button.MouseHover += button_MouseEnter;
            button.MouseLeave += button_MouseLeave;
            button.Click += button_Click;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                butt1();
                butt2();
                butt3();
                butt4();
                butt5();
                butt6();
                a++;
            }
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Control button = sender as Control;
            string[] data = button.Name.Substring(6).Split(':');
            int.TryParse(data[0], out column);
            int.TryParse(data[1], out row);

            lowest = row;

            for (int i = row; i <= 5; i++)
            {
                if (Controls[$"button{column}:{i}"].BackColor == Color.Red)
                {
                    return;
                }
                else if (Controls[$"button{column}:{i}"].BackColor == Color.Yellow)
                {
                    return;
                }
                Controls[$"button{column}:{i}"].BackColor = Color.LightGray;
                lowest = i;
            }
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            Control button = sender as Control;
            foreach (Control ctl in Controls)
            {
                if (ctl.BackColor == Color.Red)
                {
                    continue;
                }
                if (ctl.BackColor == Color.Yellow)
                {
                    continue;
                }
                ctl.BackColor = Color.Gray;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                Controls[$"button{column}:{lowest}"].BackColor = Color.Red;
                i = 0;
            }
            else if (i == 0)
            {
                Controls[$"button{column}:{lowest}"].BackColor = Color.Yellow;
                i = 1;
            }
            button_MouseLeave(sender, e);
            button_MouseEnter(sender, e);

            Control button = sender as Control;
            string[] data = button.Name.Substring(6).Split(':');
            int.TryParse(data[0], out column);
            int.TryParse(data[1], out row);

            lowest = row;

            for (int i = row; i <= 5; i++)
            {
                if (Controls[$"button{column}:{i}"].BackColor == Color.Red)
                {
                    return;
                }
                else if (Controls[$"button{column}:{i}"].BackColor == Color.Yellow)
                {
                    return;
                }
                Controls[$"button{column}:{i}"].BackColor = Color.LightGray;
                lowest = i;
            }

            for (int i = 1; i <= 6; i++)
            {
                if (coloredred == 4 || coloredyellow == 4)
                {
                    break;
                }
                if (Controls[$"button{i}:{column}"].BackColor == Color.Red)
                {
                    coloredred++;
                    return;
                }
                else if (Controls[$"button{i}:{column}"].BackColor == Color.Yellow)
                {
                    coloredyellow++;
                }
            }

            if (coloredred != 4 || coloredyellow != 4)
            {
                coloredred = 0;
                coloredyellow = 0;

                for (int i = 0; i <= 5; i++)
                {
                    if (coloredred == 4 || coloredyellow == 4)
                    {
                        break;
                    }
                    if (Controls[$"button{row}:{i}"].BackColor == Color.Red)
                    {
                        coloredred++;
                        return;
                    }
                    else if (Controls[$"button{row}:{i}"].BackColor == Color.Yellow)
                    {
                        coloredyellow++;
                    }
                }
            }

            if (coloredred == 4)
            {
                MessageBox.Show("Red Wins!");
                coloredred = 0;
            }
            else if (coloredyellow == 4)
            {
                MessageBox.Show("Yellow Wins!");
                coloredyellow = 0;
            }
        }
    }
}