using Microsoft.WindowsAPICodePack.Taskbar;
using static System.Windows.Forms.DataFormats;

namespace VideoDownloader
{
    public partial class Form1 : Form
    {
        Thread loadingThread;
        VideoInformation vi;
        string selectedFormatId = "";

        public Form1()
        {
            InitializeComponent();
            string download_path = Properties.Settings.Default.download_path;
            if (download_path != null && download_path != "")
            {
                tb_save_path.Text = download_path;
            }
            else
            {
                tb_save_path.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            btn_download_selected.Enabled = false;
        }

        private void btn_browse_save_dir_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            tb_save_path.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            if (loadingThread != null && loadingThread.IsAlive)
            {
                //MessageBox.Show("Please wait for the current video to finish downloading.");
                // terminate the thread
                try
                {
                    loadingThread.Abort();
                    download_btn.Text = "Download";
                }
                catch (PlatformNotSupportedException ex)
                {
                    MessageBox.Show("Thread abort failed");
                }
                this.Cursor = Cursors.Default; // reset cursor
                return;
            }
            groupBox2.Enabled = false;

            loadingThread = new Thread(DowloadInfomation);
            loadingThread.Start();
            download_btn.Text = "Cancel";
            // set cursor to wait
            this.Cursor = Cursors.WaitCursor;
        }

        private void DowloadInfomation()
        {
            try
            {
                vi = new VideoInformation(tb_url.Text);
                vi.LoadInformation();
                // invoke showVidInfo()
                this.Invoke(new MethodInvoker(showVidInfo));
                this.Invoke(() =>
                {
                    download_btn.Text = "Download";
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                this.Invoke(() =>
                {
                    download_btn.Text = "Download";
                });
            }
            finally
            {
                this.Invoke(() =>
                {
                    this.Cursor = Cursors.Default; // reset cursor
                });
            }
        }

        private void showVidInfo()
        {
            if (vi == null || !vi.isLoaded)
            {
                MessageBox.Show("No video information found.");
                return;
            }

            lb_title.Text = "Title: " + vi.Title;
            // create bitmap from the thumbnail
            try
            {
                //pb_thumbnail.Image = vi.ThumbnailUrl != "" ? new Bitmap(vi.ThumbnailUrl) : null;
                pb_thumbnail.Image = vi.thumbnail;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!");
            }
            btn_download_selected.Enabled = false;

            initListView();
            groupBox2.Enabled = true;

        }

        void initListView()
        {
            // initilize ListView
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("Title", 300);
            listView1.Columns.Add("ID", 100);
            listView1.Columns.Add("Size", 100);
            listView1.Columns.Add("Audio Only", 100);

            foreach (FileFormats ff in vi.fileFormats)
            {
                if (ff.Size == 0 && !chb_show_zero_size.Checked)
                {
                    continue;
                }
                if (toggle_hide_audio.Checked && !ff.hasVideo)
                {
                    continue;
                }

                ListViewItem item = new ListViewItem(new string[] {
                    ff.FormatText,
                    ff.FormatId,
                    ff.sizeStr(),
                    ff.getAvState()
                });
                listView1.Items.Add(item);
            }

        }

        private void btn_download_selected_Click(object sender, EventArgs e)
        {
            // Get Selected
            if (vi == null || !vi.isLoaded)
            {
                MessageBox.Show("No video information found.");
                return;
            }

            // get selectedFormatId
            FileFormats ff = null;
            for (int i = 0; i < vi.fileFormats.Length; i++)
            {
                if (vi.fileFormats[i].FormatId == selectedFormatId)
                {
                    ff = vi.fileFormats[i];
                    break;
                }
            }

            if (ff == null)
            {
                MessageBox.Show("No format selected.");
                return;
            }

            // Check if it is video only
            String audioFormatId = null;
            if (ff.hasVideo && !ff.hasAudio)
            {
                // Automatically select best audio format
                FileFormats bestAudio = null;
                foreach (FileFormats format in vi.fileFormats)
                {
                    if (format.hasAudio)
                    {
                        if (bestAudio == null || format.Size > bestAudio.Size)
                        {
                            bestAudio = format;
                        }
                    }
                }
                if (bestAudio != null)
                {
                    audioFormatId = bestAudio.FormatId;
                }
            }

            string savePath = tb_save_path.Text + "\\" + vi.FileName + "_" + ff.FormatId + "." + ff.Extension;
            Thread t = new Thread(() =>
            {
                downloaing_form df = new downloaing_form(vi, ff.FormatId, savePath, audioFormatId);
                df.ShowDialog();
            });

            t.Start();

        }

        private void toggle_hide_audio_CheckedChanged(object sender, EventArgs e)
        {
            initListView();
            btn_download_selected.Enabled = false;
        }

        private void btn_browse_save_dir_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = tb_save_path.Text;
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK) return;
            tb_save_path.Text = folderBrowserDialog1.SelectedPath;

            // Save the path
            Properties.Settings.Default.download_path = tb_save_path.Text;
            Properties.Settings.Default.Save();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = null;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    item = listView1.Items[i];
                    break;
                }
            }

            if (item == null)
            {
                btn_download_selected.Enabled = false;
                return;
            }

            selectedFormatId = item.SubItems[1].Text;
            btn_download_selected.Enabled = true;
        }

        private void btn_paste_Click(object sender, EventArgs e)
        {
            // paste from clipboard
            String url = Clipboard.GetText();
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                tb_url.Text = url;
            }
            else
            {
                MessageBox.Show("Invalid URL in clipboard.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
        }

        private void tb_url_KeyDown(object sender, KeyEventArgs e)
        {
            // Check for enter key
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the 'ding' sound
                if (loadingThread != null && loadingThread.IsAlive)
                {
                    MessageBox.Show("Please wait for the current video to finish loading.");
                    return;
                }
                download_btn.PerformClick();
            }
        }

        private void btn_browse_save_dir_Click_2(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = tb_save_path.Text;
            DialogResult results = folderBrowser.ShowDialog();
            if (results.HasFlag(DialogResult.OK))
            {
                tb_save_path.Text = folderBrowser.SelectedPath;
                // Save the path
                Properties.Settings.Default.download_path = tb_save_path.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void visitWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // launch external web browser
            System.Diagnostics.Process.Start("https://namindu.lk");
        }

        private void aboutVideoDownloaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }
    }
}