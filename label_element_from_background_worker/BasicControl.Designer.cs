
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
            this.myLabel = new System.Windows.Forms.Label();
            this.checkBoxDoWork = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // myLabel
            // 
            this.myLabel.AutoSize = true;
            this.myLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myLabel.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.myLabel.Location = new System.Drawing.Point(140, 24);
            this.myLabel.Name = "myLabel";
            this.myLabel.Padding = new System.Windows.Forms.Padding(3);
            this.myLabel.Size = new System.Drawing.Size(73, 26);
            this.myLabel.TabIndex = 0;
            this.myLabel.Text = "No Message";
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
            this.Controls.Add(this.myLabel);
            this.Name = "BasicControl";
            this.Size = new System.Drawing.Size(457, 86);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label myLabel;
        private System.Windows.Forms.CheckBox checkBoxDoWork;
    }
}
