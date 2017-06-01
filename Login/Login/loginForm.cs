using System;
using System.Windows.Forms;

namespace Login
{
    public partial class loginForm : Form
    {
        DBManager DBM = DBManager.GetInstance();
        public loginForm()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            // 회원가입창 이동
            Hide();  
            AddMemberForm addmemberform = new AddMemberForm();
            addmemberform.ShowDialog();
            Close();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            // ID PW 입력
            string id = tb_id.Text.ToString();
            string pw = tb_pw.Text.ToString();

            if (id == string.Empty || pw == string.Empty)
            {
                MessageBox.Show("ID와 PW 를 입력해주세요.");
                return;
            }

            // ID PW DB 조회 
            int result = DBM.Login(id, pw);

            // 0:에러 1:성공 2:PW X 3:ID X
            switch (result)
            {
                case 0: MessageBox.Show("접속에러 관리자에게 문의하세요"); return;
                case 1: break;
                case 2: MessageBox.Show("PW가 틀립니다."); return;
                case 3: MessageBox.Show("ID가 틀립니다."); return;
            }            

            // 메인 창 이동 
            Hide();
            MainForm mainform = new MainForm();
            mainform.ShowDialog();
            Close();
        }
    }
}
