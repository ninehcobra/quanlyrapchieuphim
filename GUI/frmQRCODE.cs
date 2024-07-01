using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.Common;
using ZXing;

namespace GUI
{
    public partial class frmQRCODE : Form
    {
        public frmQRCODE(string id)
        {
            InitializeComponent();
            GenerateBarcode(id);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerateBarcode(string id)
        {

            BarcodeWriter barcodeWriter = new BarcodeWriter();

            // Thiết lập định dạng mã vạch (ở đây chọn QR Code)
            barcodeWriter.Format = BarcodeFormat.QR_CODE;

            // Thiết lập các tùy chọn cho mã vạch (độ rộng, chiều cao, margin)
            EncodingOptions options = new EncodingOptions()
            {
                Width = 300, // Độ rộng của mã vạch
                Height = 300, // Chiều cao của mã vạch
                Margin = 10 // Lề ngoài của mã vạch
            };
            barcodeWriter.Options = options;
            try
            {
                // Tạo Bitmap chứa mã vạch từ chuỗi
                Bitmap barcodeBitmap = barcodeWriter.Write(id);

                // Hiển thị Bitmap trong PictureBox
                picQRCode.Image = barcodeBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
    }
}
