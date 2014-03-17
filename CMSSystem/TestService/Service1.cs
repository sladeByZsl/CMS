using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace TestService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //服务开启执行代码

            StartDoSomething();

            while (true)
            {

            }
        }
        protected override void OnStop()
        {
            //服务结束执行代码
        }
        protected override void OnPause()
        {
            //服务暂停执行代码
            base.OnPause();
        }
        protected override void OnContinue()
        {
            //服务恢复执行代码
            base.OnContinue();
        }
        protected override void OnShutdown()
        {
            //系统即将关闭执行代码
            base.OnShutdown();
        }
        private void StartDoSomething()
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000); //间隔10秒
            timer.AutoReset = true;
            timer.Enabled = false;  //执行一次
            timer.Elapsed += new ElapsedEventHandler(WriteSomething);
            timer.Start();
            
        }
        private void WriteSomething(object sender, ElapsedEventArgs e)
        {
            StreamWriter fs = null;
            try
            {
                fs = File.AppendText(@"D:\test.txt");
                //获得字节数组
                string sss = DateTime.Now.ToString();
                fs.Flush();
                fs.WriteLine(sss);
                //byte[] data = new UTF8Encoding().GetBytes(sss);
                ////开始写入
                //fs.Write(data, 0, data.Length);


                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();
            }
            catch
            {
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
            
            //FileStream fs = null;
            //try
            //{
            //    fs = new FileStream(@"D:\test.txt", FileMode.OpenOrCreate);
            //    //获得字节数组
            //    string sss = DateTime.Now.ToString();
            //    byte[] data = new UTF8Encoding().GetBytes(sss);
            //    //开始写入
            //    fs.Write(data, 0, data.Length);

            //    //清空缓冲区、关闭流
            //    fs.Flush();
            //    fs.Close();
            //}
            //catch
            //{
            //}
            //finally
            //{
            //    if (fs != null)
            //    {
            //        fs.Close();
            //        fs.Dispose();
            //    }
            //}
        }
    }
}
