using System;
using System.IO;

namespace Service
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 클래스 이름 "Service"을 변경할 수 있습니다.
    public class Service : IService
    {
        DBManager DBM = DBManager.GetInstance();
        Rnet RNT = Rnet.GetInstance();
       
        #region Wcf 테스트
        public string ConnectTset()
        {
            return "Connect Complet";
        }
        #endregion

        //회원가입
        #region 아이디 중복검사 메인로직
        /// <summary>
        /// 아이디 중복 검사 메소드입니다.
        /// </summary>
        /// <param name="user_id">중복 검사를 할 아이디입니다.</param>
        /// <returns>True:성공 False:실패</returns>
        public bool IdCheck(string user_id)
        {
            //아이디 중복 검사
            string sql = string.Empty;
            bool result = false;

            sql = "SELECT * FROM Student"; //학생테이블 조회 쿼리
            result = DBM.IDCheckDB(sql, user_id);
            if (result == false)
            {
                return false;
            }
            sql = "SELECT * FROM Teacher"; //강사테이블 조회 쿼리
            result = DBM.IDCheckDB(sql, user_id);
            if (result == false)
            {
                return false;
            }
            sql = "SELECT * FROM Parent"; //부모테이블 조회 쿼리
            result = DBM.IDCheckDB(sql, user_id);
            if (result == false)
            {
                return false;
            }
            return true;
        }

        #endregion
        #region 회원가입 메인로직
        /// <summary>
        /// 회원가입 함수입니다.
        /// </summary>
        /// <param name="user_id">회원 가입할 아이디입니다.</param>
        /// <param name="pw">회원가입할 패스워드입니다.</param>
        /// <param name="name">회원의 이름입니다.</param>
        /// <param name="phonnum">회원의 전화번호입니다.</param>
        /// <param name="type">회원의 타입입니다.</param>
        /// <param name="child_id">학부모 회원의 경우에 해당하며 자녀의 아이디입니다.</param>
        /// <returns></returns>
        public int AddMember(string user_id, string pw, string name, string phonnum, int type, string child_id)
        {
            string sql = string.Empty;
            int childnum = 0;
            if (type == 2)
            {
                sql = "select 학생번호 from Student where 아이디='" + child_id + "'";
                childnum = DBM.SearchID_NumDB(sql);
                if (childnum == 0)
                {
                    return 2;
                }
            }
            switch (type)
            {
                case 1: sql = "INSERT INTO Student (아이디,비밀번호,이름,전화번호,로그인중복) VALUES (@아이디,@비밀번호,@이름,@전화번호,@로그인중복)"; break; //학생 DB에저장
                case 2: sql = "INSERT INTO Parent (아이디,비밀번호,이름,전화번호,자녀학생번호,로그인중복) VALUES (@아이디,@비밀번호,@이름,@전화번호,@자녀학생번호,@로그인중복)"; break; //부모 DB에저장
                case 3: sql = "INSERT INTO Teacher (아이디,비밀번호,이름,전화번호,로그인중복) VALUES (@아이디,@비밀번호,@이름,@전화번호,@로그인중복)"; break; //강사 DB에저장
                default: return 0;
            }
            DBM.AddMemberSaveDB(sql, user_id, pw, name, phonnum, type, childnum);
            if (type == 3)
            {                
                DBM.AddTeacherPort(user_id);
            }

            return 1;
        }
        #endregion
        
        //로그인
        #region 로그인 메인로직
        /// <summary>
        /// 로그인 요청 함수입니다.
        /// </summary>
        /// <param name="user_id">로그인하는 회원의 아이디입니다.</param>
        /// <param name="pw">로그인하는 회원의 패스워드입니다.</param>
        /// <returns>
        /// 1:학생 로그인 성공 2:강사 로그인 성공 3:로그인 성공
        /// 4:아이디가 존재하지 않음 5:비밀번호 불일치 6:이미 로그인중인 아이디.
        /// </returns>
        public int Login(string user_id, string pw)
        {
            string sql = string.Empty;
            int result = 0;

            sql = "SELECT * FROM Student";// 학생테이블 조회 쿼리
            result = DBM.LoginCheckDB(sql, user_id, pw);
            switch (result)
            {
                case 0: return 0;
                case 1:
                    {
                        sql = "UPDATE Student set 로그인중복=1 where 아이디='" + user_id + "'";
                        DBM.UpdateDataDB(sql);
                        return 1;
                    }
                case 2: return 5;
                case 4: return 6;
                default: break;
            }

            sql = "SELECT * FROM Teacher";// 강사 테이블 조회 쿼리
            result = DBM.LoginCheckDB(sql, user_id, pw);
            switch (result)
            {
                case 0: return 0;
                case 1:
                    {
                        sql = "UPDATE Teacher set 로그인중복=1 where 아이디='" + user_id + "'";
                        DBM.UpdateDataDB(sql);
                        return 2;
                    }
                case 2: return 5;
                case 4: return 6;
                default: break;
            }

            sql = "SELECT * FROM Parent";// 부모 테이블 조회 쿼리
            result = DBM.LoginCheckDB(sql, user_id, pw);
            switch (result)
            {
                case 0: return 0;
                case 1:
                    {
                        sql = "UPDATE Parent set 로그인중복=1 where 아이디='" + user_id + "'";
                        DBM.UpdateDataDB(sql);
                        return 3;
                    }
                case 2: return 5;
                case 4: return 6;
                default: break;
            }

            if (result == 3) { return 4; }

            return 0;
        }
        #endregion
        #region 강사 로그인시 ip 업데이트
        public void UpdateTeacherIP(string id, string ip)
        {
            string sql = "Update teacher set 아이피='"+ip+"' where 아이디='"+id+"'";
            DBM.UpdateDataDB(sql);
        }
        #endregion

        //로그아웃
        #region 로그아웃 메인로직
        /// <summary>
        /// 로그아웃 메인로직
        /// </summary>
        /// <param name="user_id">로그아웃을 요청할 아이디입니다.</param>
        /// <returns>
        /// True:성공 False:실패
        /// </returns>
        public bool LogOut(string user_id)
        {
            string sql = string.Empty;
            bool result = false;

            sql = "SELECT * FROM Student";// 학생테이블 조회 쿼리
            result = DBM.LogOutCheckDB(sql, user_id);
            if (result == true)
            {
                sql = "UPDATE Student set 로그인중복=0 where 아이디='" + user_id + "'";
                DBM.UpdateDataDB(sql);
                return true;
            }

            sql = "SELECT * FROM Teacher";// 강사 테이블 조회 쿼리
            result = DBM.LogOutCheckDB(sql, user_id);
            if (result == true)
            {
                sql = "UPDATE Teacher set 로그인중복=0 where 아이디='" + user_id + "'";
                DBM.UpdateDataDB(sql);
                return true;
            }

            sql = "SELECT * FROM Parent";// 부모 테이블 조회 쿼리
            result = DBM.LogOutCheckDB(sql, user_id);
            if (result == true)
            {
                sql = "UPDATE Parent set 로그인중복=0 where 아이디='" + user_id + "'";
                DBM.UpdateDataDB(sql);
                return true;
            }
            return result;
        }
        #endregion
        
        //학생
        #region 학기별 강사 목록 가져오기
        public string[] GetSemesterTeacherList(int semester)
        {
            string sql = "";
            int count = 0;
            switch (semester)
            {
                case 1: sql = "select Count(*) from teacher where 강의과목>='1' AND 강의과목<='8'"; break;
                case 2: sql = "select Count(*) from teacher where 강의과목>='9' AND 강의과목<='12'"; break;
                case 3: sql = "select Count(*) from teacher where 강의과목>='13' AND 강의과목<='16'"; break;
                case 4: sql = "select Count(*) from teacher where 강의과목>='17' AND 강의과목<='21'"; break;
                case 5: sql = "select Count(*) from teacher where 강의과목>='22' AND 강의과목<='24'"; break;
                case 6: sql = "select Count(*) from teacher where 강의과목>='25' AND 강의과목<='29'"; break;
                default: return null;
            }
            count = DBM.GetIntDataDB(sql);            
            switch (semester)
            {
                case 1: sql = "select 이름 from teacher where 강의과목>='1' AND 강의과목<='8'"; break;
                case 2: sql = "select 이름 from teacher where 강의과목>='9' AND 강의과목<='12'"; break;
                case 3: sql = "select 이름 from teacher where 강의과목>='13' AND 강의과목<='16'"; break;
                case 4: sql = "select 이름 from teacher where 강의과목>='17' AND 강의과목<='21'"; break;
                case 5: sql = "select 이름 from teacher where 강의과목>='22' AND 강의과목<='24'"; break;
                case 6: sql = "select 이름 from teacher where 강의과목>='25' AND 강의과목<='29'"; break;
                default: return null;
            }            
            string[] teacher = DBM.GetSemesterTeacherListDB(sql, count);
            return teacher;
        }
        #endregion
        #region 강사이름으로 해당강사 수업단원 가져오기
        public string GetUnit_TeacherName(string teachername)
        {
            string unit = null;
            string sql = "select 강의과목 from teacher where 이름 = '" + teachername + "'";
            unit = DBM.GetStringDataDB(sql);
            return unit; 
        }
        #endregion
        #region 강사이름으로 해당강사 강의시작시각 가져오기
        public string GetTime_TeacherName(string teachername)
        {
            string fristtime = null;
            string sql = "select 시작시각 from teacher where 이름='" + teachername + "'";
            fristtime = DBM.GetStringDataDB(sql);
            return fristtime;
        }
        #endregion
        #region 강사이름으로 해당강사 수업요일 가져오기
        public int GetDay_TeacherName(string teachername)
        {
            int day = 0;
            string sql = "select 강의요일 from teacher where 이름='" + teachername + "'";
            day = DBM.GetIntDataDB(sql);
            return day;
        }
        #endregion
        #region 강사이름으로 해당강사 강의시간 가져오기
        public string GetLectTime_TeacherName(string teachername)
        {
            string time = null;
            string sql = "select 강의시간 from teacher where 이름='" + teachername + "'";
            time = DBM.GetStringDataDB(sql);
            return time;
        }
        #endregion

        #region 강의 수강신청 
        public bool ApplyLecture(string teachername, int unit, string starttime, string lecttime, int day, string id)
        {
            string sql = "UPDATE student SET 담당강사 ='" + teachername + "',수강과목 = '" + unit + "',시작시각 = '" + starttime + "',수강시간 = '"+ lecttime + "',수강요일 = '" + day + "' WHERE 아이디='" + id + "'";
            bool reslut = DBM.UpdateLectureDB(sql);
            if (reslut == false)
            {
                return false;
            }            
            return true;
        }
        #endregion
        
        #region 단위지식 이름으로 단위지식 설명 가져오기
        public string GetConceptExplain(string concept)
        {
            string sql = "select 단위지식설명 from Concept where 단위지식이름 ='" + concept + "'";
            string conceptexplain = DBM.GetStringDataDB(sql);
            if (conceptexplain == null)
            {
                return null;
            }
            return conceptexplain;
        }
        #endregion        
        #region 단원의 문제 번호 랜덤 생성
        public int GetProblumNum(int unit,int type)
        {
            string sql = "";
            switch (type)
            {
                case 1:
                    {
                        sql = "select count(*) from UP where 교과목번호=" + unit;
                        int max_random = DBM.GetIntDataDB(sql);

                        Random random = new Random();
                        int rand_num = random.Next(1, max_random);

                        sql = "select 문제번호+" + rand_num + "from UP where 교과목번호=" + unit;
                        break;
                    }
                case 2: { sql = "select top 1 problem.문제번호 from UP,Problem where 교과목번호 = " + unit + " and 오답율 = 80 and up.문제번호 = problem.문제번호 order by NEWID()"; break; }
                case 3: { sql = "select top 1 problem.문제번호 from UP,Problem where 교과목번호 = " + unit + " and 오답율 = 50 and up.문제번호 = problem.문제번호 order by NEWID()"; break; }
                case 4: { sql = "select top 1 problem.문제번호 from UP,Problem where 교과목번호 = " + unit + " and 오답율 = 33 and up.문제번호 = problem.문제번호 order by NEWID()"; break; }
            }            
            int pnum = DBM.GetIntDataDB(sql);
            return pnum;
            
        }
        #endregion
        #region 문제번호로 문제 이미지 가져오기 
        public byte[] GetProblumImage(int pnum)
        {   
            string sql = "select 문제 from Problem where 문제번호=" + pnum;
            string path = DBM.GetStringDataDB(sql);
            
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            byte[] pimg = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();

            return pimg;
        }
        #endregion        
        #region 시험결과 
        public int[] SaveTestResult(string sid, int[] pnum, int[] answer, int[] time)
        {
            int test_count = 20;            
            int[] ans = new int[test_count + 1];            

            /// 학생아이디로 학생 번호 반환 
            string sql = "select 학생번호 from Student where 아이디 = '" + sid + "'";
            int snum = DBM.GetIntDataDB(sql);

            //문제번호로 정답 가져오기
            for (int i = 1; i < test_count + 1; i++)
            {
                sql = "select 정답 from Problem where 문제번호=" + pnum[i];
                ans[i] = DBM.GetIntDataDB(sql);
            }

            //정답 비교 
            for (int i = 1; i < test_count + 1; i++)
            {
                if (ans[i] == answer[i])//맞을경우
                {                   
                    DBM.SaveResult_true(snum, pnum[i], time[i]);
                }

                if (ans[i] != answer[i])//틀릴경우
                {                    
                    DBM.SaveResult_false(snum, pnum[i], time[i]);
                }
            }
            return ans;
        }
        #endregion
        #region 시험점수 DB에 저장 
        public void TestResultUpdate(string id,int unit,int score)
        {
            DateTime reulttime = DateTime.Now;
            string reulttimeToString = reulttime.ToString("MM.dd");
            string sql = "select 학생번호 from Student where 아이디 = '" + id + "'";
            int snum = DBM.GetIntDataDB(sql);
            DBM.TestResultUpdateDB(snum, unit, score, reulttimeToString);
        }
        #endregion
        
        #region 학생 정보 가져오기 
        public string GetStudentInfo_StartTime(string id)
        {
            string sql = "select 시작시각 from Student where 아이디='"+id+"'";
            string time = DBM.GetStringDataDB(sql);
            return time;
        }
        public string GetStudentInfo_LectTime(string id)
        {
            string sql = "select 수강시간 from Student where 아이디='" + id + "'";
            string time = DBM.GetStringDataDB(sql);
            return time;
        }
        public int GetStudentInfo_Unit(string id)
        {
            string sql = "select 수강과목 from Student where 아이디='"+id+"'";
            int unit = DBM.GetIntDataDB(sql);
            return unit;
        }

        public string GetStudentInfo_TeacherName(string id)
        {
            string sql = "select 담당강사 from Student where 아이디='"+id+"'";
            string teachername = DBM.GetStringDataDB(sql);
            return teachername;
        }

        public int GetStudentInfo_day(string id)
        {
            string sql = "select 수강요일 from Student where 아이디='"+id+"'";
            int day = DBM.GetIntDataDB(sql); 
            return day;
        }
        #endregion

        #region 강사 포트 번호 가져오기 
        //강사 이름으로 가져오기
        public string GetTeacherPort_ByStu(string teachernaem)
        {
            string sql = "select 포트번호 from teacher where 이름='"+ teachernaem + "'";
            string port = string.Empty;
            port = DBM.GetStringDataDB(sql);
            return port;
        }
        //강사 ID 로 가져오기
        public string GetTeacherPort_ByTeac(string id)
        {
            string sql = "select 포트번호 from teacher where 아이디='" + id + "'";
            string ip = string.Empty;
            ip = DBM.GetStringDataDB(sql);
            return ip;
        }
        #endregion
        #region 강사 IP 가져오기
        //강사 이름으로 가져오기
        public string GetTeacherIP_ByStu(string teachernaem)
        {
            string sql = "select 아이피 from teacher where 이름='" + teachernaem + "'";
            string port = string.Empty;
            port = DBM.GetStringDataDB(sql);
            return port;
        }
        #endregion

        #region 아이디로 이름가져오기
        public string GetNameByID(string id)
        {
            string sql = "select 이름 from student where 아이디='" + id + "'";
            string name = string.Empty;
            name = DBM.GetStringDataDB(sql);
            return name;

        }
        #endregion

        #region 학생 이름 가져오기
        public string GetStudentName(string id)
        {
            string sql = "select 자녀학생번호 from Parent where 아이디 = '"+id+"'";
            int snum = DBM.GetIntDataDB(sql);
            sql = "select 이름 from Student where 학생번호 = "+snum;
            string sname = DBM.GetStringDataDB(sql);  
            return sname;
        }
        #endregion

        #region 학부모에서 학생아이디 가져오기
        public string GetSutdnetIDByPar(string id)
        {
            string sql = "select 자녀학생번호 from Parent where 아이디 = '" + id + "'";
            int snum = DBM.GetIntDataDB(sql);
            sql = "select 아이디 from Student where 학생번호 = " + snum;
            string sid = DBM.GetStringDataDB(sql);
            return sid;
        }
        #endregion

        #region 학생 전화번호 가져오기
        public string GetStudentPhon(string id)
        {
            string sql = "select 전화번호 from student where 아이디= '" + id + "'";
            string phon = DBM.GetStringDataDB(sql);
            return phon;
        }
        #endregion

        #region 강사이름 가져오기
        public string GetTeachrNameByID(string id)
        {
            string sql = "select 이름 from teacher where 아이디 = '" + id + "'";
            string name=DBM.GetStringDataDB(sql);
            return name;
        }
        #endregion

        #region 학생 수 가져오기
        public int GetStudentCount(string name)
        {
            string sql = "select count (*) from Student where 담당강사='" + name + "'";
            int count = DBM.GetIntDataDB(sql);
            return count;
        }
        #endregion

        #region 학생아이디 리스트 가져오기
        public string[] GetStudentIDByTeach(string name, int count)
        {
            string sql = "select 아이디 from Student where 담당강사='" + name + "'";
            string[] stuid = DBM.GetStudentIDListDB(sql, count);
            return stuid;
        }
        #endregion

        #region 학생이름 리스트 가져오기
        public string[] GetStudentNameByTeach(string name,int count)
        {
            string sql = "select 이름 from Student where 담당강사='" + name + "'";
            string[] stuname = DBM.GetStudentNameListDB(sql,count);
            return stuname;
        }
        #endregion
        
        #region 학생 전화번호 리스트 가져오기
        public string[] GetStudentPhonByTeach(string name,int count)
        {
            string sql = "select 전화번호 from Student where 담당강사='" + name + "'";
            string[] stuphon = DBM.GetStudentPhonListDB(sql, count);
            return stuphon;
        }
        #endregion

        #region 강의 상태 저장 
        public bool SaveLecture(string id, int unitnum, string starttime, string lectime, int day)
        {
            bool result = false;
            string sql = "Update teacher set 강의과목 =" + unitnum + ",시작시각 = '"+ starttime + "',강의요일 ="+day+",강의시간='"+ lectime + "' where 아이디='"+id+"'";
            result = DBM.UpdateLectureDBofTeach(sql);
            return result;
        }
        #endregion

        #region 강의 신청 체크 하기
        public bool CheckTeacher(string id)
        {
            string sql = "select 담당강사 from Student where 아이디 = '" + id + "'";
            string teachername = string.Empty;
            try
            {
                teachername = DBM.GetStringDataDB(sql);
                if (teachername == "")
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;  
            }

        }
        #endregion

        #region 단위지식 번호가져오기
        public int GetConcpetnum(string concpet)
        {
            string sql = "select 단위지식번호 from Concept where 단위지식이름 = '" + concpet + "'";
            int concpetnum = DBM.GetIntDataDB(sql);
            return concpetnum;
        }
        #endregion

        #region 이미지업로드 
        /// <summary>
        /// </summary>
        /// <param name="img"></param>
        /// <param name="unit"></param>
        /// <param name="concept"></param>
        /// <param name="answer"></param>        
        /// <returns></returns>
        public bool UploadImg(byte[] img, int unit, int[] concept, int answer)
        {
            //문제 번호 가져오기
            string sql = "Select COUNT (*) From Problem";
            int pnum = DBM.GetIntDataDB(sql);
            pnum = pnum + 1;

            //이미지 파일 경로로 저장
            string fpath = "E:\\image\\Problum_";
            string path = fpath + unit + "_" + pnum + ".png";
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            stream.Write(img, 0, img.Length);
            stream.Dispose();

            //이미지 문제 DB 저장 
            DBM.UploadImg(path, answer);
            //단원 문제 연결 
            DBM.ConnectProblemUnit(unit, pnum);
            //단위지식 문제 연결
            DBM.ConnectProblemConcept(concept,pnum);
            return true;
        }
        #endregion

        #region R 사용전 분석자번호 DB 업로드
        public bool UpdateUseR_StuTea(string sid)
        {
            string sql = "Select 학생번호 From Student where 아이디 = '"+sid+"'";
            int snum = DBM.GetIntDataDB(sql);
            sql = "Update StuData set 학생번호 = "+ snum;
            DBM.UpdateDataDB(sql);
            return true;
        }        
        public bool UpdateUseR_Par(string pid)
        {
            string sql = "Select 자녀학생번호 From Parent where 아이디 = '" + pid + "'";
            int snum = DBM.GetIntDataDB(sql);
            sql = "Update StuData set 학생번호 = " + snum;
            DBM.UpdateDataDB(sql);
            return true;
        }
        public bool UpdateUserR_Tea(string tid)
        {
            string sql = "Select 이름 From teacher where 아이디 = '" + tid + "'";
            string teachername = DBM.GetStringDataDB(sql);
            sql = "update TeacherData set 강사이름 = '"+ teachername + "'";
            DBM.UpdateDataDB(sql);
            return true;
        }
        #endregion

        #region R 분석 이미지 가져오기        
        public byte[] GetRDataImage(int type)
        {
            bool result = false;
            switch (type)
            {
                case 1: result = RNT.Stu_Achievement_Plot(); break;
                case 2: result = RNT.Stu_Achievement_Plot(); break;
                case 3: result = RNT.Stu_Strength_Week_Plot(); break;
                case 4: result = RNT.Stu_Strength_Week_Plot(); break;
                case 5: result = RNT.AllStu_Achievement_Plot(); break;
                case 6: result = RNT.AllStu_Achievement_Plot(); break;
                case 7: result = RNT.AllStu_Strength_Week_Plot(); break;
                case 8: result = RNT.AllStu_Strength_Week_Plot(); break;
                case 9: result = RNT.AllStu_Achievement_Ggplot(); break;
                case 10: result = RNT.Stu_Achievement_Ggplot();break;
                case 11: result = RNT.Unit_count_plot();break;
                default: result = false; break;
            }
            if (result == false)
            {
                return null;
            }
            string sql = string.Empty;
            switch (type)
            {
                case 1: sql = "select imageAddress from RData where name='학생시간별성취도'"; break;
                case 2: sql = "select imageAddress from RData where name='학생단원별성취도'"; break;
                case 3: sql = "select imageAddress from RData where name='학생강점단원'"; break;
                case 4: sql = "select imageAddress from RData where name='학생취약단원'"; break;
                case 5: sql = "select imageAddress from RData where name='전체학생시간별성취도'"; break;
                case 6: sql = "select imageAddress from RData where name='전체학생단원별성취도'"; break;
                case 7: sql = "select imageAddress from RData where name='전체학생강점단원'"; break;
                case 8: sql = "select imageAddress from RData where name='전체학생취약단원'"; break;
                case 9: sql = "select imageAddress from RData where name='전체학생단원별점수산포도'"; break;
                case 10: sql ="select imageAddress from RData where name='학생단원별점수산포도'"; break;
                case 11: sql ="select imageAddress from RData where name='단원별문제이용개수'"; break;
                default: return null;
            }                
            string path = DBM.GetStringDataDB(sql);

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            byte[] img = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();

            return img;
        }
        #endregion

        #region 단원별 학생 성취도
        public string GetStudentAchievementByUnit(string id)
        {
            string result;
            StudentAnalysisByUnits analysis = new StudentAnalysisByUnits();
            result = analysis.AnalysisScore(id);
            return result;
        }
        #endregion

        #region 시간별 학생 성취도
        public string GetStudentAchievementByDate(string id)
        {
            string result;
            StudentAnalysisByDates analysis = new StudentAnalysisByDates();
            result = analysis.AnalysisScores(id);
            return result;
        }
        #endregion
        
        #region 강점 분석
        public string GetStrongConceptAnalysis(string id)
        {
            string result;
            StudentAnalysisByConcept analysis = new StudentAnalysisByConcept();
            result = analysis.AnalysisStrongConcept(id);
            return result;
        }
        #endregion

        #region 취약점 분석
        public string GetWeakConceptAnalysis(string id)
        {
            string result;
            StudentAnalysisByConcept analysis = new StudentAnalysisByConcept();
            result = analysis.AnalysisWeakConcept(id);
            return result;
        }
        #endregion

        #region 예상 점수 가져오기
        public double GetScore(string sid)
        {
            string sql= "select v1 from predict where 학생번호 = (select 학생번호 from Student where 아이디 = '" + sid + "')";
            double score = DBM.GetDoubleDataDB(sql);
            return score; 
        }
        #endregion

        #region 단위지식 갯수 가져오기
        public int ConcpetCount(string unit)
        {
            string sql = "select count(*) from UC where 교과목번호 = (select 교과목번호 from Unit where 교과목이름 = '" + unit + "')";
            int count = DBM.GetIntDataDB(sql);
            return count;
        }
        #endregion

        #region 단위지식 리스트가져오기
        public string[] ConceptList(string unit,int count)
        {
            
            string sql = "select 단위지식번호 from UC where 교과목번호 = (select 교과목번호 from Unit where 교과목이름 = '"+unit+"')";
            int[] conceptnum = DBM.GetConceptNumListDB(sql,count);
            string[] concept = new string[count];
            for (int i = 0; i < count; i++)
            {
                sql = "select 단위지식이름 from Concept where 단위지식번호 = " + conceptnum[i];
                concept[i] = DBM.GetStringDataDB(sql);
            }
            return concept;
        }
        #endregion

        #region 정답률 순위 구하기
        public int[] GetRankAnswer_Score()
        {
           
            string sql = "select TOP 10 avg(학생점수) as 정답률,이름 from stuscore,Student where StuScore.학생번호 = student.학생번호 group by 이름 order by 정답률 DESC";
            int[] score = DBM.GetRankAnswer_ScoreDB(sql);
            return score;
        }
        public string[] GetRankAnswer_Name()
        {
            string sql = "select TOP 10 avg(학생점수) as 정답률,이름 from stuscore,Student where StuScore.학생번호 = student.학생번호 group by 이름 order by 정답률 DESC";
            string[] name = DBM.GetRankAnswer_Name(sql);
            return name;
        }
        #endregion

        #region 최근 응시현황 가져오기
        public RecentStatusStare GetRecentStatusStare(string id)
        {
            string sql = "select TOP 10 문제푼시간,학생점수,교과목이름 from ps1,stuscore,unit,StuData where StuScore.교과목번호=unit.교과목번호 and stuscore.학생번호 = (select 학생번호 from Student where 아이디='"+id+"') group by 문제푼시간,학생점수,교과목이름 order by 문제푼시간 desc";
            RecentStatusStare recent = DBM.GetRecentStatusStareDB(sql);
            return recent;
        }
        #endregion

        #region 취약단위지식 가져오기
        public string[] GetWeakPoint(string id)
        {
            string sql = " select TOP 10 단위지식이름 from cp,Concept where cp.단위개념번호 = Concept.단위지식번호 and 문제번호 in(select 틀린문제번호 from ps where 학생번호 = (select 학생번호 from Student where 아이디 = '" + id + "')) group by 단위개념번호,단위지식이름 HAVING count(*) >= 1 ORDER BY count(*) DESC";
            string[] conceptname = DBM.GetGetWeakPoint(sql);
            return conceptname;
        }
        #endregion

        #region 학생 평균점수 가져오기
        public int StudentAvgScore(string id)
        {
            string sql = "select avg(학생점수) as 학생점수 from stuscore,Student where student.학생번호= StuScore.학생번호 and Student.아이디='" + id + "'";
            int avg = DBM.GetIntDataDB(sql);
            return avg;
        }
        #endregion

    }
}
