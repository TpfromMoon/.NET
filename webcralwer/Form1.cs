using homework5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webcralwer
{
    public partial class Form1 : Form
    {
        SimpleCrawler simplecrawler = new SimpleCrawler();
        BindingSource bindingSource = new BindingSource();
        Thread thread = null;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = bindingSource;
            simplecrawler.PageDownload += crawlerPagedl;
            simplecrawler.CrawlerStop += crawlerStop;
        }

        private void crawlerPagedl(SimpleCrawler crawler,int index,string url,string status)
        {
            var PageStatus = new { Index = index, Url = url, Status = status };
            Action action = () => { bindingSource.Add(PageStatus); };
            if(this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }
        private void crawlerStop(SimpleCrawler crawler)
        {
            Action action = () => lbStatus.Text = "爬取结束";
            if(this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource.Clear();
            simplecrawler.StartURL = tBUrl.Text;
            Match match = Regex.Match(simplecrawler.StartURL, SimpleCrawler.urlParseRegex);
            if (match.Length == 0)
                return;
            string host = match.Groups["host"].Value;
            simplecrawler.HostFilter = "^" + host + "$";
            simplecrawler.FileFilter = ".html?$";
            if(thread!=null)
            {
                thread.Abort();
            }
            thread = new Thread(simplecrawler.Start);
            thread.Start();
            lbStatus.Text = "正在爬取";
        }
    }
}
