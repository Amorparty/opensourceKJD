using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysql연습
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (monthCalendar1.SelectionRange.Start == monthCalendar1.SelectionRange.End)
            {
                textBox1.Text = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            }
            else
            {
                textBox1.Text = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                
            }
        }
    }
}
