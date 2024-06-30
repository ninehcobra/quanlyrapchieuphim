using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.frmClientUserControls
{
    public partial class HomeUC : UserControl
    {

        private int currentIndex = 0;
        private Timer timer;

        private List<string> imageUrls = new List<string>
        {
            "https://iguov8nhvyobj.vcdn.cloud/media/banner/cache/1/b58515f018eb873dafa430b6f9ae0c1e/9/8/980x448_10__2.jpg",
            "https://iguov8nhvyobj.vcdn.cloud/media/banner/cache/1/b58515f018eb873dafa430b6f9ae0c1e/9/8/980x448_11__2.jpg",
            "https://iguov8nhvyobj.vcdn.cloud/media/banner/cache/1/b58515f018eb873dafa430b6f9ae0c1e/2/0/2024_minion_cb_rbanner.jpg",
            "https://iguov8nhvyobj.vcdn.cloud/media/banner/cache/1/b58515f018eb873dafa430b6f9ae0c1e/r/o/rolling_banner_980x448_2_.png",
            "https://iguov8nhvyobj.vcdn.cloud/media/banner/cache/1/b58515f018eb873dafa430b6f9ae0c1e/9/8/980x448_9__5.jpg"

        };
        public HomeUC()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 3000; // Interval in milliseconds (3 seconds in this case)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            // Load the next image from the list
            currentIndex = (currentIndex + 1) % imageUrls.Count;
            await LoadImageFromUrlAsync(imageUrls[currentIndex]);
        }

        private async Task LoadImageFromUrlAsync(string url)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    byte[] data = await webClient.DownloadDataTaskAsync(url);
                    using (var stream = new System.IO.MemoryStream(data))
                    {
                        Image image = Image.FromStream(stream);
                        picThumb.Image = image;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load image from URL: {ex.Message}");
            }
        }

        private async void pictureBox9_Click(object sender, EventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = imageUrls.Count - 1;

            await LoadImageFromUrlAsync(imageUrls[currentIndex]);
        }

        private async void pictureBox8_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % imageUrls.Count;
            await LoadImageFromUrlAsync(imageUrls[currentIndex]);
        }
    }
}
