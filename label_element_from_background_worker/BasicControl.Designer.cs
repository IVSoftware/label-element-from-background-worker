﻿
namespace label_element_from_background_worker
{
    partial class BasicControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxDoWork = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(166, 21);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(151, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "No Result";
            // 
            // checkBoxDoWork
            // 
            this.checkBoxDoWork.AutoSize = true;
            this.checkBoxDoWork.Location = new System.Drawing.Point(25, 22);
            this.checkBoxDoWork.Name = "checkBoxDoWork";
            this.checkBoxDoWork.Size = new System.Drawing.Size(109, 29);
            this.checkBoxDoWork.TabIndex = 2;
            this.checkBoxDoWork.Text = "Do Work";
            this.checkBoxDoWork.UseVisualStyleBackColor = true;
            // 
            // BasicControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.checkBoxDoWork);
            this.Controls.Add(this.label1);
            this.Name = "BasicControl";
            this.Size = new System.Drawing.Size(457, 86);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxDoWork;
    }
}
