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
    public partial class login : Form
    {
        DBmanager DBM = DBmanager.GetInstance();
        public login()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        // 나가기 버튼 눌렀을때 메모리 해제 시키고 프로그램 종료시키기
        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }

        // 로그인 성공하면 다음 메뉴 탭으로 넘어가기
        private void login_button_Click(object sender, EventArgs e)
        {
            // id, pw 입력 
            string id = id_tb.Text.ToString();
            string pw = pw_tb.Text.ToString();

            if (id == string.Empty || pw == string.Empty)
            {
                MessageBox.Show("ID와 PW를 입력해주세요");
                return;
            }

            // 아이디 패스워드 조회
            int result = DBM.Login(id,pw);

            // 0:에러 1:성공 2:PW X 3:ID X
            switch (result)
            {
                case 0: MessageBox.Show("접속에러 관리자에게 문의하세요"); return;
                case 1: break;
                case 2: MessageBox.Show("PW가 틀립니다."); return;
                case 3: MessageBox.Show("ID가 틀립니다."); return;
            }




            menuform mf = new menuform();
            mf.Show();
            this.Hide();
        }

        private void join_Click(object sender, EventArgs e)
        {
            Hide();
            AddMemberForm addmemberform = new AddMemberForm();
            addmemberform.ShowDialog();
            Close();
        }
    }
}
