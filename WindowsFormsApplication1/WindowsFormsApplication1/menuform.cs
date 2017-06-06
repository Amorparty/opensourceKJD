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
    public partial class menuform : Form
    {
        public menuform()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        // 뒤로가기 모양 눌렀을때 로그인창으로 돌아가기
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            login loginform = new login();
            this.Hide();
            loginform.ShowDialog();
            
        }
        // 닫기 눌렀을때 메모리 해제 (프로그램 끄기)
        private void formclosing1(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }

        // 클릭시 스케쥴 창으로 넘어감
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            scheduleform sf = new scheduleform();
            this.Hide();
            sf.ShowDialog();
            
        }
    }
}
