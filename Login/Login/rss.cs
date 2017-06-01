using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Rss : Form
    {
        public Rss()
        {
            InitializeComponent();
        }

        String[,] rssData = null;

        private String[,] getRssData(String channel)
        {
            System.Net.WebRequest myRequest = System.Net.WebRequest.Create(channel);
            System.Net.WebResponse myResponse = myRequest.GetResponse();

            System.IO.Stream rssStream = myResponse.GetResponseStream();
            System.Xml.XmlDocument rssDoc = new System.Xml.XmlDocument();

            rssDoc.Load(rssStream);

            System.Xml.XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");

            String[,] tempRssData = new String[100, 3];

            for(int i= 0; i< rssItems.Count; i++)
            {
                System.Xml.XmlNode rssNode;

                rssNode = rssItems.Item(i).SelectSingleNode("title");
                if (rssNode != null)
                {
                    tempRssData[i, 0] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 0] = "";
                }

                rssNode = rssItems.Item(i).SelectSingleNode("description");
                if (rssNode != null)
                {
                    tempRssData[i, 1] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 1] = "";
                }

                rssNode = rssItems.Item(i).SelectSingleNode("link");
                if (rssNode != null)
                {
                    tempRssData[i, 2] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 2] = "";
                }

            }
            return tempRssData;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            titleCombobox.Items.Clear();
            rssData = getRssData(channelTextbox.Text);
            for (int i = 0; i< rssData.GetLength(0); i++)
            {
                if(rssData[i, 0] != null)
                {
                    titleCombobox.Items.Add(rssData[i, 0]);
                }
                titleCombobox.SelectedIndex = 0;
            }
        }

        private void titleCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rssData[titleCombobox.SelectedIndex, 1] != null)
            {
                descriptionTextbox.Text = rssData[titleCombobox.SelectedIndex, 1];
                
            }
            if(rssData[titleCombobox.SelectedIndex, 2] != null)
            {
                linkLabel.Text = "GoTo: " + rssData[titleCombobox.SelectedIndex, 0];
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(rssData[titleCombobox.SelectedIndex, 2] != null)
            {
                System.Diagnostics.Process.Start(rssData[titleCombobox.SelectedIndex, 2]);
            }
        }
    }
}
