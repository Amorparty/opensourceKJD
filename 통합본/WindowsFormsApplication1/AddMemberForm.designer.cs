namespace WindowsFormsApplication1
{
    partial class AddMemberForm
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
            this.tb_pw = new System.Windows.Forms.TextBox();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.lb_pw = new System.Windows.Forms.Label();
            this.lb_id = new System.Windows.Forms.Label();
            this.btn_check = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.tb_pw2 = new System.Windows.Forms.TextBox();
            this.lb_pw2 = new System.Windows.Forms.Label();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_age = new System.Windows.Forms.TextBox();
            this.tb_sex = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tb_pw
            // 
            this.tb_pw.Location = new System.Drawing.Point(77, 33);
            this.tb_pw.Name = "tb_pw";
            this.tb_pw.PasswordChar = '*';
            this.tb_pw.Size = new System.Drawing.Size(104, 21);
            this.tb_pw.TabIndex = 11;
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(77, 6);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(104, 21);
            this.tb_id.TabIndex = 10;
            // 
            // lb_pw
            // 
            this.lb_pw.AutoSize = true;
            this.lb_pw.Location = new System.Drawing.Point(12, 36);
            this.lb_pw.Name = "lb_pw";
            this.lb_pw.Size = new System.Drawing.Size(31, 12);
            this.lb_pw.TabIndex = 9;
            this.lb_pw.Text = "PW :";
            // 
            // lb_id
            // 
            this.lb_id.AutoSize = true;
            this.lb_id.Location = new System.Drawing.Point(12, 9);
            this.lb_id.Name = "lb_id";
            this.lb_id.Size = new System.Drawing.Size(24, 12);
            this.lb_id.TabIndex = 8;
            this.lb_id.Text = "ID :";
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(197, 4);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(69, 23);
            this.btn_check.TabIndex = 7;
            this.btn_check.Text = "중복체크";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(106, 249);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 6;
            this.btn_add.Text = "가입";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // tb_pw2
            // 
            this.tb_pw2.Location = new System.Drawing.Point(77, 60);
            this.tb_pw2.Name = "tb_pw2";
            this.tb_pw2.PasswordChar = '*';
            this.tb_pw2.Size = new System.Drawing.Size(104, 21);
            this.tb_pw2.TabIndex = 13;
            // 
            // lb_pw2
            // 
            this.lb_pw2.AutoSize = true;
            this.lb_pw2.Location = new System.Drawing.Point(12, 63);
            this.lb_pw2.Name = "lb_pw2";
            this.lb_pw2.Size = new System.Drawing.Size(55, 12);
            this.lb_pw2.TabIndex = 12;
            this.lb_pw2.Text = "PW 확인:";
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(209, 249);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 14;
            this.btn_cancle.Text = "취소";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "이름 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "나이 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "성별 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "거주지 :";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(77, 89);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(104, 21);
            this.tb_name.TabIndex = 19;
            // 
            // tb_age
            // 
            this.tb_age.Location = new System.Drawing.Point(77, 118);
            this.tb_age.Name = "tb_age";
            this.tb_age.Size = new System.Drawing.Size(104, 21);
            this.tb_age.TabIndex = 20;
            // 
            // tb_sex
            // 
            this.tb_sex.Location = new System.Drawing.Point(77, 147);
            this.tb_sex.Name = "tb_sex";
            this.tb_sex.Size = new System.Drawing.Size(104, 21);
            this.tb_sex.TabIndex = 21;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "서울",
            "경기도",
            "강원도",
            "충청북도",
            "충청남도",
            "전라북도",
            "전라남도",
            "경상북도",
            "경상남도",
            "제주도"});
            this.comboBox1.Location = new System.Drawing.Point(77, 176);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(104, 20);
            this.comboBox1.TabIndex = 23;
            // 
            // AddMemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 315);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tb_sex);
            this.Controls.Add(this.tb_age);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.tb_pw2);
            this.Controls.Add(this.lb_pw2);
            this.Controls.Add(this.tb_pw);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.lb_pw);
            this.Controls.Add(this.lb_id);
            this.Controls.Add(this.btn_check);
            this.Controls.Add(this.btn_add);
            this.Name = "AddMemberForm";
            this.Text = "AddMemberForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_pw;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label lb_pw;
        private System.Windows.Forms.Label lb_id;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox tb_pw2;
        private System.Windows.Forms.Label lb_pw2;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_age;
        private System.Windows.Forms.TextBox tb_sex;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}