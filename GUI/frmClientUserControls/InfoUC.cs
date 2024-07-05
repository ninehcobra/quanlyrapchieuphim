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
using GUI.DTO;
using GUI.DAO;
using System.Globalization;

namespace GUI.frmClientUserControls
{
    public partial class InfoUC : UserControl
    {
        User User;
        public InfoUC(User user)
        {
            InitializeComponent();
            User= user;
            GenerateBarcode(User.ID);
            renderInfo();
        }

        private void renderInfo()
        {
            lblName.Text = User.HoTen;
            lblEmail.Text = User.Email;
            label3.Text=User.HoTen;
            float totalSpent = TicketDAO.GetTotalAmountSpentByUser(User.ID);
            lblTotalSpent.Text = $"{totalSpent.ToString("C", new CultureInfo("vi-VN"))}";
        }

        private void GenerateBarcode(string id)
        {
            
            BarcodeWriter barcodeWriter = new BarcodeWriter();

            // Thiết lập định dạng mã vạch (ở đây chọn QR Code)
            barcodeWriter.Format = BarcodeFormat.CODE_128;

            // Thiết lập các tùy chọn cho mã vạch (độ rộng, chiều cao, margin)
            EncodingOptions options = new EncodingOptions()
            {
                Width = 300, // Độ rộng của mã vạch
                Height = 100, // Chiều cao của mã vạch
                Margin = 10 // Lề ngoài của mã vạch
            };
            barcodeWriter.Options = options;
            try
            {
                // Tạo Bitmap chứa mã vạch từ chuỗi
                Bitmap barcodeBitmap = barcodeWriter.Write(id);

                // Hiển thị Bitmap trong PictureBox
                pictureBoxBarcode.Image = barcodeBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
    }
}
