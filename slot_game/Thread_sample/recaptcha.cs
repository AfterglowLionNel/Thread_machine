using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thread_sample
{
    public partial class recaptcha : Form
    {
        private bool captchaPassed = false; // 状態フラグ

        public recaptcha()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(550, 150);

            // チェックボックスのイベントハンドラ
            checkBox1.Click += async (s, e) =>
            {
                // すでに認証済みの場合は何もしない
                if (captchaPassed)
                {
                    return;
                }

                this.Hide();

                using (var captchaForm = new ImageCaptchaForm())
                {
                    var result = captchaForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        captchaPassed = true; // 認証済み状態にする
                        checkBox1.Checked = true;
                        this.Show();

                        await Task.Delay(5000);

                        var quizForm = new MathQuizForm();
                        quizForm.Show();

                        this.Hide(); // recaptchaは閉じる
                    }
                    else
                    {
                        checkBox1.Checked = false;
                        this.Show();
                    }
                }
            };
        }
    }
}
