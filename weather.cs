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

namespace Login
{
    public partial class weather : Form
    {
        

        public weather()
        {
            InitializeComponent();
        }

   

        public void button1_Click(object sender, EventArgs e)
        {
            String strUrl = "http://www.kma.go.kr/weather/forecast/mid-term-xml.jsp";
            textBox1.Text = strUrl;
            UriBuilder ub = new UriBuilder(strUrl);
            ub.Query = "stnld=109";
            HttpWebRequest request;
            request = HttpWebRequest.Create(ub.Uri) as HttpWebRequest;
            request.BeginGetResponse(new AsyncCallback(GetResponse), request);

        }

        
        public void GetResponse(IAsyncResult ar)
        {
            HttpWebRequest wr = (HttpWebRequest)ar.AsyncState;
            HttpWebResponse wp = (HttpWebResponse)wr.EndGetResponse(ar);
            Stream stream = wp.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            String strRead = reader.ReadToEnd();
            XElement xmlMain = XElement.Parse(strRead);
            XElement xmlHead = xmlMain.Descendants("header").First();
            String strTitle = xmlHead.Element("title").Value;
            String strDate = xmlHead.Element("tm").Value;
            String strDesc = xmlHead.Element("wf").Value;
            strDesc = strDesc.Replace("<br /><br />", "\n");
            String strTemp = strTitle + "\n" + strDate + "\n" + strDesc + "\n";
            
             textBox1.Text = strTemp;
            
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String strUrl = "http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=133";
            textBox1.Text = strUrl;
            UriBuilder ub = new UriBuilder(strUrl);
            ub.Query = "stnld=109";
            HttpWebRequest request;
            request = HttpWebRequest.Create(ub.Uri) as HttpWebRequest;
            request.BeginGetResponse(new AsyncCallback(GetResponse), request);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String strUrl = "http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=133";
            textBox1.Text = strUrl;
            UriBuilder ub = new UriBuilder(strUrl);
            ub.Query = "stnld=133";
            HttpWebRequest request;
            request = HttpWebRequest.Create(ub.Uri) as HttpWebRequest;
            request.BeginGetResponse(new AsyncCallback(GetResponse), request);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String strUrl = "http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=184";
            textBox1.Text = strUrl;
            UriBuilder ub = new UriBuilder(strUrl);
            ub.Query = "stnld=184";
            HttpWebRequest request;
            request = HttpWebRequest.Create(ub.Uri) as HttpWebRequest;
            request.BeginGetResponse(new AsyncCallback(GetResponse), request);
            
        }
    }
}
