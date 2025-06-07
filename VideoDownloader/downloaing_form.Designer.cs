namespace VideoDownloader
{
    partial class downloaing_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(downloaing_form));
            label1 = new Label();
            progressBar1 = new ProgressBar();
            button1 = new Button();
            label2 = new Label();
            lb_status = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 27);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 0;
            label1.Text = "File:";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(14, 135);
            progressBar1.Margin = new Padding(3, 4, 3, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(413, 31);
            progressBar1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(14, 197);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 2;
            button1.Text = "Stop";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 60);
            label2.Name = "label2";
            label2.Size = new Size(142, 20);
            label2.TabIndex = 3;
            label2.Text = "Download Location:";
            // 
            // lb_status
            // 
            lb_status.AutoSize = true;
            lb_status.Location = new Point(118, 204);
            lb_status.Name = "lb_status";
            lb_status.Size = new Size(50, 20);
            lb_status.TabIndex = 4;
            lb_status.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 96);
            label4.Name = "label4";
            label4.Size = new Size(142, 20);
            label4.TabIndex = 5;
            label4.Text = "Download Location:";
            // 
            // downloaing_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 244);
            Controls.Add(label4);
            Controls.Add(lb_status);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "downloaing_form";
            Text = "Downloading";
            FormClosing += downloaing_form_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ProgressBar progressBar1;
        private Button button1;
        private Label label2;
        private Label lb_status;
        private Label label4;
    }
}