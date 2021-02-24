namespace FireCard
{
    partial class newItem
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
            this.itemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.itemDirection = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.itemHighth = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // itemName
            // 
            this.itemName.Location = new System.Drawing.Point(27, 43);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(189, 22);
            this.itemName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Назва";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Відстань (м)";
            // 
            // itemDirection
            // 
            this.itemDirection.Location = new System.Drawing.Point(27, 106);
            this.itemDirection.Name = "itemDirection";
            this.itemDirection.Size = new System.Drawing.Size(189, 22);
            this.itemDirection.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Висота відносно позиції (м)";
            // 
            // itemHighth
            // 
            this.itemHighth.Location = new System.Drawing.Point(27, 156);
            this.itemHighth.Name = "itemHighth";
            this.itemHighth.Size = new System.Drawing.Size(189, 22);
            this.itemHighth.TabIndex = 5;
            // 
            // newItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 219);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.itemHighth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.itemDirection);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemName);
            this.Name = "newItem";
            this.Text = "Орієнтир";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox itemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox itemDirection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox itemHighth;
    }
}