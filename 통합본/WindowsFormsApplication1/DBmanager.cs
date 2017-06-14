using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    class DBmanager
    {
        #region 싱글톤 
        static DBmanager dbm;
        protected DBmanager() { }
        public static DBmanager GetInstance()
        {
            if (dbm == null)
            {
                dbm = new DBmanager();
            }
            return dbm;
        }
        #endregion

        #region DB 연결
        //DB 서버 주소 연결        
       //민상 static string connStr = @"Server=localhost;Database=test;Uid=root;Pwd=enqn132";
        static string connStr = @"Server=localhost;Database=test2;Uid=root;Pwd=3219";
        MySqlConnection scon = new MySqlConnection(connStr); // DB 연결
        #endregion

        //회원가입
        #region ID 중복검사 
        internal bool IDCheckDB(string id)
        {
            string sql = "SELECT * FROM login";
            using (MySqlCommand scom = new MySqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (MySqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return false;
                    }
                    while (reader.Read())
                    {
                        if (reader["user_id"].Equals(id))
                        {
                            scom.Connection.Close();
                            return false;
                        }
                    }
                    scom.Connection.Close();
                    return true;
                }
            }
        }
        #endregion              
        #region 회원 가입 
        internal bool AddMember(string id, string pw, string name, string age, string sex, string address)
        {
            string sql = "INSERT INTO login(user_id, user_password, user_name, user_age, user_sex, user_address) VALUES(@user_id, @user_password, @user_name, @user_age, @user_sex, @user_address)";

            using (MySqlCommand scom = new MySqlCommand(sql, scon))
            {
                MySqlParameter sp_id = new MySqlParameter("@user_id", id);
                MySqlParameter sp_pw = new MySqlParameter("@user_password", pw);
                MySqlParameter sp_name = new MySqlParameter("@user_name", name);
                MySqlParameter sp_age = new MySqlParameter("@user_age", age);
                MySqlParameter sp_sex = new MySqlParameter("@user_sex", sex);
                MySqlParameter sp_address = new MySqlParameter("@user_address", address);

                scom.Parameters.Add(sp_id);
                scom.Parameters.Add(sp_pw);
                scom.Parameters.Add(sp_name);
                scom.Parameters.Add(sp_age);
                scom.Parameters.Add(sp_sex);
                scom.Parameters.Add(sp_address);

                scom.Connection.Open();
                int re = scom.ExecuteNonQuery();
                scom.Connection.Close();
                if (re >= 1)
                {
                    if (re == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
        //저장
        #region 저장
        internal void Schedule(string title, string memo, string st_time, string ed_time, string st_date, string ed_date, int checknum=1)
        {
            // 시작시간 종료시간 저장, 제목, 일정 저장
            string sql = "INSERT INTO member(title, memo, st_time, ed_time, st_date, ed_date, checknum)) VALUES(@title, @memo, @st_time, @ed_time, @st_date, @ed_date, @checknum)";

            using (MySqlCommand scom = new MySqlCommand(sql, scon))
            {
                MySqlParameter sp_title = new MySqlParameter("@title", title);
                MySqlParameter sp_memo = new MySqlParameter("@memo", memo);
                MySqlParameter sp_st_time = new MySqlParameter("@st_time", st_time);
                MySqlParameter sp_ed_time = new MySqlParameter("@ed_time", ed_time);
                MySqlParameter sp_st_date = new MySqlParameter("@st_date", st_date);
                MySqlParameter sp_ed_date = new MySqlParameter("@ed_date", ed_date);
                MySqlParameter sp_checknum = new MySqlParameter("@checknum", checknum);

                scom.Parameters.Add(sp_title);
                scom.Parameters.Add(sp_memo);
                scom.Parameters.Add(sp_st_time);
                scom.Parameters.Add(sp_ed_time);
                scom.Parameters.Add(sp_st_date);
                scom.Parameters.Add(sp_ed_date);
                scom.Parameters.Add(sp_checknum);

                scom.Connection.Open();
                int re = scom.ExecuteNonQuery();
                scom.Connection.Close();
           
            }
        }
        #endregion

        public void Insert()
        {
            try
            {
                scon.Open();
                string sql1 = "INSER INTO login(user_id) VALUES(@user_id)";
                MySqlCommand cmd = new MySqlCommand(sql1, scon);

                cmd.Parameters.AddWithValue("@user_id", "peter123");
                //cmd.Parameters.AddWithValue("@memo", "소풍");
                //cmd.Parameters.AddWithValue("@checknum", "1");
                if (cmd.ExecuteNonQuery() == 1)
                {
                    
                }
                
                scon.Clone();
            }
            catch
            {
                
            }
        }
        //로그인
        #region 로그인        
        internal int Login(string id, string pw)
        {

            string sql = "SELECT * FROM login";
            using (MySqlCommand scom = new MySqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (MySqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return 0; // 에러
                    }
                    while (reader.Read())
                    {
                        if (reader["user_id"].Equals(id))
                        {
                            if (reader["user_password"].Equals(pw))
                            {
                                scom.Connection.Close();
                                return 1; // 정상반환                               
                            }
                            else
                            {
                                //비밀번호가 틀릴때
                                scom.Connection.Close();
                                return 2; // 비번 불일치
                            }
                        }
                    }
                    //ID가 일치하는게 없을때
                    scom.Connection.Close();
                    return 3; // 아이디없음
                }
            }
        }
        #endregion
    }
}
