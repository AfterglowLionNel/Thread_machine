using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thread_sample
{
    public partial class Form1 : Form
    {
        // スロットの回転状態を示すフラグ（3つ）
        private volatile bool isSpinning1 = false;
        private volatile bool isSpinning2 = false;
        private volatile bool isSpinning3 = false;

        public Form1()
        {
            InitializeComponent();

            // フォームがキー入力を先に受け取れるように設定
            this.KeyPreview = true;

            // イベント登録
            this.KeyDown += Form1_KeyDown;
            this.Shown += Form1_Shown;

            
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // クイズフォームをモーダル表示（閉じるまで進めない）
            using (var quiz = new MathQuizForm())
            {
                var result = quiz.ShowDialog();

                // 正解するまで閉じられない仕組みなので、ここでは特に何も不要
                // 逆にキャンセルなどされたらアプリ終了（セーフティ）
                if (result != DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        // フォーム表示直後にボタンのフォーカスを外す
        private void Form1_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        // キー入力処理（Enter = Start, Space = Stop, Esc = 終了）
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // すべて停止中ならスロット開始
                if (!isSpinning1 && !isSpinning2 && !isSpinning3)
                {
                    StartSlot1();
                    StartSlot2();
                    StartSlot3();
                }

                // Startボタンへのフォーカスを外す
                this.ActiveControl = null;
            }
            else if (e.KeyCode == Keys.Space)
            {
                // 回転中のスロットを順に停止
                if (isSpinning1)
                {
                    isSpinning1 = false;
                    this.BeginInvoke((MethodInvoker)(() => CheckAllStopped()));
                }
                else if (isSpinning2)
                {
                    isSpinning2 = false;
                    this.BeginInvoke((MethodInvoker)(() => CheckAllStopped()));
                }
                else if (isSpinning3)
                {
                    isSpinning3 = false;
                    this.BeginInvoke((MethodInvoker)(() => CheckAllStopped()));
                }

                this.ActiveControl = null;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                // ESCキーでアプリ終了
                this.Close();
            }
        }

        // スロット1の回転処理
        private void StartSlot1()
        {
            if (isSpinning1) return;
            isSpinning1 = true;

            Task.Run(() =>
            {
                Random rnd = new Random();
                while (isSpinning1)
                {
                    if (this.IsDisposed || !this.IsHandleCreated) break;

                    try
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            label1.Text = rnd.Next(0, 4).ToString();
                        }));
                    }
                    catch { break; }

                    Thread.Sleep(50);
                }

                isSpinning1 = false;
            });
        }

        // スロット2の回転処理
        private void StartSlot2()
        {
            if (isSpinning2) return;
            isSpinning2 = true;

            Task.Run(() =>
            {
                Random rnd = new Random();
                while (isSpinning2)
                {
                    if (this.IsDisposed || !this.IsHandleCreated) break;

                    try
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            label2.Text = rnd.Next(0, 4).ToString();
                        }));
                    }
                    catch { break; }

                    Thread.Sleep(50);
                }

                isSpinning2 = false;
            });
        }

        // スロット3の回転処理
        private void StartSlot3()
        {
            if (isSpinning3) return;
            isSpinning3 = true;

            Task.Run(() =>
            {
                Random rnd = new Random();
                while (isSpinning3)
                {
                    if (this.IsDisposed || !this.IsHandleCreated) break;

                    try
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            label3.Text = rnd.Next(0, 4).ToString();
                        }));
                    }
                    catch { break; }

                    Thread.Sleep(50);
                }

                isSpinning3 = false;
            });
        }

        // フォームを閉じるとき、すべてのスロットを強制停止
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isSpinning1 = false;
            isSpinning2 = false;
            isSpinning3 = false;
        }

        // ボタンクリックによるスロット停止（今は未使用）
        private void buttonStop1_Click(object sender, EventArgs e)
        {
            isSpinning1 = false;
            CheckAllStopped();
        }

        private void buttonStop2_Click(object sender, EventArgs e)
        {
            isSpinning2 = false;
            CheckAllStopped();
        }

        private void buttonStop3_Click(object sender, EventArgs e)
        {
            isSpinning3 = false;
            CheckAllStopped();
        }

        // すべてのスロットが停止したときに当たり判定を行う
        private void CheckAllStopped()
        {
            if (!isSpinning1 && !isSpinning2 && !isSpinning3)
            {
                if (label1.Text == label2.Text && label2.Text == label3.Text)
                {
                    MessageBox.Show("あたり！");
                }

                // 再度フォームにフォーカスを戻す
                this.ActiveControl = null;
            }
        }
    }
}
