﻿
namespace bd_PROG
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
            this.button1 = new System.Windows.Forms.Button();
            this.b_u = new System.Windows.Forms.Button();
            this.b_l = new System.Windows.Forms.Button();
            this.b_r = new System.Windows.Forms.Button();
            this.b_d = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // b_u
            // 
            this.b_u.Location = new System.Drawing.Point(24, 117);
            this.b_u.Name = "b_u";
            this.b_u.Size = new System.Drawing.Size(64, 23);
            this.b_u.TabIndex = 1;
            this.b_u.Text = "up";
            this.b_u.UseVisualStyleBackColor = true;
            this.b_u.Click += new System.EventHandler(this.b_u_Click);
            // 
            // b_l
            // 
            this.b_l.Location = new System.Drawing.Point(8, 146);
            this.b_l.Name = "b_l";
            this.b_l.Size = new System.Drawing.Size(48, 23);
            this.b_l.TabIndex = 1;
            this.b_l.Text = "left";
            this.b_l.UseVisualStyleBackColor = true;
            this.b_l.Click += new System.EventHandler(this.b_l_Click);
            // 
            // b_r
            // 
            this.b_r.Location = new System.Drawing.Point(62, 146);
            this.b_r.Name = "b_r";
            this.b_r.Size = new System.Drawing.Size(50, 23);
            this.b_r.TabIndex = 1;
            this.b_r.Text = "right";
            this.b_r.UseVisualStyleBackColor = true;
            this.b_r.Click += new System.EventHandler(this.b_r_Click);
            // 
            // b_d
            // 
            this.b_d.Location = new System.Drawing.Point(24, 175);
            this.b_d.Name = "b_d";
            this.b_d.Size = new System.Drawing.Size(64, 23);
            this.b_d.TabIndex = 1;
            this.b_d.Text = "down";
            this.b_d.UseVisualStyleBackColor = true;
            this.b_d.Click += new System.EventHandler(this.b_d_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(24, 231);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Копать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 398);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(286, 225);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Удачной дороги, путник. Помни что опасность может быть ближе чем ты думаешь!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 635);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.b_d);
            this.Controls.Add(this.b_r);
            this.Controls.Add(this.b_l);
            this.Controls.Add(this.b_u);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button b_u;
        private System.Windows.Forms.Button b_l;
        private System.Windows.Forms.Button b_r;
        private System.Windows.Forms.Button b_d;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

