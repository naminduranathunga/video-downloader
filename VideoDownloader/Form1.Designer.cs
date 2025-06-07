namespace VideoDownloader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            download_btn = new Button();
            tb_url = new TextBox();
            btn_paste = new Button();
            saveFileDialog1 = new SaveFileDialog();
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel2 = new Panel();
            listView1 = new ListView();
            tableLayoutPanel3 = new TableLayoutPanel();
            toggle_hide_audio = new CheckBox();
            chb_show_zero_size = new CheckBox();
            label1 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            btn_browse_save_dir = new Button();
            tb_save_path = new TextBox();
            label2 = new Label();
            panel5 = new Panel();
            pb_thumbnail = new PictureBox();
            panel6 = new Panel();
            btn_download_selected = new Button();
            lb_title = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            menuStrip1 = new MenuStrip();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutVideoDownloaderToolStripMenuItem = new ToolStripMenuItem();
            visitWebsiteToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_thumbnail).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 28);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(9, 11, 9, 11);
            groupBox1.Size = new Size(1209, 92);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "URL";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.30493F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.6950674F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
            tableLayoutPanel1.Controls.Add(download_btn, 0, 0);
            tableLayoutPanel1.Controls.Add(tb_url, 0, 0);
            tableLayoutPanel1.Controls.Add(btn_paste, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(9, 31);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1191, 50);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // download_btn
            // 
            download_btn.Dock = DockStyle.Top;
            download_btn.Location = new Point(893, 4);
            download_btn.Margin = new Padding(3, 4, 3, 4);
            download_btn.Name = "download_btn";
            download_btn.Size = new Size(159, 36);
            download_btn.TabIndex = 2;
            download_btn.Text = "Download";
            download_btn.UseVisualStyleBackColor = true;
            download_btn.Click += btn_download_Click;
            // 
            // tb_url
            // 
            tb_url.Dock = DockStyle.Fill;
            tb_url.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_url.Location = new Point(3, 4);
            tb_url.Margin = new Padding(3, 4, 3, 4);
            tb_url.Name = "tb_url";
            tb_url.PlaceholderText = "https://www.youtube.com";
            tb_url.Size = new Size(884, 34);
            tb_url.TabIndex = 1;
            tb_url.KeyDown += tb_url_KeyDown;
            // 
            // btn_paste
            // 
            btn_paste.Dock = DockStyle.Top;
            btn_paste.Location = new Point(1058, 4);
            btn_paste.Margin = new Padding(3, 4, 3, 4);
            btn_paste.Name = "btn_paste";
            btn_paste.Size = new Size(130, 36);
            btn_paste.TabIndex = 0;
            btn_paste.Text = "Paste";
            btn_paste.UseVisualStyleBackColor = true;
            btn_paste.Click += btn_paste_Click;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 120);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1209, 21);
            panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tableLayoutPanel2);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 141);
            groupBox2.Margin = new Padding(0);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(1209, 548);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Download Options";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.98236F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.01764F));
            tableLayoutPanel2.Controls.Add(panel2, 0, 0);
            tableLayoutPanel2.Controls.Add(panel3, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 24);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 148F));
            tableLayoutPanel2.Size = new Size(1203, 520);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(listView1);
            panel2.Controls.Add(tableLayoutPanel3);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 4);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(8);
            panel2.Size = new Size(583, 512);
            panel2.TabIndex = 0;
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(8, 61);
            listView1.Margin = new Padding(3, 4, 3, 4);
            listView1.Name = "listView1";
            listView1.Size = new Size(567, 443);
            listView1.TabIndex = 8;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(toggle_hide_audio, 0, 0);
            tableLayoutPanel3.Controls.Add(chb_show_zero_size, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(8, 28);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(567, 33);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // toggle_hide_audio
            // 
            toggle_hide_audio.AutoSize = true;
            toggle_hide_audio.Checked = true;
            toggle_hide_audio.CheckState = CheckState.Checked;
            toggle_hide_audio.Dock = DockStyle.Top;
            toggle_hide_audio.Location = new Point(3, 4);
            toggle_hide_audio.Margin = new Padding(3, 4, 3, 4);
            toggle_hide_audio.Name = "toggle_hide_audio";
            toggle_hide_audio.Size = new Size(277, 24);
            toggle_hide_audio.TabIndex = 6;
            toggle_hide_audio.Text = "Hide Aduio only";
            toggle_hide_audio.UseVisualStyleBackColor = true;
            toggle_hide_audio.CheckedChanged += toggle_hide_audio_CheckedChanged;
            // 
            // chb_show_zero_size
            // 
            chb_show_zero_size.AutoSize = true;
            chb_show_zero_size.Location = new Point(286, 3);
            chb_show_zero_size.Name = "chb_show_zero_size";
            chb_show_zero_size.Size = new Size(160, 24);
            chb_show_zero_size.TabIndex = 7;
            chb_show_zero_size.Text = "Show zero file sizes";
            chb_show_zero_size.UseVisualStyleBackColor = true;
            chb_show_zero_size.CheckedChanged += toggle_hide_audio_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(8, 8);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 2;
            label1.Text = "Select Quality";
            // 
            // panel3
            // 
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(pb_thumbnail);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(btn_download_selected);
            panel3.Controls.Add(lb_title);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(592, 4);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(8);
            panel3.Size = new Size(608, 512);
            panel3.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(btn_browse_save_dir);
            panel4.Controls.Add(tb_save_path);
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(8, 301);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(592, 97);
            panel4.TabIndex = 11;
            // 
            // btn_browse_save_dir
            // 
            btn_browse_save_dir.Location = new Point(6, 59);
            btn_browse_save_dir.Margin = new Padding(3, 4, 3, 4);
            btn_browse_save_dir.Name = "btn_browse_save_dir";
            btn_browse_save_dir.Size = new Size(86, 31);
            btn_browse_save_dir.TabIndex = 5;
            btn_browse_save_dir.Text = "Browse";
            btn_browse_save_dir.UseVisualStyleBackColor = true;
            btn_browse_save_dir.Click += btn_browse_save_dir_Click_2;
            // 
            // tb_save_path
            // 
            tb_save_path.Dock = DockStyle.Fill;
            tb_save_path.Location = new Point(0, 20);
            tb_save_path.Margin = new Padding(3, 4, 3, 4);
            tb_save_path.Name = "tb_save_path";
            tb_save_path.PlaceholderText = "C:/Users/ABC/Downloads/";
            tb_save_path.Size = new Size(592, 27);
            tb_save_path.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 3;
            label2.Text = "Save Directory";
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(8, 280);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(592, 21);
            panel5.TabIndex = 10;
            // 
            // pb_thumbnail
            // 
            pb_thumbnail.Dock = DockStyle.Top;
            pb_thumbnail.Image = Properties.Resources.icons8_download_100;
            pb_thumbnail.Location = new Point(8, 57);
            pb_thumbnail.Margin = new Padding(3, 4, 3, 4);
            pb_thumbnail.Name = "pb_thumbnail";
            pb_thumbnail.Size = new Size(592, 223);
            pb_thumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            pb_thumbnail.TabIndex = 9;
            pb_thumbnail.TabStop = false;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(8, 36);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(592, 21);
            panel6.TabIndex = 8;
            // 
            // btn_download_selected
            // 
            btn_download_selected.Dock = DockStyle.Bottom;
            btn_download_selected.Location = new Point(8, 421);
            btn_download_selected.Margin = new Padding(3, 4, 3, 4);
            btn_download_selected.Name = "btn_download_selected";
            btn_download_selected.Size = new Size(592, 83);
            btn_download_selected.TabIndex = 5;
            btn_download_selected.Text = "Download";
            btn_download_selected.UseVisualStyleBackColor = true;
            btn_download_selected.Click += btn_download_selected_Click;
            // 
            // lb_title
            // 
            lb_title.AutoSize = true;
            lb_title.Dock = DockStyle.Top;
            lb_title.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lb_title.Location = new Point(8, 8);
            lb_title.Name = "lb_title";
            lb_title.Size = new Size(62, 28);
            lb_title.TabIndex = 0;
            lb_title.Text = "Title: ";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1209, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutVideoDownloaderToolStripMenuItem, visitWebsiteToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutVideoDownloaderToolStripMenuItem
            // 
            aboutVideoDownloaderToolStripMenuItem.Name = "aboutVideoDownloaderToolStripMenuItem";
            aboutVideoDownloaderToolStripMenuItem.Size = new Size(262, 26);
            aboutVideoDownloaderToolStripMenuItem.Text = "About Video Downloader";
            aboutVideoDownloaderToolStripMenuItem.Click += aboutVideoDownloaderToolStripMenuItem_Click;
            // 
            // visitWebsiteToolStripMenuItem
            // 
            visitWebsiteToolStripMenuItem.Name = "visitWebsiteToolStripMenuItem";
            visitWebsiteToolStripMenuItem.Size = new Size(262, 26);
            visitWebsiteToolStripMenuItem.Text = "Visit Website";
            visitWebsiteToolStripMenuItem.Click += visitWebsiteToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 689);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Video Downloader";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_thumbnail).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox tb_url;
        private Button btn_download;
        private SaveFileDialog saveFileDialog1;
        private Panel panel1;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Button btn_download_selected;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label lb_title;
        private PictureBox pb_thumbnail;
        private Panel panel4;
        private Button btn_browse_save_dir;
        private TextBox tb_save_path;
        private Label label2;
        private Panel panel5;
        private Panel panel6;
        private Button btn_paste;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel3;
        private ListView listView1;
        private CheckBox toggle_hide_audio;
        private CheckBox chb_show_zero_size;
        private Button download_btn;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutVideoDownloaderToolStripMenuItem;
        private ToolStripMenuItem visitWebsiteToolStripMenuItem;
    }
}