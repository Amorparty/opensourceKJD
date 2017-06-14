using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class scheduleform : Form
    {
        DBmanager DBM = DBmanager.GetInstance();
        public scheduleform()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void scheduleform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 시작시간 종료시간 저장, 제목, 일정 저장
            string title = tb_title.Text;
            string memo = tb_memo.Text ;
            string st_time = cb_starttime.Text ;
            string ed_time = cb_endtime.Text;
            string st_date = dateEdit1.Text;
            string ed_date = dateEdit2.Text;


            label8.Text = title.ToString();
            label9.Text = memo.ToString();

            label10.Text = st_time.Replace(":","");
            label11.Text = ed_time.Replace(":", "");

            label12.Text = st_date.Replace("-", "");
            label13.Text = ed_date.Replace("-","");
            //string st_date = ;
            //string ed_date = ;
            //DBM.Schedule()
        }
    }
}
