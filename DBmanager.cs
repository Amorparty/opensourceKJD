using MySql.Data.MySqlClient;

namespace Login
{
    class DBManager
    {
        #region 싱글톤 
        static DBManager dbm;
        protected DBManager() { }
        public static DBManager GetInstance()
        {
            if (dbm == null)
            {
                dbm = new DBManager();
            }
            return dbm;
        }
        #endregion

        #region DB 연결
        //DB 서버 주소 연결        
        static string connStr = @"Server=localhost;Database=test;Uid=root;Pwd=enqn132";
        MySqlConnection scon = new MySqlConnection(connStr); // DB 연결
        #endregion

        //회원가입
        #region ID 중복검사 
        internal bool IDCheckDB(string id)
        {
            string sql = "SELECT * FROM member";
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
                        if (reader["id"].Equals(id))
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
            string sql = "INSERT INTO member(id, pw, name, age, sex, address) VALUES(@id, @pw, @name, @age, @sex, @address)";

            using (MySqlCommand scom = new MySqlCommand(sql, scon))
            {
                MySqlParameter sp_id = new MySqlParameter("@id", id);
                MySqlParameter sp_pw = new MySqlParameter("@pw", pw);
                MySqlParameter sp_name = new MySqlParameter("@name", name);
                MySqlParameter sp_age = new MySqlParameter("@age", age);
                MySqlParameter sp_sex = new MySqlParameter("@sex", sex);
                MySqlParameter sp_address = new MySqlParameter("@address", address);

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

        //로그인
        #region 로그인        
        internal int Login(string id, string pw)
        {

            string sql = "SELECT * FROM member";
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
                        if (reader["id"].Equals(id))
                        {
                            if (reader["pw"].Equals(pw))
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
