using System;
using System.Data.SqlClient;

namespace Service
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
        static string connStr = @"Data Source=192.168.1.10;Initial Catalog=Success;Integrated Security=False;User ID=sa;Password=123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection scon = new SqlConnection(connStr); // DB 연결
        #endregion

        // 회원가입
        #region ID 중복검사 DB 확인 
        /// <returns> T:ID없음 F:ID있음</returns>
        internal bool IDCheckDB(string sql, string id)
        {
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return false;
                    }
                    while (reader.Read())
                    {
                        if (reader["아이디"].Equals(id))
                        {
                            //ID가 중복 되면
                            scom.Connection.Close();
                            return false;
                        }
                    }
                    //ID가 일치하는게 없을때
                    scom.Connection.Close();
                    return true;
                }
            }
        }

        #endregion
        #region 회원 가입 
        #region 학생ID로 번호 조회
        internal int SearchID_NumDB(string sql)
        {
            int stunum = 0;
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                try
                {
                    stunum = int.Parse(scom.ExecuteScalar().ToString());
                }
                catch
                {
                    scom.Connection.Close();
                    return 0;
                }
                scom.Connection.Close();
            }
            return stunum;
        }
        #endregion
        #region DB에 가입정보 저장
        internal void AddMemberSaveDB(string sql, string user_id, string pw, string name, string phonnum, int type, int childnum)
        {
            int defultnum = 0;
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                SqlParameter sp_user_id = new SqlParameter("@아이디", user_id);
                SqlParameter sp_pw = new SqlParameter("@비밀번호", pw);
                SqlParameter sp_name = new SqlParameter("@이름", name);
                SqlParameter sp_phonnum = new SqlParameter("@전화번호", phonnum);
                SqlParameter sp_logincheck = new SqlParameter("@로그인중복", defultnum);

                if (type == 2)
                {
                    SqlParameter sp_children_id = new SqlParameter("@자녀학생번호", childnum);
                    scom.Parameters.Add(sp_children_id);
                }
                scom.Parameters.Add(sp_user_id);
                scom.Parameters.Add(sp_pw);
                scom.Parameters.Add(sp_name);
                scom.Parameters.Add(sp_phonnum);
                scom.Parameters.Add(sp_logincheck);

                scom.Connection.Open();
                scom.ExecuteNonQuery();
                scom.Connection.Close();
            }
        }
        #endregion
        #region 선생 포트번호 저장
        internal void AddTeacherPort(string user_id)
        {
            int port = 10000;
            int teachernum = 0;
            string sql = "select 강사번호  from teacher where 아이디 = '" + user_id + "'";
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                teachernum = int.Parse(scom.ExecuteScalar().ToString());
                scom.Connection.Close();
            }
            port = port + teachernum;
            sql = "UPDATE teacher SET 포트번호 ='" + port + "'WHERE 아이디='" + user_id + "'";
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                scom.ExecuteNonQuery();
                scom.Connection.Close();
            }

        }
        #endregion
        #endregion

        // 로그인 로그아웃
        #region 로그인        
        /// <returns> 에러:0 성공:1 비번불일치:2 아이디없음:3 로그인중:4</returns>
        internal int LoginCheckDB(string sql, string id, string pw)
        {
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return 0; // 에러
                    }
                    while (reader.Read())
                    {
                        if (reader["아이디"].Equals(id))
                        {
                            if (reader["비밀번호"].Equals(pw))
                            {
                                if (reader["로그인중복"].Equals(1))
                                {
                                    scom.Connection.Close();
                                    return 4;
                                }
                                scom.Connection.Close();
                                return 1; // 성공
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
        #region 로그아웃        
        internal bool LogOutCheckDB(string sql, string id)
        {
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return false; // 에러
                    }

                    while (reader.Read())
                    {
                        if (reader["아이디"].Equals(id))
                        {
                            scom.Connection.Close();
                            return true;
                        }
                    }
                    //ID가 일치하는게 없을때
                    scom.Connection.Close();
                    return false; // 아이디없음
                }
            }
        }
        #endregion

        //학기선택시 강사리스트가져오기         
        #region DB에서 강사리스트 가져오기
        internal string[] GetSemesterTeacherListDB(string sql, int count)
        {
            int i = 0;
            string[] teacher = new string[count];
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return null;
                    }
                    while (reader.Read())
                    {
                        teacher[i] = reader["이름"].ToString();
                        i++;
                    }
                    scom.Connection.Close();
                }
            }
            return teacher;
        }

        #endregion

        //학생 수강신청 상태변경
        #region 강의수강신청 DB 업데이트
        internal bool UpdateLectureDB(string sql)
        {
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                try
                {
                    scom.Connection.Open();
                    scom.ExecuteNonQuery();
                    scom.Connection.Close();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        //학생 문제풀이 결과값 저장 
        #region 결과값 DB에 저장 (PS)//맞을경우
        public void SaveResult_true(int snum, int pnum, int sendtime)//문제번호, 데이터가전송된시각,푸는데걸린시간
        {
            string sql = "INSERT INTO PS1 (시각,맞은문제번호,학생번호) VALUES (@시각,@맞은문제번호,@학생번호)";
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {

                SqlParameter sp_sendtime = new SqlParameter("@시각", sendtime);
                SqlParameter sp_pnum = new SqlParameter("@맞은문제번호", pnum);
                SqlParameter sp_snum = new SqlParameter("@학생번호", snum);

                scom.Parameters.Add(sp_sendtime);
                scom.Parameters.Add(sp_pnum);
                scom.Parameters.Add(sp_snum);

                scom.Connection.Open();
                scom.ExecuteNonQuery();
                scom.Connection.Close();
            }
        }
        #endregion
        #region 결과값 DB에 저장 (PS1)//틀릴경우
        public void SaveResult_false(int snum, int pnum, int sendtime)//문제번호, 데이터가전송된시각,푸는데걸린시간
        {
            string sql = "INSERT INTO PS (시각,틀린문제번호,학생번호) VALUES (@시각,@틀린문제번호,@학생번호)";
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {

                SqlParameter sp_sendtime = new SqlParameter("@시각", sendtime);
                SqlParameter sp_pnum = new SqlParameter("@틀린문제번호", pnum);
                SqlParameter sp_snum = new SqlParameter("@학생번호", snum);

                scom.Parameters.Add(sp_sendtime);
                scom.Parameters.Add(sp_pnum);
                scom.Parameters.Add(sp_snum);

                scom.Connection.Open();
                scom.ExecuteNonQuery();
                scom.Connection.Close();
            }
        }
        #endregion        
        #region 시험점수 저장
        public void TestResultUpdateDB(int snum, int unit, int score, string reulttimeToString)
        {
            string sql = "INSERT INTO stuscore (학생번호,학생점수,교과목번호,문제푼시간) VALUES (@학생번호,@학생점수,@교과목번호,@문제푼시간)";
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                SqlParameter sp_snum = new SqlParameter("@학생번호", snum);
                SqlParameter sp_score = new SqlParameter("@학생점수", score);
                SqlParameter sp_unit = new SqlParameter("@교과목번호", unit);
                SqlParameter sp_time = new SqlParameter("@문제푼시간", reulttimeToString);

                scom.Parameters.Add(sp_snum);
                scom.Parameters.Add(sp_score);
                scom.Parameters.Add(sp_unit);
                scom.Parameters.Add(sp_time);

                scom.Connection.Open();
                scom.ExecuteNonQuery();
                scom.Connection.Close();
            }
        }
        #endregion

        #region DB 정보 가져오기 및 업데이트
        internal string GetStringDataDB(string sql)
        {
            string StringData = string.Empty;
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                StringData = scom.ExecuteScalar().ToString();
                scom.Connection.Close();
            }
            return StringData;
        }

        internal int GetIntDataDB(string sql)
        {
            int IntData = 0;
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                IntData = int.Parse(scom.ExecuteScalar().ToString());
                scom.Connection.Close();
            }
            return IntData;
        }
        internal void UpdateDataDB(string sql)
        {
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                scom.ExecuteNonQuery();
                scom.Connection.Close();
            }
        }
        internal double GetDoubleDataDB(string sql)
        {
            double DoubleData = 0.0;
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                DoubleData = double.Parse(scom.ExecuteScalar().ToString());
                scom.Connection.Close();
            }
            return DoubleData;
        }

        #endregion

        #region 학생 목록 가져오기 - 아이디
        internal string[] GetStudentIDListDB(string sql, int count)
        {
            int i = 0;
            string[] stuname = new string[count];
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return null;
                    }
                    while (reader.Read())
                    {
                        stuname[i] = reader["아이디"].ToString();
                        i++;
                    }
                    scom.Connection.Close();
                }
            }
            return stuname;
        }
        #endregion
        #region 학생 목록 가져오기 - 이름 
        internal string[] GetStudentNameListDB(string sql, int count)
        {
            int i = 0;
            string[] stuname = new string[count];
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return null;
                    }
                    while (reader.Read())
                    {
                        stuname[i] = reader["이름"].ToString();
                        i++;
                    }
                    scom.Connection.Close();
                }
            }
            return stuname;
        }
        #endregion
        #region 학생 목록 가져오기 - 폰번호
        internal string[] GetStudentPhonListDB(string sql, int count)
        {
            int i = 0;
            string[] stuphon = new string[count];
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return null;
                    }
                    while (reader.Read())
                    {
                        stuphon[i] = reader["전화번호"].ToString();
                        i++;
                    }
                    scom.Connection.Close();
                }
            }
            return stuphon;

        }
        #endregion

        #region 강의 업데이트
        internal bool UpdateLectureDBofTeach(string sql)
        {
            try
            {
                using (SqlCommand scom = new SqlCommand(sql, scon))
                {
                    scom.Connection.Open();
                    scom.ExecuteNonQuery();
                    scom.Connection.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 단위지식번호 목록 가져오기 - 단원
        internal int[] GetConceptNumListDB(string sql, int count)
        {
            int[] concpetnum = new int[count];
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                int i = 0;
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return null;
                    }
                    while (reader.Read())
                    {
                        concpetnum[i] = int.Parse(reader["단위지식번호"].ToString());
                        i++;
                    }
                    scom.Connection.Close();
                }
            }
            return concpetnum;
        }
        #endregion

        #region 이미지업로드
        #region 이미지 경로로 DB 저장
        internal void UploadImg(string path, int answer)
        {
            string sql = "INSERT INTO Problem (문제,정답) VALUES (@문제,@정답)";
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                SqlParameter sp_path = new SqlParameter("@문제", path);
                SqlParameter sp_answer = new SqlParameter("@정답", answer);

                scom.Parameters.Add(sp_path);
                scom.Parameters.Add(sp_answer);

                scom.Connection.Open();
                scom.ExecuteNonQuery();
                scom.Connection.Close();
            }
        }
        #endregion
        #region 문제 단원 연결 
        internal void ConnectProblemUnit(int unit, int pnum)
        {
            string sql = "INSERT INTO UP (교과목번호,문제번호) VALUES (@교과목번호,@문제번호)";
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                SqlParameter sp_unit = new SqlParameter("@교과목번호", unit);
                SqlParameter sp_pnum = new SqlParameter("@문제번호", pnum);

                scom.Parameters.Add(sp_unit);
                scom.Parameters.Add(sp_pnum);

                scom.Connection.Open();
                scom.ExecuteNonQuery();
                scom.Connection.Close();
            }
        }
        #endregion
        #region 문제 단위지식 연결 
        internal void ConnectProblemConcept(int[] concept, int pnum)
        {
            string sql = "INSERT INTO CP (단위개념번호,문제번호) VALUES (@단위개념번호,@문제번호)";
            for (int i = 0; i < concept.Length; i++)
            {
                using (SqlCommand scom = new SqlCommand(sql, scon))
                {
                    SqlParameter sp_unit = new SqlParameter("@단위개념번호", concept[i]);
                    SqlParameter sp_pnum = new SqlParameter("@문제번호", pnum);

                    scom.Parameters.Add(sp_unit);
                    scom.Parameters.Add(sp_pnum);

                    scom.Connection.Open();
                    scom.ExecuteNonQuery();
                    scom.Connection.Close();
                }

            }

        }
        #endregion
        #endregion

        //분석 관련 메소드
        #region 각 단원별 평균값 호출
        internal StudentAnalysisByUnits.UnitAverage GetUnitAvg(int i)
        {
            string UnitName = "";
            int AvgScore = -1;
            string sql = "select avg(학생점수) AS 평균, 교과목이름 from ps1, stuscore, unit, StuData where StuScore.교과목번호 = unit.교과목번호 and unit.교과목번호 =" + i + "group by 교과목이름";
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return null;
                    }
                    while (reader.Read())
                    {
                        UnitName = reader["교과목이름"].ToString();
                        AvgScore = (int)reader["평균"];
                    }
                    scom.Connection.Close();
                }
            }
            return new StudentAnalysisByUnits.UnitAverage(UnitName, AvgScore);
        }
        #endregion
        #region 한 학생이 푼 모든 단원 점수가져오기
        internal void GetAllUnitScores(string sql, StudentAnalysisByUnits analysis)
        {
            string Unit = "";
            int UnitScore = -1;
            int index = -1;
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return;
                    }
                    while (reader.Read())
                    {
                        Unit = reader["교과목이름"].ToString();
                        UnitScore = (int)reader["학생점수"];

                        for (int i = 0; i < analysis.StudentScores.Count; i++)
                        {
                            if (analysis.StudentScores[i].UnitName == Unit)
                            {
                                index = i;
                            }
                        }
                        if (index == -1)
                        {
                            analysis.StudentScores.Add(new StudentAnalysisByUnits.StudentScore(Unit, UnitScore));
                        }
                        else
                        {
                            analysis.StudentScores[index].StuScore = UnitScore;
                        }
                    }
                    scom.Connection.Close();
                }
            }
        }
        #endregion
        #region 한 학생의 일별 평균 10개
        internal void GetStudentScoreByDates(int snum, StudentAnalysisByDates analysis)
        {
            string sql = "select TOP 10 AVG(학생점수) AS 평균, 문제푼시간 AS 날짜 from stuscore where stuscore.학생번호 = " + snum.ToString() + " group by 문제푼시간 order by 문제푼시간 DESC";
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return;
                    }
                    while (reader.Read())
                    {
                        analysis.StudentScores.Add(new StudentAnalysisByDates.StudentScore(reader["날짜"].ToString(), (int)reader["평균"]));
                    }
                    scom.Connection.Close();
                    analysis.StudentScores.Reverse();
                }
            }
        }
        #endregion
        #region 한 학생의 강점리스트
        public void GetStrongConcept(int snum, StudentAnalysisByConcept analysis)
        {
            analysis.WeakConcepts.Clear();
            string sql = "select TOP 3 단위지식이름, count(*) Count from cp, Concept, StuData where cp.단위개념번호 = Concept.단위지식번호 and 문제번호 in(select 맞은문제번호 from ps1 where 학생번호 = " + snum + ") group by 단위개념번호,단위지식이름 HAVING count(*) > 1 ORDER BY count(*) DESC";
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return;
                    }
                    while (reader.Read())
                    {
                        analysis.StrongConcepts.Add(new StudentAnalysisByConcept.ConceptFrequency(reader["단위지식이름"].ToString(), (int)reader["Count"]));
                    }
                    scom.Connection.Close();
                }
            }
        }
        #endregion
        #region 한 학생의 취약점리스트
        public void GetWeakConcept(int snum, StudentAnalysisByConcept analysis)
        {
            analysis.StrongConcepts.Clear();
            string sql = "select TOP 3 단위지식이름, count(*) Count from cp, Concept, StuData where cp.단위개념번호 = Concept.단위지식번호 and 문제번호 in(select 틀린문제번호 from ps where 학생번호 = " + snum + ") group by 단위개념번호,단위지식이름 HAVING count(*) > 1 ORDER BY count(*) DESC";
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return;
                    }
                    while (reader.Read())
                    {
                        
                        analysis.WeakConcepts.Add(new StudentAnalysisByConcept.ConceptFrequency(reader["단위지식이름"].ToString(), (int)reader["Count"]));
                    }
                    scom.Connection.Close();
                }
            }
        }
        #endregion

        #region 정답률 순위구하기
        internal int[] GetRankAnswer_ScoreDB(string sql)
        {
            int[] score = new int[10];
            int i = 0;
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return null;
                    }
                    while (reader.Read())
                    {
                        score[i] = int.Parse(reader["정답률"].ToString());
                        i++;
                    }
                    scom.Connection.Close();
                }
            }
            return score;
        }
        internal string[] GetRankAnswer_Name(string sql)
        {
            string[] name = new string[10];
            int i = 0;
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return null;
                    }
                    while (reader.Read())
                    {
                        name[i] = reader["이름"].ToString();
                        i++;
                    }
                    scom.Connection.Close();
                }
            }
            return name;            
        }
        #endregion
        #region  최근 응시현황 가져오기
        internal RecentStatusStare GetRecentStatusStareDB(string sql)
        {
            string[] unitname = new string[10];
            int[] score = new int[10];
            string[] time = new string[10];
            int i = 0;
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return null;
                    }
                    while (reader.Read())
                    {
                        unitname[i] = reader["교과목이름"].ToString();
                        score[i] = int.Parse(reader["학생점수"].ToString());
                        time[i] = reader["문제푼시간"].ToString();
                        i++;
                    }
                    scom.Connection.Close();
                }
            }
            RecentStatusStare recent = new RecentStatusStare(unitname, score, time);
            return recent;
        }
        #endregion
        #region 취약단위지식 가져오기
        internal string[] GetGetWeakPoint(string sql)
        {
            string[] conceptname = new string[10];
            int i = 0;
            using (SqlCommand scom = new SqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (SqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return null;
                    }
                    while (reader.Read())
                    {
                        conceptname[i] = reader["단위지식이름"].ToString();
                        i++;
                    }
                    scom.Connection.Close();
                }
            }
            return conceptname;
        }
        #endregion

    }
}
