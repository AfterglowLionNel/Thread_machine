using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Thread_sample
{
    public partial class ImageCaptchaForm : Form
    {
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        private List<(Bitmap Image, string Category)> imageResources = new List<(Bitmap, string)>();
        private HashSet<PictureBox> selectedBoxes = new HashSet<PictureBox>();
        private string currentQuestionCategory;
        private Random rnd = new Random();

        public ImageCaptchaForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Size = new Size(450, 730);
            this.StartPosition = FormStartPosition.CenterScreen;

            InitPictureBoxList();
            LoadImageResources();
            LoadQuestion();
        }

        private void InitPictureBoxList()
        {
            pictureBoxes.Add(pictureBox1);
            pictureBoxes.Add(pictureBox2);
            pictureBoxes.Add(pictureBox3);
            pictureBoxes.Add(pictureBox4);
            pictureBoxes.Add(pictureBox5);
            pictureBoxes.Add(pictureBox6);
            pictureBoxes.Add(pictureBox7);
            pictureBoxes.Add(pictureBox8);
            pictureBoxes.Add(pictureBox9);

            foreach (var pb in pictureBoxes)
            {
                pb.Click += PictureBox_Click;
                pb.Paint += PictureBox_Paint;
            }

            button1.Click += Button1_Click;
        }

        private void LoadImageResources()
        {
            imageResources.Clear();
            imageResources.Add((Properties.Resources.car_1, "car"));
            imageResources.Add((Properties.Resources.car_2, "car"));
            imageResources.Add((Properties.Resources.car_3, "car"));
            imageResources.Add((Properties.Resources.car_4, "car"));
            imageResources.Add((Properties.Resources.car_5, "car"));
            imageResources.Add((Properties.Resources.car_6, "car"));
            imageResources.Add((Properties.Resources.car_7, "car"));
            imageResources.Add((Properties.Resources.bike_1, "bike"));
            imageResources.Add((Properties.Resources.bike_2, "bike"));
            imageResources.Add((Properties.Resources.traffic_1, "traffic"));
            imageResources.Add((Properties.Resources.traffic_2, "traffic"));
            imageResources.Add((Properties.Resources.traffic_3, "traffic"));
        }

        private void LoadQuestion()
        {
            var selectedImages = imageResources.OrderBy(x => rnd.Next()).Take(9).ToList();

            for (int i = 0; i < 9; i++)
            {
                pictureBoxes[i].Image = selectedImages[i].Image;
                pictureBoxes[i].Tag = selectedImages[i].Category;
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxes[i].Invalidate();
            }

            selectedBoxes.Clear();

            var categories = new List<string> { "car", "bike", "traffic" };
            currentQuestionCategory = categories[rnd.Next(categories.Count)];

            switch (currentQuestionCategory)
            {
                case "car":
                    label1.Text = "車の画像を選択してください";
                    break;
                case "bike":
                    label1.Text = "バイクの画像を選択してください";
                    break;
                case "traffic":
                    label1.Text = "信号の画像を選択してください";
                    break;
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            var pb = sender as PictureBox;
            if (pb == null) return;

            if (selectedBoxes.Contains(pb))
                selectedBoxes.Remove(pb);
            else
                selectedBoxes.Add(pb);

            pb.Invalidate();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            var pb = sender as PictureBox;
            if (pb != null && selectedBoxes.Contains(pb))
            {
                using (Pen bluePen = new Pen(Color.Blue, 4))
                {
                    e.Graphics.DrawRectangle(bluePen, new Rectangle(0, 0, pb.Width - 1, pb.Height - 1));
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var correctBoxes = pictureBoxes.Where(pb => (string)pb.Tag == currentQuestionCategory).ToList();
            bool isAllCorrect = selectedBoxes.SetEquals(correctBoxes);

            if (isAllCorrect)
            {
                this.DialogResult = DialogResult.OK;
                this.Close(); // 正解時は閉じる（呼び出し元が次に進む）
            }
            else
            {
                LoadQuestion(); // 間違い → 別問題を再表示
            }
        }
    }
}
