namespace FireCard
{
    partial class Create
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Create));
            this.createButton = new System.Windows.Forms.Button();
            this.discardButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.directionBox = new System.Windows.Forms.ComboBox();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(478, 586);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(179, 60);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "Створити";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // discardButton
            // 
            this.discardButton.Location = new System.Drawing.Point(12, 586);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(179, 60);
            this.discardButton.TabIndex = 1;
            this.discardButton.Text = "Скинути";
            this.discardButton.UseVisualStyleBackColor = true;
            this.discardButton.Click += new System.EventHandler(this.discardButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Сторони горизонту :";
            // 
            // directionBox
            // 
            this.directionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.directionBox.FormattingEnabled = true;
            this.directionBox.Items.AddRange(new object[] {
            "Північний",
            "Північно-Східний",
            "Східний",
            "Південно-Східний",
            "Південий",
            "Південно-Західний",
            "Західний",
            "Північно-Західний"});
            this.directionBox.Location = new System.Drawing.Point(301, 104);
            this.directionBox.Name = "directionBox";
            this.directionBox.Size = new System.Drawing.Size(356, 39);
            this.directionBox.TabIndex = 3;
            // 
            // typeBox
            // 
            this.typeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Items.AddRange(new object[] {
            "Перше",
            "Друге",
            "Третє"});
            this.typeBox.Location = new System.Drawing.Point(301, 30);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(356, 39);
            this.typeBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Номер мех. відділення :";
            // 
            // Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 658);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.directionBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.discardButton);
            this.Controls.Add(this.createButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Create";
            this.Text = "Нова картка вогню";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Create_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button discardButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox directionBox;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Label label2;
    }
}