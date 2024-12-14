namespace SUBD_books_project
{
    partial class Form_INSERT_BOOKS
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_publishing_houses = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.textBox_pages = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_insert = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(75)))), ((int)(((byte)(60)))));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(909, 100);
            this.panel3.TabIndex = 103;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 24.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(11, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(509, 53);
            this.label4.TabIndex = 18;
            this.label4.Text = "Книги - добавление (insert)";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(75)))), ((int)(((byte)(60)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBox_publishing_houses);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_title);
            this.panel1.Controls.Add(this.textBox_pages);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.button_insert);
            this.panel1.Location = new System.Drawing.Point(5, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(672, 407);
            this.panel1.TabIndex = 103;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(24, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 37);
            this.label5.TabIndex = 130;
            this.label5.Text = "Издатель:";
            // 
            // comboBox_publishing_houses
            // 
            this.comboBox_publishing_houses.BackColor = System.Drawing.Color.AntiqueWhite;
            this.comboBox_publishing_houses.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_publishing_houses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(75)))), ((int)(((byte)(60)))));
            this.comboBox_publishing_houses.FormattingEnabled = true;
            this.comboBox_publishing_houses.Location = new System.Drawing.Point(193, 94);
            this.comboBox_publishing_houses.Name = "comboBox_publishing_houses";
            this.comboBox_publishing_houses.Size = new System.Drawing.Size(237, 37);
            this.comboBox_publishing_houses.TabIndex = 128;
            this.comboBox_publishing_houses.TabStop = false;
            this.comboBox_publishing_houses.SelectedIndexChanged += new System.EventHandler(this.comboBox_publishing_houses_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 37);
            this.label1.TabIndex = 127;
            this.label1.Text = "Название:";
            // 
            // textBox_title
            // 
            this.textBox_title.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox_title.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(75)))), ((int)(((byte)(60)))));
            this.textBox_title.Location = new System.Drawing.Point(134, 43);
            this.textBox_title.Multiline = true;
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.Size = new System.Drawing.Size(296, 33);
            this.textBox_title.TabIndex = 126;
            this.textBox_title.TabStop = false;
            // 
            // textBox_pages
            // 
            this.textBox_pages.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox_pages.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_pages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(75)))), ((int)(((byte)(60)))));
            this.textBox_pages.Location = new System.Drawing.Point(240, 150);
            this.textBox_pages.Multiline = true;
            this.textBox_pages.Name = "textBox_pages";
            this.textBox_pages.Size = new System.Drawing.Size(190, 33);
            this.textBox_pages.TabIndex = 124;
            this.textBox_pages.TabStop = false;
            this.textBox_pages.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(24, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(210, 39);
            this.label8.TabIndex = 125;
            this.label8.Text = "Количество страниц:";
            // 
            // button_insert
            // 
            this.button_insert.BackColor = System.Drawing.Color.AntiqueWhite;
            this.button_insert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_insert.Font = new System.Drawing.Font("Bahnschrift Condensed", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_insert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(75)))), ((int)(((byte)(60)))));
            this.button_insert.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_insert.Location = new System.Drawing.Point(228, 236);
            this.button_insert.Name = "button_insert";
            this.button_insert.Size = new System.Drawing.Size(202, 42);
            this.button_insert.TabIndex = 122;
            this.button_insert.TabStop = false;
            this.button_insert.Text = "Добавить";
            this.button_insert.UseVisualStyleBackColor = false;
            this.button_insert.Click += new System.EventHandler(this.button_insert_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::SUBD_books_project.Properties.Resources.aab0dd7a13205ce05bff5ea2f2db866a;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(696, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 273);
            this.panel2.TabIndex = 104;
            // 
            // Form_INSERT_BOOKS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(908, 523);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "Form_INSERT_BOOKS";
            this.Text = "Form_INSERT_BOOKS";
            this.Load += new System.EventHandler(this.Form_INSERT_BOOKS_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_publishing_houses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_title;
        private System.Windows.Forms.TextBox textBox_pages;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_insert;
        private System.Windows.Forms.Panel panel2;
    }
}