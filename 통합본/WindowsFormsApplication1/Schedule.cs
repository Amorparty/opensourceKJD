using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSE_Core;
using MorphemeParserLib;
using MySql.Data.MySqlClient;


namespace WindowsFormsApplication1
{
    public partial class scheduleform : Form
    {
        // 결과 lv (0 : basic , 1 : 야외활동, 2 : 운동)
        //int lv = 0;

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
            //string ed_time = cb_endtime.Text;
            string st_date = dateEdit1.Text;
            //string ed_date = dateEdit2.Text;


            label8.Text = title.ToString();
            label9.Text = memo.ToString();

            label10.Text = st_time.Replace(":","");
            //label11.Text = ed_time.Replace(":", "");

            label12.Text = st_date.Replace("-", "");
            //label13.Text = ed_date.Replace("-","");
            //DBM.Insert();

            string content = tb_memo.Text;
            List<Morpheme> list = MorphemeParser.Parse(content);
            foreach (Morpheme mo in list)
            {

                label14.Text = "1";
                label15.Text = "2";
                #region
                //mo.Name.Contains("데이트")
                if (mo.Name.Contains("소풍"))
                {
                    
                    MySqlConnection connection = new MySqlConnection("Server=localhost;Database=test2;Uid=root;Pwd=3219");
                    string insertquery = "INSERT INTO my_schedule(title, memo, st_time, ed_time, st_date, ed_date, mykey, place) VALUES" +
                        "('" + label8.Text + "','" + label9.Text + "','" + label10.Text + "','" + label11.Text + "','" + label12.Text + "','" + label13.Text + "','" + label14.Text + "','"+cb_place.Text+"')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertquery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (mo.Name.Contains("여행"))
                {
                    MySqlConnection connection = new MySqlConnection("Server=localhost;Database=test2;Uid=root;Pwd=3219");
                    string insertquery = "INSERT INTO my_schedule(title, memo, st_time, ed_time, st_date, ed_date, mykey, place) VALUES" +
                        "('" + label8.Text + "','" + label9.Text + "','" + label10.Text + "','" + label11.Text + "','" + label12.Text + "','" + label13.Text + "','" + label14.Text + "','" + cb_place.Text + "')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertquery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (mo.Name.Contains("데이트"))
                {
                    MySqlConnection connection = new MySqlConnection("Server=localhost;Database=test2;Uid=root;Pwd=3219");
                    string insertquery = "INSERT INTO my_schedule(title, memo, st_time, ed_time, st_date, ed_date, mykey, place) VALUES" +
                        "('" + label8.Text + "','" + label9.Text + "','" + label10.Text + "','" + label11.Text + "','" + label12.Text + "','" + label13.Text + "','" + label14.Text + "','" + cb_place.Text + "')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertquery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (mo.Name.Contains("나들이"))
                {
                    MySqlConnection connection = new MySqlConnection("Server=localhost;Database=test2;Uid=root;Pwd=3219");
                    string insertquery = "INSERT INTO my_schedule(title, memo, st_time, ed_time, st_date, ed_date, mykey, place) VALUES" +
                        "('" + label8.Text + "','" + label9.Text + "','" + label10.Text + "','" + label11.Text + "','" + label12.Text + "','" + label13.Text + "','" + label14.Text + "','" + cb_place.Text + "')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertquery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (mo.Name.Contains("피크닉"))
                {
                    MySqlConnection connection = new MySqlConnection("Server=localhost;Database=test2;Uid=root;Pwd=3219");
                    string insertquery = "INSERT INTO my_schedule(title, memo, st_time, ed_time, st_date, ed_date, mykey, place) VALUES" +
                        "('" + label8.Text + "','" + label9.Text + "','" + label10.Text + "','" + label11.Text + "','" + label12.Text + "','" + label13.Text + "','" + label14.Text + "','" + cb_place.Text + "')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertquery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (mo.Name.Contains("야외활동"))
                {
                    MySqlConnection connection = new MySqlConnection("Server=localhost;Database=test2;Uid=root;Pwd=3219");
                    string insertquery = "INSERT INTO my_schedule(title, memo, st_time, ed_time, st_date, ed_date, mykey, place) VALUES" +
                        "('" + label8.Text + "','" + label9.Text + "','" + label10.Text + "','" + label11.Text + "','" + label12.Text + "','" + label13.Text + "','" + label14.Text + "','" + cb_place.Text + "')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertquery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (mo.Name.Contains("picnic"))
                {
                    MySqlConnection connection = new MySqlConnection("Server=localhost;Database=test2;Uid=root;Pwd=3219");
                    string insertquery = "INSERT INTO my_schedule(title, memo, st_time, ed_time, st_date, ed_date, mykey, place) VALUES" +
                        "('" + label8.Text + "','" + label9.Text + "','" + label10.Text + "','" + label11.Text + "','" + label12.Text + "','" + label13.Text + "','" + label14.Text + "','" + cb_place.Text + "')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertquery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (mo.Name.Contains("탁구"))
                {
                    MySqlConnection connection = new MySqlConnection("Server=localhost;Database=test2;Uid=root;Pwd=3219");
                    string insertquery = "INSERT INTO my_schedule(title, memo, st_time, ed_time, st_date, ed_date, mykey, place) VALUES" +
                        "('" + label8.Text + "','" + label9.Text + "','" + label10.Text + "','" + label11.Text + "','" + label12.Text + "','" + label13.Text + "','" + label15.Text + "','" + cb_place.Text + "')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertquery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (mo.Name.Contains("축구"))
                {
                    MySqlConnection connection = new MySqlConnection("Server=localhost;Database=test2;Uid=root;Pwd=3219");
                    string insertquery = "INSERT INTO my_schedule(title, memo, st_time, ed_time, st_date, ed_date, mykey, place) VALUES" +
                        "('" + label8.Text + "','" + label9.Text + "','" + label10.Text + "','" + label11.Text + "','" + label12.Text + "','" + label13.Text + "','" + label15.Text + "','" + cb_place.Text + "')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertquery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (mo.Name.Contains("농구"))
                {
                    MySqlConnection connection = new MySqlConnection("Server=localhost;Database=test2;Uid=root;Pwd=3219");
                    string insertquery = "INSERT INTO my_schedule(title, memo, st_time, ed_time, st_date, ed_date, mykey, place) VALUES" +
                        "('" + label8.Text + "','" + label9.Text + "','" + label10.Text + "','" + label11.Text + "','" + label12.Text + "','" + label13.Text + "','" + label15.Text + "','" + cb_place.Text + "')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertquery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (mo.Name.Contains("야구"))
                {
                    MySqlConnection connection = new MySqlConnection("Server=localhost;Database=test2;Uid=root;Pwd=3219");
                    string insertquery = "INSERT INTO my_schedule(title, memo, st_time, ed_time, st_date, ed_date, mykey, place) VALUES" +
                        "('" + label8.Text + "','" + label9.Text + "','" + label10.Text + "','" + label11.Text + "','" + label12.Text + "','" + label13.Text + "','" + label15.Text + "','" + cb_place.Text + "')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertquery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (mo.Name.Contains("헬스"))
                {
                    MySqlConnection connection = new MySqlConnection("Server=localhost;Database=test2;Uid=root;Pwd=3219");
                    string insertquery = "INSERT INTO my_schedule(title, memo, st_time, ed_time, st_date, ed_date, mykey, place) VALUES" +
                        "('" + label8.Text + "','" + label9.Text + "','" + label10.Text + "','" + label11.Text + "','" + label12.Text + "','" + label13.Text + "','" + label15.Text + "','" + cb_place.Text + "')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertquery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (mo.Name.Contains("달리기"))
                {
                    MySqlConnection connection = new MySqlConnection("Server=localhost;Database=test2;Uid=root;Pwd=3219");
                    string insertquery = "INSERT INTO my_schedule(title, memo, st_time, ed_time, st_date, ed_date, mykey, place) VALUES" +
                        "('" + label8.Text + "','" + label9.Text + "','" + label10.Text + "','" + label11.Text + "','" + label12.Text + "','" + label13.Text + "','" + label15.Text + "','" + cb_place.Text + "')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertquery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (mo.Name.Contains("조깅"))
                {
                    MySqlConnection connection = new MySqlConnection("Server=localhost;Database=test2;Uid=root;Pwd=3219");
                    string insertquery = "INSERT INTO my_schedule(title, memo, st_time, ed_time, st_date, ed_date, mykey, place) VALUES" +
                        "('" + label8.Text + "','" + label9.Text + "','" + label10.Text + "','" + label11.Text + "','" + label12.Text + "','" + label13.Text + "','" + label15.Text + "','" + cb_place.Text + "')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertquery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                #endregion



            }

        }

        private void bt_check_Click(object sender, EventArgs e)
        {
            WeatherManager wm = new WeatherManager();
            MySqlConnection connection1 = new MySqlConnection("Server=localhost;Database=test2;Uid=root;Pwd=3219");
            connection1.Open();
            string sql = "SELECT * FROM my_schedule";

            MySqlCommand cmd = new MySqlCommand(sql, connection1);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (rdr["st_date"].Equals(monthCalendar1.SelectionStart.ToShortDateString().Replace("-", ""))) 
                {
                    if(rdr["st_time"].Equals(comboBox1.Text.Replace(":", "")))
                    {
                        tb_date.Text = monthCalendar1.SelectionStart.ToShortDateString().Replace("-", "");
                        textBox3.Text = rdr["memo"].ToString();
                        tb_place.Text = rdr["place"].ToString();

                        
                        List<string> res = wm.manager(tb_place.Text);
                        tb_maxt.Text = res[0];
                        tb_mint.Text = res[1];
                        tb_uncon.Text = res[2];
                        


                        string lv1 = rdr["mykey"].ToString();
                        int lv = Convert.ToInt16(lv1);

                        // WeatherManager wm = new WeatherManager();
                        //textBox4.Text = wm.method(20,0.5);

                        // r = 불쾌지수 정도 ( 1: 조금 더움, 2 : 폭염)
                        int r = 0;
                        r = wm.tembase();

                        //불쾌지수 들어오는지 확인
                        //textBox4.Text = r.ToString();
                        if (r == 1)
                        {
                            //lv 1: 야외 활동 2: 운동
                            if ( lv == 1)
                            {
                                // 선선 외출
                                pictureBox3.Load(@"C: \Users\Peter Kim\Desktop\코디\co5.jpg");
                                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                                tb_expl.Text = " 얇은 긴팔을 준비하세요 ";
                                
                            }
                            else if (lv == 2)
                            {
                                // 선선 운동
                                pictureBox3.Load(@"C: \Users\Peter Kim\Desktop\코디\co2.jpg");
                                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                                tb_expl.Text = " 덥지 않아서 운동하기 좋아요 ";
                            }
                            else
                            {
                                // 선선 캐쥬얼 복장
                                pictureBox3.Load(@"C: \Users\Peter Kim\Desktop\코디\co1.jpg");
                                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                                tb_expl.Text = " 가볍게 입지만 외투를 준비해요 ";
                            }



                        }
                        else if( r==2)
                        {
                            if (lv == 1)
                            {
                                // 더워 외출
                                pictureBox3.Load(@"C: \Users\Peter Kim\Desktop\코디\co3.jpg");
                                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                                tb_expl.Text = " 반팔 반바지를 준비하세요 ";
                            }
                            else if (lv == 2)
                            {
                                // 더워 운동
                                pictureBox3.Load(@"C: \Users\Peter Kim\Desktop\코디\co6.jpg");
                                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                                tb_expl.Text = " 기능성 운동복이나 반팔 운동복 ";
                            }
                            else
                            {
                                // 더워 캐쥬얼 복장
                                pictureBox3.Load(@"C: \Users\Peter Kim\Desktop\코디\co4.jpg");
                                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                                tb_expl.Text = " 반팔 반바지를 준비하세요";
                            }
                        }
                        else
                        {

                            
                            pictureBox3.Load(@"C: \Users\Peter Kim\Desktop\코디\co5.jpg");
                            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                            tb_expl.Text = " 얇은 긴팔 긴바지를 준비하세요 ";


                        }
                        //lv 값 default
                        lv = 0;
                        r = 0;

                    }

                }
                
            }
        }
    }
}
