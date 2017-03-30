namespace OrderADO
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button15 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SortOrientationList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(952, 479);
            this.listView1.SmallImageList = this.SortOrientationList;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listView1_RetrieveVirtualItem);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "№";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Id";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Номер документа";
            this.columnHeader3.Width = 140;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Сумма";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Статус";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Тип документа";
            this.columnHeader6.Width = 140;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Процент обработки";
            this.columnHeader7.Width = 140;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Коментарий";
            this.columnHeader8.Width = 200;
            // 
            // button15
            // 
            this.button15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button15.Location = new System.Drawing.Point(970, 167);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(157, 23);
            this.button15.TabIndex = 10;
            this.button15.Text = "Отменить обработку";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button12
            // 
            this.button12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button12.Location = new System.Drawing.Point(970, 138);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(157, 23);
            this.button12.TabIndex = 9;
            this.button12.Text = "Обработать";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(970, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Изменить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(970, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(970, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(970, 228);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(157, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Типы заказов";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // SortOrientationList
            // 
            this.SortOrientationList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SortOrientationList.ImageStream")));
            this.SortOrientationList.TransparentColor = System.Drawing.Color.White;
            this.SortOrientationList.Images.SetKeyName(0, "_bullet_arrow_up.png");
            this.SortOrientationList.Images.SetKeyName(1, "Desc");
            this.SortOrientationList.Images.SetKeyName(2, "Asc");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 503);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Заказы";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ImageList SortOrientationList;
    }
}

