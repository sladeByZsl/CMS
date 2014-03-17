using System;
using System.IO;
using System.Text;
using System.Timers;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(1000); //间隔10秒
            timer.Elapsed += WriteSomething;
            timer.AutoReset = true;
            timer.Start();
            WriteStr();
            //Console.ReadKey();
        }

        private static void WriteStr()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(@"D:\test.txt", FileMode.OpenOrCreate);
                //获得字节数组
                string sss = DateTime.Now.ToString();
                byte[] data = new UTF8Encoding().GetBytes(sss);
                //开始写入
                fs.Write(data, 0, data.Length);

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
        }

        private static void WriteSomething(object sender, ElapsedEventArgs e)
        {
            //Console.WriteLine(DateTime.Now.ToString());

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
        }
    }
}
