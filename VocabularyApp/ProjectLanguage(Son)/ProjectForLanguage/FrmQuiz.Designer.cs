namespace ProjectForLanguage
{
    partial class FrmQuiz
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQuestionNumber = new System.Windows.Forms.Label();
            this.lblWord = new System.Windows.Forms.Label();
            this.btnA = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblExampleSentence = new System.Windows.Forms.Label();
            this.pictureBoxWordImage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCorrectCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblWrongCount = new System.Windows.Forms.Label();
            this.pictureBoxWrong = new System.Windows.Forms.PictureBox();
            this.pictureBoxCorrect = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWordImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWrong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCorrect)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(93, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Soru No:";
            // 
            // lblQuestionNumber
            // 
            this.lblQuestionNumber.AutoSize = true;
            this.lblQuestionNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblQuestionNumber.Location = new System.Drawing.Point(225, 27);
            this.lblQuestionNumber.Name = "lblQuestionNumber";
            this.lblQuestionNumber.Size = new System.Drawing.Size(30, 32);
            this.lblQuestionNumber.TabIndex = 1;
            this.lblQuestionNumber.Text = "0";
            // 
            // lblWord
            // 
            this.lblWord.AutoSize = true;
            this.lblWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWord.Location = new System.Drawing.Point(206, 237);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(129, 32);
            this.lblWord.TabIndex = 2;
            this.lblWord.Text = "Question";
            // 
            // btnA
            // 
            this.btnA.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnA.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.btnA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnA.Location = new System.Drawing.Point(84, 316);
            this.btnA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(171, 62);
            this.btnA.TabIndex = 3;
            this.btnA.Text = "button1";
            this.btnA.UseVisualStyleBackColor = false;
            // 
            // btnB
            // 
            this.btnB.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnB.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.btnB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnB.Location = new System.Drawing.Point(311, 317);
            this.btnB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(171, 62);
            this.btnB.TabIndex = 4;
            this.btnB.Text = "button2";
            this.btnB.UseVisualStyleBackColor = false;
            // 
            // btnC
            // 
            this.btnC.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnC.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.btnC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnC.Location = new System.Drawing.Point(84, 418);
            this.btnC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(171, 62);
            this.btnC.TabIndex = 5;
            this.btnC.Text = "button3";
            this.btnC.UseVisualStyleBackColor = false;
            // 
            // btnD
            // 
            this.btnD.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnD.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.btnD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnD.Location = new System.Drawing.Point(311, 418);
            this.btnD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(171, 62);
            this.btnD.TabIndex = 6;
            this.btnD.Text = "button4";
            this.btnD.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBack.Location = new System.Drawing.Point(12, 17);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(45, 42);
            this.btnBack.TabIndex = 33;
            this.btnBack.Text = "←";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblExampleSentence
            // 
            this.lblExampleSentence.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblExampleSentence.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblExampleSentence.Location = new System.Drawing.Point(579, 446);
            this.lblExampleSentence.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExampleSentence.Name = "lblExampleSentence";
            this.lblExampleSentence.Size = new System.Drawing.Size(342, 137);
            this.lblExampleSentence.TabIndex = 36;
            this.lblExampleSentence.Text = "label2";
            this.lblExampleSentence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxWordImage
            // 
            this.pictureBoxWordImage.Location = new System.Drawing.Point(1016, 422);
            this.pictureBoxWordImage.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxWordImage.Name = "pictureBoxWordImage";
            this.pictureBoxWordImage.Size = new System.Drawing.Size(13, 90);
            this.pictureBoxWordImage.TabIndex = 35;
            this.pictureBoxWordImage.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ProjectForLanguage.Properties.Resources.quiz;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(84, 63);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(348, 170);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(509, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 32);
            this.label2.TabIndex = 37;
            this.label2.Text = "Doğru Sayısı:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblCorrectCount
            // 
            this.lblCorrectCount.AutoSize = true;
            this.lblCorrectCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCorrectCount.Location = new System.Drawing.Point(698, 54);
            this.lblCorrectCount.Name = "lblCorrectCount";
            this.lblCorrectCount.Size = new System.Drawing.Size(30, 32);
            this.lblCorrectCount.TabIndex = 38;
            this.lblCorrectCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(509, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 32);
            this.label4.TabIndex = 39;
            this.label4.Text = "Yanlış Sayısı:";
            // 
            // lblWrongCount
            // 
            this.lblWrongCount.AutoSize = true;
            this.lblWrongCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWrongCount.Location = new System.Drawing.Point(698, 106);
            this.lblWrongCount.Name = "lblWrongCount";
            this.lblWrongCount.Size = new System.Drawing.Size(30, 32);
            this.lblWrongCount.TabIndex = 40;
            this.lblWrongCount.Text = "0";
            // 
            // pictureBoxWrong
            // 
            this.pictureBoxWrong.BackgroundImage = global::ProjectForLanguage.Properties.Resources.quiz;
            this.pictureBoxWrong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxWrong.Image = global::ProjectForLanguage.Properties.Resources.camp_dayz_no;
            this.pictureBoxWrong.Location = new System.Drawing.Point(748, 38);
            this.pictureBoxWrong.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxWrong.Name = "pictureBoxWrong";
            this.pictureBoxWrong.Size = new System.Drawing.Size(173, 151);
            this.pictureBoxWrong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxWrong.TabIndex = 41;
            this.pictureBoxWrong.TabStop = false;
            // 
            // pictureBoxCorrect
            // 
            this.pictureBoxCorrect.BackgroundImage = global::ProjectForLanguage.Properties.Resources.quiz;
            this.pictureBoxCorrect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCorrect.Image = global::ProjectForLanguage.Properties.Resources.green;
            this.pictureBoxCorrect.Location = new System.Drawing.Point(748, 38);
            this.pictureBoxCorrect.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxCorrect.Name = "pictureBoxCorrect";
            this.pictureBoxCorrect.Size = new System.Drawing.Size(173, 151);
            this.pictureBoxCorrect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCorrect.TabIndex = 42;
            this.pictureBoxCorrect.TabStop = false;
            // 
            // FrmQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 667);
            this.Controls.Add(this.pictureBoxCorrect);
            this.Controls.Add(this.pictureBoxWrong);
            this.Controls.Add(this.lblWrongCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCorrectCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblExampleSentence);
            this.Controls.Add(this.pictureBoxWordImage);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.lblWord);
            this.Controls.Add(this.lblQuestionNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmQuiz";
            this.Text = "Quiz";
            this.Load += new System.EventHandler(this.FrmQuiz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWordImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWrong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCorrect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQuestionNumber;
        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxWordImage;
        private System.Windows.Forms.Label lblExampleSentence;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCorrectCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblWrongCount;
        private System.Windows.Forms.PictureBox pictureBoxWrong;
        private System.Windows.Forms.PictureBox pictureBoxCorrect;
    }
}