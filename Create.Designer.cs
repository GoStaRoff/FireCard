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
            this.label3 = new System.Windows.Forms.Label();
            this.checkBTR = new System.Windows.Forms.CheckBox();
            this.checkTANK = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(357, 252);
            this.createButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(134, 49);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "Створити";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // discardButton
            // 
            this.discardButton.Location = new System.Drawing.Point(11, 252);
            this.discardButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(134, 49);
            this.discardButton.TabIndex = 1;
            this.discardButton.Text = "Скинути";
            this.discardButton.UseVisualStyleBackColor = true;
            this.discardButton.Click += new System.EventHandler(this.discardButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 24);
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
            this.directionBox.Location = new System.Drawing.Point(226, 84);
            this.directionBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.directionBox.Name = "directionBox";
            this.directionBox.Size = new System.Drawing.Size(268, 34);
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
            this.typeBox.Location = new System.Drawing.Point(226, 24);
            this.typeBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(268, 34);
            this.typeBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(4, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Номер мех. відділення :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(5, 153);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Допоміжні засоби :";
            // 
            // checkBTR
            // 
            this.checkBTR.AutoSize = true;
            this.checkBTR.Location = new System.Drawing.Point(226, 159);
            this.checkBTR.Name = "checkBTR";
            this.checkBTR.Size = new System.Drawing.Size(47, 17);
            this.checkBTR.TabIndex = 7;
            this.checkBTR.Text = "БТР";
            this.checkBTR.UseVisualStyleBackColor = true;
            // 
            // checkTANK
            // 
            this.checkTANK.AutoSize = true;
            this.checkTANK.Location = new System.Drawing.Point(226, 199);
            this.checkTANK.Name = "checkTANK";
            this.checkTANK.Size = new System.Drawing.Size(55, 17);
            this.checkTANK.TabIndex = 8;
            this.checkTANK.Text = "ТАНК";
            this.checkTANK.UseVisualStyleBackColor = true;
            // 
            // Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 309);
            this.Controls.Add(this.checkTANK);
            this.Controls.Add(this.checkBTR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.directionBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.discardButton);
            this.Controls.Add(this.createButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBTR;
        private System.Windows.Forms.CheckBox checkTANK;
    }
}