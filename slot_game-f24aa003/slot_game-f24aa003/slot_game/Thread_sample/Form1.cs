using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Thread_sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static bool stop_flg = true;

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            stop_flg = true;

            Task.Run(() =>  // こう書くだけで、並行して処理が行われる
            {
                while (stop_flg)
                {
                    Thread.Sleep(10); // 一定間隔で処理を中断

                    label1.Text = (rnd.Next(0, 9)).ToString(); // ランダムに表示数値を変更
                }
            });

        }

        private void button2_Click(object sender, EventArgs e)
        {
            stop_flg = false;
        }
    }
}
