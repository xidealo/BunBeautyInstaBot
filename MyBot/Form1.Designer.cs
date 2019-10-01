namespace MyBot
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PassTB = new System.Windows.Forms.TextBox();
            this.EmailTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.TB_tags = new System.Windows.Forms.TextBox();
            this.TB_count_likes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RepetNmbr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PassTB
            // 
            this.PassTB.Location = new System.Drawing.Point(150, 113);
            this.PassTB.Name = "PassTB";
            this.PassTB.Size = new System.Drawing.Size(180, 20);
            this.PassTB.TabIndex = 8;
            this.PassTB.TextChanged += new System.EventHandler(this.PassTB_TextChanged);
            // 
            // EmailTB
            // 
            this.EmailTB.Location = new System.Drawing.Point(150, 87);
            this.EmailTB.Name = "EmailTB";
            this.EmailTB.Size = new System.Drawing.Size(180, 20);
            this.EmailTB.TabIndex = 9;
            this.EmailTB.Text = "bun.beauty2019@gmail.com";
            this.EmailTB.TextChanged += new System.EventHandler(this.EmailTB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "email/login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "pass";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FloralWhite;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button8.Location = new System.Drawing.Point(150, 139);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(137, 23);
            this.button8.TabIndex = 12;
            this.button8.Text = "Бот инстаграмма";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // TB_tags
            // 
            this.TB_tags.Location = new System.Drawing.Point(150, 168);
            this.TB_tags.Name = "TB_tags";
            this.TB_tags.Size = new System.Drawing.Size(287, 20);
            this.TB_tags.TabIndex = 13;
            this.TB_tags.Text = "#Дубна";
            this.TB_tags.TextChanged += new System.EventHandler(this.TB_tags_TextChanged);
            // 
            // TB_count_likes
            // 
            this.TB_count_likes.Location = new System.Drawing.Point(150, 207);
            this.TB_count_likes.Name = "TB_count_likes";
            this.TB_count_likes.Size = new System.Drawing.Size(67, 20);
            this.TB_count_likes.TabIndex = 14;
            this.TB_count_likes.Text = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "tags";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "likes on tags";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(261, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Пример: #girl #girls #cute #Moscow #Russia #Black";
            // 
            // RepetNmbr
            // 
            this.RepetNmbr.Location = new System.Drawing.Point(150, 233);
            this.RepetNmbr.Name = "RepetNmbr";
            this.RepetNmbr.Size = new System.Drawing.Size(67, 20);
            this.RepetNmbr.TabIndex = 18;
            this.RepetNmbr.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "repet number";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(482, 303);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.RepetNmbr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_count_likes);
            this.Controls.Add(this.TB_tags);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EmailTB);
            this.Controls.Add(this.PassTB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox PassTB;
        private System.Windows.Forms.TextBox EmailTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox TB_tags;
        private System.Windows.Forms.TextBox TB_count_likes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox RepetNmbr;
        private System.Windows.Forms.Label label6;
    }
}

