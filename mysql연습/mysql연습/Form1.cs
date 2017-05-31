using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace mysql연습
{
    public delegate void EventHandler(string userName);
    

    public partial class Form1 : Form
    {
        public event EventHandler loginEventHandler;

       
        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            LoginHandler loginHandler = new LoginHandler();
            if (ControlCheck())
            {
                if (loginHandler.LoginCheck(textBox1.Text, textBox2.Text))
                {
                    string userName = loginHandler.GetUserName(textBox1.Text);
                    MessageBox.Show("로그인 성공", "알림", MessageBoxButtons.OK);
                    //loginEventHandler(userName);
                    DialogResult = DialogResult.OK;
                    MainForm mainform = new MainForm();

                    this.Hide();
                    mainform.Show();
                    

                }
                else
                {
                    MessageBox.Show("로그인 정보가 정확하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            
            
        }
        private bool ControlCheck()
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("아이디와 비밀번호를 입력해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("비밀번호를 입력해 주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
