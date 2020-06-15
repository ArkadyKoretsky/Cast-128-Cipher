using System.Security.Cryptography.X509Certificates;

namespace Cast128_CS
{
    partial class AddNewRow
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
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.FullNameTextBox = new System.Windows.Forms.TextBox();
            this.AlgorithmTextBox = new System.Windows.Forms.TextBox();
            this.IdLabel = new System.Windows.Forms.Label();
            this.FullNameLabel = new System.Windows.Forms.Label();
            this.AlgorithmLabel = new System.Windows.Forms.Label();
            this.GroupNumber = new System.Windows.Forms.NumericUpDown();
            this.GroupNumberLabel = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GroupNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(265, 68);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(247, 20);
            this.IdTextBox.TabIndex = 0;
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Location = new System.Drawing.Point(265, 120);
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.Size = new System.Drawing.Size(247, 20);
            this.FullNameTextBox.TabIndex = 1;
            // 
            // AlgorithmTextBox
            // 
            this.AlgorithmTextBox.Location = new System.Drawing.Point(265, 180);
            this.AlgorithmTextBox.Name = "AlgorithmTextBox";
            this.AlgorithmTextBox.Size = new System.Drawing.Size(247, 20);
            this.AlgorithmTextBox.TabIndex = 2;
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdLabel.Location = new System.Drawing.Point(230, 65);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(32, 25);
            this.IdLabel.TabIndex = 4;
            this.IdLabel.Text = "ID";
            // 
            // FullNameLabel
            // 
            this.FullNameLabel.AutoSize = true;
            this.FullNameLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullNameLabel.Location = new System.Drawing.Point(162, 116);
            this.FullNameLabel.Name = "FullNameLabel";
            this.FullNameLabel.Size = new System.Drawing.Size(101, 25);
            this.FullNameLabel.TabIndex = 5;
            this.FullNameLabel.Text = "Full Name";
            // 
            // AlgorithmLabel
            // 
            this.AlgorithmLabel.AutoSize = true;
            this.AlgorithmLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgorithmLabel.Location = new System.Drawing.Point(161, 176);
            this.AlgorithmLabel.Name = "AlgorithmLabel";
            this.AlgorithmLabel.Size = new System.Drawing.Size(102, 25);
            this.AlgorithmLabel.TabIndex = 6;
            this.AlgorithmLabel.Text = "Algorithm";
            // 
            // GroupNumber
            // 
            this.GroupNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupNumber.Location = new System.Drawing.Point(265, 232);
            this.GroupNumber.Name = "GroupNumber";
            this.GroupNumber.Size = new System.Drawing.Size(76, 25);
            this.GroupNumber.TabIndex = 7;
            this.GroupNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GroupNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // GroupNumberLabel
            // 
            this.GroupNumberLabel.AutoSize = true;
            this.GroupNumberLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupNumberLabel.Location = new System.Drawing.Point(113, 231);
            this.GroupNumberLabel.Name = "GroupNumberLabel";
            this.GroupNumberLabel.Size = new System.Drawing.Size(149, 25);
            this.GroupNumberLabel.TabIndex = 8;
            this.GroupNumberLabel.Text = "Group Number";
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(333, 290);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(118, 48);
            this.AddButton.TabIndex = 9;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(333, 358);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(117, 47);
            this.ExitButton.TabIndex = 10;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // AddNewRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.GroupNumberLabel);
            this.Controls.Add(this.GroupNumber);
            this.Controls.Add(this.AlgorithmLabel);
            this.Controls.Add(this.FullNameLabel);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.AlgorithmTextBox);
            this.Controls.Add(this.FullNameTextBox);
            this.Controls.Add(this.IdTextBox);
            this.Name = "AddNewRow";
            this.Text = "Add New Row";
            ((System.ComponentModel.ISupportInitialize)(this.GroupNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.TextBox FullNameTextBox;
        private System.Windows.Forms.TextBox AlgorithmTextBox;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Label FullNameLabel;
        private System.Windows.Forms.Label AlgorithmLabel;
        private System.Windows.Forms.NumericUpDown GroupNumber;
        private System.Windows.Forms.Label GroupNumberLabel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button ExitButton;
    }
}