using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Windows.Threading;
using System.Windows.Data;
using System.Windows.Media;
using System.Media;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class weather : Form
    {


        public weather()
        {
            InitializeComponent();
        }

        /*
        public void GetResponse(IAsyncResult ar)
        {
            HttpWebRequest wr = (HttpWebRequest)ar.AsyncState;
            HttpWebResponse wp = (HttpWebResponse)wr.EndGetResponse(ar);
            Stream stream = wp.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            String strRead = reader.ReadToEnd();
            XElement xmlMain = XElement.Parse(strRead);
            XElement xmlHead = xmlMain.Descendants("body").First();
            String strTitle = xmlHead.Element("data").Value;
            String strDate = xmlHead.Element("tmn").Value;
            String strDesc = xmlHead.Element("tmx").Value;
            strDesc = strDesc.Replace("<data/></data>", "\n");
            String strTemp = strTitle + "\n" + strDate + "\n" + strDesc + "\n";

            CheckForIllegalCrossThreadCalls = false;
            textBox1.Text = strTemp;
        }
        */

        private void button2_Click(object sender, EventArgs e)
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

            foreach (XmlNode xn in xnl)
            {
                textBox1.Text = xn.SelectSingleNode("tmn").InnerText;
                textBox2.Text = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(textBox1.Text);
                WeatherManager wm = new WeatherManager();
                textBox3.Text = wm.method(tem, 0.5);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
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
                textBox1.Text = xn.SelectSingleNode("tmn").InnerText;
                textBox2.Text = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(textBox1.Text);
                WeatherManager wm = new WeatherManager();
                textBox3.Text = wm.method(tem, 0.5);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
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
                textBox1.Text = xn.SelectSingleNode("tmn").InnerText;
                textBox2.Text = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(textBox1.Text);
                WeatherManager wm = new WeatherManager();
                textBox3.Text = wm.method(tem, 0.5);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
                textBox1.Text = xn.SelectSingleNode("tmn").InnerText;
                textBox2.Text = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(textBox1.Text);
                WeatherManager wm = new WeatherManager();
                textBox3.Text = wm.method(tem, 0.5);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
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
                textBox1.Text = xn.SelectSingleNode("tmn").InnerText;
                textBox2.Text = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(textBox1.Text);
                WeatherManager wm = new WeatherManager();
                textBox3.Text = wm.method(tem, 0.5);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
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
                textBox1.Text = xn.SelectSingleNode("tmn").InnerText;
                textBox2.Text = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(textBox1.Text);
                WeatherManager wm = new WeatherManager();
                textBox3.Text = wm.method(tem, 0.5);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
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
                textBox1.Text = xn.SelectSingleNode("tmn").InnerText;
                textBox2.Text = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(textBox1.Text);
                WeatherManager wm = new WeatherManager();
                textBox3.Text = wm.method(tem, 0.5);
            }
        }

        private void weather_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void button1_Click_1(object sender, EventArgs e)
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

            foreach (XmlNode xn in xnl)
            {
                textBox1.Text = xn.SelectSingleNode("tmn").InnerText;
                textBox2.Text = xn.SelectSingleNode("tmx").InnerText;
                int tem = int.Parse(textBox1.Text);
                WeatherManager wm = new WeatherManager();
                textBox3.Text = wm.method(tem , 0.5);
            }

            
         
        }
    }
}
