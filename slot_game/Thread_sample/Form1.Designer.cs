namespace Thread_sample
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStop1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop2 = new System.Windows.Forms.Button();
            this.buttonStop3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ＭＳ ゴシック", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(184, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 60);
            this.label1.TabIndex = 1;
            this.label1.Text = "0";
            // 
            // buttonStop1
            // 
            this.buttonStop1.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonStop1.Location = new System.Drawing.Point(51, 195);
            this.buttonStop1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStop1.Name = "buttonStop1";
            this.buttonStop1.Size = new System.Drawing.Size(260, 95);
            this.buttonStop1.TabIndex = 2;
            this.buttonStop1.Text = "Stop";
            this.buttonStop1.UseVisualStyleBackColor = true;
            this.buttonStop1.Click += new System.EventHandler(this.buttonStop1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("ＭＳ ゴシック", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(479, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 60);
            this.label2.TabIndex = 3;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("ＭＳ ゴシック", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(829, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 60);
            this.label3.TabIndex = 4;
            this.label3.Text = "0";
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonStart.Location = new System.Drawing.Point(385, 399);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(260, 95);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonStop2
            // 
            this.buttonStop2.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonStop2.Location = new System.Drawing.Point(385, 195);
            this.buttonStop2.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStop2.Name = "buttonStop2";
            this.buttonStop2.Size = new System.Drawing.Size(260, 95);
            this.buttonStop2.TabIndex = 5;
            this.buttonStop2.Text = "Stop";
            this.buttonStop2.UseVisualStyleBackColor = true;
            this.buttonStop2.Click += new System.EventHandler(this.buttonStop2_Click);
            // 
            // buttonStop3
            // 
            this.buttonStop3.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonStop3.Location = new System.Drawing.Point(728, 195);
            this.buttonStop3.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStop3.Name = "buttonStop3";
            this.buttonStop3.Size = new System.Drawing.Size(260, 95);
            this.buttonStop3.TabIndex = 6;
            this.buttonStop3.Text = "Stop";
            this.buttonStop3.UseVisualStyleBackColor = true;
            this.buttonStop3.Click += new System.EventHandler(this.buttonStop3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.buttonStop3);
            this.Controls.Add(this.buttonStop2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonStop1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStop1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop2;
        private System.Windows.Forms.Button buttonStop3;
    }
}

