using System;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
{
    public partial class AddMemberForm : Form
    {
        DBmanager DBM = DBmanager.GetInstance();
        bool idcheck;
        public AddMemberForm()
        {
            InitializeComponent();
            idcheck = false;
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            string id = tb_id.Text.ToString();
            if (id == string.Empty)
            {
                MessageBox.Show("ID를 입력해주세요");
                return;
            }

            bool result = DBM.IDCheckDB(id);

            if (result== false)
            {
                MessageBox.Show("사용중인 ID입니다.");
                return;
            }

            MessageBox.Show("사용가능한 ID입니다.");
            idcheck = true;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string id = tb_id.Text.ToString();
            string pw = tb_pw.Text.ToString();
            string pw2 = tb_pw2.Text.ToString();
            string name = tb_name.Text.ToString();
            string age = tb_age.Text.ToString();
            string address = comboBox1.Text.ToString();
            string sex = tb_sex.Text.ToString();

            if (id == string.Empty || pw == string.Empty || pw2== string.Empty)
            {
                MessageBox.Show("빈칸 없이 입력해주세요.");
                return;
            }

            //pw pw 2 확인
            if (pw != pw2)
            {
                MessageBox.Show("PW와 PW확인이 다름니다.");
                return;
            }
            // id 중복체크 확인 
            if (idcheck == false)
            {
                MessageBox.Show("ID 중복체크를 해주세요.");
                return;
            }

            bool result = DBM.AddMember(id, pw, name, age, sex, address);

            if (result == false)
            {
                MessageBox.Show("가입에 실패하였습니다.\n 관리자게에 문의하세요.");
                return;
            }



            // 로그인폼 이동
            Hide();
            login loginfrom = new login();
            loginfrom.ShowDialog();
            Close();

        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            // 로그인폼 이동
            Hide();
            login loginfrom = new login();
            loginfrom.ShowDialog();
            Close();
        }

       
    }
}
