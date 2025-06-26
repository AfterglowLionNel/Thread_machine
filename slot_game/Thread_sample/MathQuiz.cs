using System;
using System.Windows.Forms;

namespace Thread_sample
{
    public partial class MathQuizForm : Form
    {
        private int correctAnswer;

        public MathQuizForm()
        {
            InitializeComponent();
            GenerateProblem();
            // EnterキーでbuttonSubmitが押されるようにする
            this.AcceptButton = buttonSubmit;

            // 起動時にtextBoxにフォーカス
            this.Shown += (s, e) => textBoxAnswer.Focus();

            GenerateProblem();
        }

        private void GenerateProblem()
        {
            Random rnd = new Random();
            int a = rnd.Next(1, 10);
            int b = rnd.Next(1, 10);
            bool useMultiply = rnd.Next(2) == 0;

            if (useMultiply)
            {
                labelQuestion.Text = $"{a} × {b} = ?";
                correctAnswer = a * b;
            }
            else
            {
                labelQuestion.Text = $"{a} + {b} = ?";
                correctAnswer = a + b;
            }
        }



        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxAnswer.Text, out int answer))
            {
                if (answer == correctAnswer)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();  // 正解なら閉じる
                }
                else
                {
                    MessageBox.Show("不正解です。もう一度チャレンジしてください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxAnswer.Clear();
                    GenerateProblem();
                }
            }
            else
            {
                MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GenerateProblem();
            }
        }

        private void MathQuizForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // 枠ありだがサイズ固定
            this.MaximizeBox = false; // 最大化無効
            this.MinimizeBox = false; // 最小化無効（任意）

        }
    }
}
