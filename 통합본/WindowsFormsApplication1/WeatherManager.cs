using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApplication1
{
    class WeatherManager
    {
        public string method(double tem, double rh )
        {
            double bul = 0;
            double x = 1 - rh;
            double t = (tem - 26) * 1.8;
            double y = tem * 1.8;
            double z = x * t * 0.55*-1;
            bul = y + z + 32;

            string res = bul.ToString();
            return res;
        }
        public int tembase()
        {
            String strUrl = "http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=109";

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(strUrl);

            XmlNode cnode = xdoc.SelectSingleNode("rss");
            XmlNode ccnode = cnode.SelectSingleNode("channel");
            XmlNode cccnode = ccnode.SelectSingleNode("item");
            XmlNode ccccnode = cccnode.SelectSingleNode("description");
            XmlNode cccccnode = ccccnode.SelectSingleNode("body");
            XmlNode ccccccnode = cccccnode.SelectSingleNode("location");
            XmlNodeList xnl = ccccccnode.SelectNodes("data");

            int num=0;
            foreach (XmlNode xn in xnl)
            {
                string tmn = xn.SelectSingleNode("tmn").InnerText;
                // string tmx = xn.SelectSingleNode("tmx").InnerText;
                //int tem = int.Parse(textBox1.Text);
                string tem_result;
                WeatherManager wm = new WeatherManager();
                tem_result = wm.method(Convert.ToDouble(tmn), 0.5);
                //불쾌지수 70 이상 가벼운 긴팔 추천
                if (Convert.ToDouble(tem_result) > 70)
                {
                    num = 1;
                }
                //불쾌지수 80이상 반팔 반바지 추천
                else if (Convert.ToDouble(tem_result) > 80)
                {
                   num = 2;
                }

            }
            return num;
            
            

        }
        public  List<string> manager(string place)
        {
            List<string> result3 = new List<string>();
            if (place == "경기도")
            {
                result3 = kyunggi();
            }
            else if (place == "서울")
            {
                result3 = seoul();
            }
            else if (place == "강원도")
            {
                result3 = gangwondo();
            }
            else if (place == "충청북도")
            {
                result3 = chungbuk();
            }
            else if (place == "충청남도")
            {
                result3 = chungnam();
            }
            else if (place == "전라북도")
            {
                result3 = jeonbuk();
            }
            else if (place == "전라남도")
            {
                result3 = jeonnam();
            }
            else if (place == "경상북도")
            {
                result3 = kyungbuk();
            }
            else if (place == "경상남도")
            {
                result3 = kyungnam();
            }
            else if (place == "제주도")
            {
                result3 = jeju();
            }
            return result3;
        }
        private static List<string> kyunggi ()
        {
            List<string> result2 = new List<string>();

            String strUrl = "http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=109";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(strUrl);

            XmlNode cnode = xdoc.SelectSingleNode("rss");
            XmlNode ccnode = cnode.SelectSingleNode("channel");
            XmlNode cccnode = ccnode.SelectSingleNode("item");
            XmlNode ccccnode = cccnode.SelectSingleNode("description");
            XmlNode cccccnode = ccccnode.SelectSingleNode("body");
            XmlNode ccccccnode = cccccnode.SelectSingleNode("location");
            XmlNodeList xnl = ccccccnode.SelectNodes("data");

            foreach (XmlNode xn in xnl)
            {
               string tmn = xn.SelectSingleNode("tmn").InnerText;
               string tmx = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(tmx);
                WeatherManager wm = new WeatherManager();
               string result = wm.method(tem, 0.5);
                
                result2.Add(tmn);
                result2.Add(tmx);
                result2.Add(result);
            }
            return result2;
        }
        private static List<string> seoul()
        {
            List<string> result2 = new List<string>();

            String strUrl = "http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=109";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(strUrl);

            XmlNode cnode = xdoc.SelectSingleNode("rss");
            XmlNode ccnode = cnode.SelectSingleNode("channel");
            XmlNode cccnode = ccnode.SelectSingleNode("item");
            XmlNode ccccnode = cccnode.SelectSingleNode("description");
            XmlNode cccccnode = ccccnode.SelectSingleNode("body");
            XmlNode ccccccnode = cccccnode.SelectSingleNode("location");
            XmlNodeList xnl = ccccccnode.SelectNodes("data");

            foreach (XmlNode xn in xnl)
            {
                string tmn = xn.SelectSingleNode("tmn").InnerText;
                string tmx = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(tmx);
                WeatherManager wm = new WeatherManager();
                string result = wm.method(tem, 0.5);

                result2.Add(tmn);
                result2.Add(tmx);
                result2.Add(result);
            }
            return result2;
        }
        private static List<string> chungnam()
        {
            List<string> result2 = new List<string>();

            String strUrl = "http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=133";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(strUrl);

            XmlNode cnode = xdoc.SelectSingleNode("rss");
            XmlNode ccnode = cnode.SelectSingleNode("channel");
            XmlNode cccnode = ccnode.SelectSingleNode("item");
            XmlNode ccccnode = cccnode.SelectSingleNode("description");
            XmlNode cccccnode = ccccnode.SelectSingleNode("body");
            XmlNode ccccccnode = cccccnode.SelectSingleNode("location");
            XmlNodeList xnl = ccccccnode.SelectNodes("data");

            foreach (XmlNode xn in xnl)
            {
                string tmn = xn.SelectSingleNode("tmn").InnerText;
                string tmx = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(tmx);
                WeatherManager wm = new WeatherManager();
                string result = wm.method(tem, 0.5);

                result2.Add(tmn);
                result2.Add(tmx);
                result2.Add(result);
            }
            return result2;
        }
        private static List<string> chungbuk()
        {
            List<string> result2 = new List<string>();

            String strUrl = "http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=131";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(strUrl);

            XmlNode cnode = xdoc.SelectSingleNode("rss");
            XmlNode ccnode = cnode.SelectSingleNode("channel");
            XmlNode cccnode = ccnode.SelectSingleNode("item");
            XmlNode ccccnode = cccnode.SelectSingleNode("description");
            XmlNode cccccnode = ccccnode.SelectSingleNode("body");
            XmlNode ccccccnode = cccccnode.SelectSingleNode("location");
            XmlNodeList xnl = ccccccnode.SelectNodes("data");

            foreach (XmlNode xn in xnl)
            {
                string tmn = xn.SelectSingleNode("tmn").InnerText;
                string tmx = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(tmx);
                WeatherManager wm = new WeatherManager();
                string result = wm.method(tem, 0.5);

                result2.Add(tmn);
                result2.Add(tmx);
                result2.Add(result);
            }
            return result2;
        }
        private static List<string> gangwondo()
        {
            List<string> result2 = new List<string>();

            String strUrl = "http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=105";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(strUrl);

            XmlNode cnode = xdoc.SelectSingleNode("rss");
            XmlNode ccnode = cnode.SelectSingleNode("channel");
            XmlNode cccnode = ccnode.SelectSingleNode("item");
            XmlNode ccccnode = cccnode.SelectSingleNode("description");
            XmlNode cccccnode = ccccnode.SelectSingleNode("body");
            XmlNode ccccccnode = cccccnode.SelectSingleNode("location");
            XmlNodeList xnl = ccccccnode.SelectNodes("data");

            foreach (XmlNode xn in xnl)
            {
                string tmn = xn.SelectSingleNode("tmn").InnerText;
                string tmx = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(tmx);
                WeatherManager wm = new WeatherManager();
                string result = wm.method(tem, 0.5);

                result2.Add(tmn);
                result2.Add(tmx);
                result2.Add(result);
            }
            return result2;
        }
        private static List<string> jeju()
        {
            List<string> result2 = new List<string>();

            String strUrl = "http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=184";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(strUrl);

            XmlNode cnode = xdoc.SelectSingleNode("rss");
            XmlNode ccnode = cnode.SelectSingleNode("channel");
            XmlNode cccnode = ccnode.SelectSingleNode("item");
            XmlNode ccccnode = cccnode.SelectSingleNode("description");
            XmlNode cccccnode = ccccnode.SelectSingleNode("body");
            XmlNode ccccccnode = cccccnode.SelectSingleNode("location");
            XmlNodeList xnl = ccccccnode.SelectNodes("data");

            foreach (XmlNode xn in xnl)
            {
                string tmn = xn.SelectSingleNode("tmn").InnerText;
                string tmx = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(tmx);
                WeatherManager wm = new WeatherManager();
                string result = wm.method(tem, 0.5);

                result2.Add(tmn);
                result2.Add(tmx);
                result2.Add(result);
            }
            return result2;
        }
        private static List<string> jeonnam()
        {
            List<string> result2 = new List<string>();

            String strUrl = "http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=156";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(strUrl);

            XmlNode cnode = xdoc.SelectSingleNode("rss");
            XmlNode ccnode = cnode.SelectSingleNode("channel");
            XmlNode cccnode = ccnode.SelectSingleNode("item");
            XmlNode ccccnode = cccnode.SelectSingleNode("description");
            XmlNode cccccnode = ccccnode.SelectSingleNode("body");
            XmlNode ccccccnode = cccccnode.SelectSingleNode("location");
            XmlNodeList xnl = ccccccnode.SelectNodes("data");

            foreach (XmlNode xn in xnl)
            {
                string tmn = xn.SelectSingleNode("tmn").InnerText;
                string tmx = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(tmx);
                WeatherManager wm = new WeatherManager();
                string result = wm.method(tem, 0.5);

                result2.Add(tmn);
                result2.Add(tmx);
                result2.Add(result);
            }
            return result2;
        }
        private static List<string> jeonbuk()
        {
            List<string> result2 = new List<string>();

            String strUrl = "http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=146";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(strUrl);

            XmlNode cnode = xdoc.SelectSingleNode("rss");
            XmlNode ccnode = cnode.SelectSingleNode("channel");
            XmlNode cccnode = ccnode.SelectSingleNode("item");
            XmlNode ccccnode = cccnode.SelectSingleNode("description");
            XmlNode cccccnode = ccccnode.SelectSingleNode("body");
            XmlNode ccccccnode = cccccnode.SelectSingleNode("location");
            XmlNodeList xnl = ccccccnode.SelectNodes("data");

            foreach (XmlNode xn in xnl)
            {
                string tmn = xn.SelectSingleNode("tmn").InnerText;
                string tmx = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(tmx);
                WeatherManager wm = new WeatherManager();
                string result = wm.method(tem, 0.5);

                result2.Add(tmn);
                result2.Add(tmx);
                result2.Add(result);
            }
            return result2;
        }
        private static List<string> kyungnam()
        {
            List<string> result2 = new List<string>();

            String strUrl = "http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=159";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(strUrl);

            XmlNode cnode = xdoc.SelectSingleNode("rss");
            XmlNode ccnode = cnode.SelectSingleNode("channel");
            XmlNode cccnode = ccnode.SelectSingleNode("item");
            XmlNode ccccnode = cccnode.SelectSingleNode("description");
            XmlNode cccccnode = ccccnode.SelectSingleNode("body");
            XmlNode ccccccnode = cccccnode.SelectSingleNode("location");
            XmlNodeList xnl = ccccccnode.SelectNodes("data");

            foreach (XmlNode xn in xnl)
            {
                string tmn = xn.SelectSingleNode("tmn").InnerText;
                string tmx = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(tmx);
                WeatherManager wm = new WeatherManager();
                string result = wm.method(tem, 0.5);

                result2.Add(tmn);
                result2.Add(tmx);
                result2.Add(result);
            }
            return result2;
        }
        private static List<string> kyungbuk()
        {
            List<string> result2 = new List<string>();

            String strUrl = "http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=143";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(strUrl);

            XmlNode cnode = xdoc.SelectSingleNode("rss");
            XmlNode ccnode = cnode.SelectSingleNode("channel");
            XmlNode cccnode = ccnode.SelectSingleNode("item");
            XmlNode ccccnode = cccnode.SelectSingleNode("description");
            XmlNode cccccnode = ccccnode.SelectSingleNode("body");
            XmlNode ccccccnode = cccccnode.SelectSingleNode("location");
            XmlNodeList xnl = ccccccnode.SelectNodes("data");

            foreach (XmlNode xn in xnl)
            {
                string tmn = xn.SelectSingleNode("tmn").InnerText;
                string tmx = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(tmx);
                WeatherManager wm = new WeatherManager();
                string result = wm.method(tem, 0.5);

                result2.Add(tmn);
                result2.Add(tmx);
                result2.Add(result);
            }
            return result2;
        }

    }
}
