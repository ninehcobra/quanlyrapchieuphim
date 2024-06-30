using GUI.DAO;
using GUI.DTO;
using GUI.frmAdminUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace GUI.frmClientUserControls
{
    public partial class BookingUC : UserControl
    {
        ShowTimes Times;
        Movie Movie;

        int SIZE = 30;//Size của ghế
        int GAP = 7;//Khoảng cách giữa các ghế

        List<Ticket> listSeat = new List<Ticket>();

        //dùng lưu vết các Ghế đang chọn
        List<Button> listSeatSelected = new List<Button>();

        float displayPrice = 0;//Hiện thị giá vé
        float ticketPrice = 0;//Lưu giá vé gốc
        float total = 0;//Tổng giá tiền
        float discount = 0;//Tiền được giảm
        float payment = 0;//Tiền phải trả
        int plusPoint = 0;//Số điểm tích lũy khi mua vé

        frmClient frmClient;
        User User;
        public BookingUC(ShowTimes showTimes, Movie movie, frmClient frmClient1,User user1)
        {
            InitializeComponent();
            Times = showTimes;
            Movie = movie;
            User = user1;
            RenderForm();
            frmClient= frmClient1;
          
        }

        private void RenderForm()
        {
            lblUserName.Text = User.HoTen;
            ticketPrice = Times.TicketPrice;
            plusPoint=UserDAO.GetDiemTichLuy(User.UserName);

            lblPlusPoint.Text = plusPoint.ToString();

            lblInformation.Text = "CGV Hung Vuong | " + Times.CinemaName + " | " + Times.MovieName;
            lblTime.Text = Times.Time.ToShortDateString() + " | "
                + Times.Time.ToShortTimeString() + " - "
                + Times.Time.AddMinutes(Movie.Time).ToShortTimeString();
            if (Movie.Poster != null)
                picFilm.Image = MovieDAO.byteArrayToImage(Movie.Poster);

          
            

            LoadDataCinema(Times.CinemaName);

           

            listSeat = TicketDAO.GetListTicketsByShowTimes(Times.ID);

            LoadSeats(listSeat);
        }

        private void LoadDataCinema(string cinemaName)
        {
            Cinema cinema = CinemaDAO.GetCinemaByName(cinemaName);
            int Row = cinema.Row;
            int Column = cinema.SeatInRow;
            flpSeat.Size = new Size((SIZE + 20 + GAP) * Column, (SIZE + GAP) * Row);
        }

        private void LoadSeats(List<Ticket> list)
        {
            flpSeat.Controls.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                Button btnSeat = new Button() { Width = SIZE + 20, Height = SIZE };
                btnSeat.Text = list[i].SeatName;
                if (list[i].Status == 1)
                    btnSeat.BackColor = Color.Red;
                else
                    btnSeat.BackColor = Color.White;
                btnSeat.Click += BtnSeat_Click;
                flpSeat.Controls.Add(btnSeat);

                btnSeat.Tag = list[i];
            }
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btnSeat = sender as Button;
            if (btnSeat.BackColor == Color.White)
            {
               

                btnSeat.BackColor = Color.Yellow;
                Ticket ticket = btnSeat.Tag as Ticket;

                ticket.Price = ticketPrice;
                displayPrice = ticket.Price;
                total += ticketPrice;
                payment = total - discount;
                ticket.Type = 1;

                listSeatSelected.Add(btnSeat);
                plusPoint++;
               
            }
            else if (btnSeat.BackColor == Color.Yellow)
            {
                btnSeat.BackColor = Color.White;
                Ticket ticket = btnSeat.Tag as Ticket;

                total -= ticket.Price;
                payment = total - discount;
                ticket.Price = 0;
                displayPrice = ticket.Price;
                ticket.Type = 0;

                listSeatSelected.Remove(btnSeat);
                plusPoint--;
                
            }
            else if (btnSeat.BackColor == Color.Red)
            {
                MessageBox.Show("Ghế số [" + btnSeat.Text + "] đã có người mua");
            }
            LoadBill();
            
        }

        private void LoadBill()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            //Đổi culture vùng quốc gia để đổi đơn vị tiền tệ 

            //Thread.CurrentThread.CurrentCulture = culture;
            //dùng thread để chuyển cả luồng đang chạy về vùng quốc gia đó

            lblTicketPrice.Text = displayPrice.ToString("c", culture);
            lblTotal.Text = total.ToString("c", culture);
            lblDiscount.Text = discount.ToString("c", culture);
            lblPayment.Text = payment.ToString("c", culture);

            //Đổi đơn vị tiền tệ
            //gán culture chỗ này thì chỉ có chỗ này sd culture này còn
            //lại sài mặc định
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn hủy tất cả những vé đã chọn ko?",
                "Hủy Mua Vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            foreach (Button btn in listSeatSelected)
            {
                btn.BackColor = Color.White;
            }
            RestoreDefault();
            this.OnLoad(new EventArgs());
        }

        private void RestoreDefault()
        {
            listSeatSelected.Clear();

           

            total = 0;
            displayPrice = 0;
            discount = 0;
            payment = 0;
            plusPoint = 0;

            LoadBill();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có vé nào được chọn không
            if (listSeatSelected.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé trước khi thanh toán!");
                return;
            }

            // Tạo thông điệp xác nhận mua vé
            string message = "Bạn có chắc chắn mua những vé: \n";
            foreach (Button btn in listSeatSelected)
            {
                message += "[" + btn.Text + "] ";
            }
            message += "\nKhông?";
            DialogResult result = MessageBox.Show(message, "Hỏi Mua",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                int ret = 0;
                List<Attachment> attachments = new List<Attachment>();

                foreach (Button btn in listSeatSelected)
                {
                    Ticket ticket = btn.Tag as Ticket;

                    // Mã vé của từng vé đã mua
                    string ticketID = ticket.ID;

                    // Tạo mã QR cho từng vé
                    Bitmap qrCode = GenerateQRCode(ticketID);
                    // Lưu lại mã QR vào thư mục (tuỳ chọn)

                    // Tạo đường dẫn đến tệp QR Code (tuỳ chọn)
                    string qrCodeFilePath = $"QRCode_{ticketID}.png";
                    qrCode.Save(qrCodeFilePath);

                    // Đính kèm tệp QR Code vào danh sách attachments (tuỳ chọn)
                    attachments.Add(new Attachment(qrCodeFilePath));

                    // Mua vé và kiểm tra kết quả
                    ret += TicketDAO.BuyTicket(ticket.ID, ticket.Type, User.ID, ticket.Price);
                }

                // Kiểm tra xem tất cả các vé đã được mua thành công
                if (ret == listSeatSelected.Count)
                {
                    MessageBox.Show("Bạn đã mua vé thành công!");

                    // Render lại form (tuỳ chọn)
                    RenderForm();

                    // Gửi email chứa các thông tin mua vé và mã QR cho người mua
                    string userEmail = User.Email; // Địa chỉ email người mua
                    string emailSubject = "Xác nhận mua vé"; // Tiêu đề email
                    string emailBody = "<!doctype html>\r\n<html lang=\"en\">\r\n  <head>\r\n    <meta charset=\"UTF-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>OTP</title>\r\n    <style>\r\n      /* Styles for small screens */\r\n      @media (max-width: 767px) {\r\n        .container {\r\n          width: 90%;\r\n          padding: 12px;\r\n        }\r\n        .logo img {\r\n          height: 30px;\r\n        }\r\n        .heading {\r\n          font-size: 24px;\r\n        }\r\n        .otp-banner img {\r\n          max-width: 100%;\r\n          height: auto;\r\n        }\r\n        .content {\r\n          padding: 20px;\r\n        }\r\n        .footer {\r\n          font-size: 12px;\r\n        }\r\n      }\r\n\r\n      /* Styles for medium screens */\r\n      @media (min-width: 768px) and (max-width: 1023px) {\r\n        .container {\r\n          width: 80%;\r\n        }\r\n        .logo img {\r\n          height: 40px;\r\n        }\r\n        .heading {\r\n          font-size: 32px;\r\n        }\r\n        .otp-banner img {\r\n          max-width: 100%;\r\n          height: auto;\r\n        }\r\n        .content {\r\n          padding: 30px;\r\n        }\r\n        .footer {\r\n          font-size: 14px;\r\n        }\r\n      }\r\n\r\n      /* Styles for large screens */\r\n      @media (min-width: 1024px) {\r\n        .container {\r\n          width: 60%;\r\n          max-width: 800px; /* Giới hạn chiều rộng tối đa */\r\n        }\r\n        .logo img {\r\n          height: 45px;\r\n        }\r\n        .heading {\r\n          font-size: 38px;\r\n        }\r\n        .otp-banner img {\r\n          max-width: 100%;\r\n          height: auto;\r\n        }\r\n        .content {\r\n          padding: 40px 48px;\r\n        }\r\n        .footer {\r\n          font-size: 16px;\r\n        }\r\n      }\r\n\r\n      /* Căn giữa nội dung */\r\n      .container {\r\n        margin: 0 auto;\r\n      }\r\n    </style>\r\n  </head>\r\n  <body style=\"font-family: 'Poppins', sans-serif; background-color: #101010; color: #ffffff; border-radius: 16px\">\r\n    <div style=\"display: table; width: 100%\">\r\n      <div style=\"display: table-cell; vertical-align: middle\">\r\n        <div class=\"container\" style=\"padding: 24px\">\r\n          <div class=\"logo\" style=\"width: 100%\">\r\n            <img\r\n              src=\"https://raw.githubusercontent.com/ninehcobra/free-host-image/main/cinema-logo.png\"\r\n              alt=\"logo\"\r\n              style=\"height: 45px\"\r\n            />\r\n          </div>\r\n          <div style=\"margin-top: 32px; text-align: center\">\r\n            <div class=\"heading\" style=\"font-size: 38px; font-weight: 700\">Buy ticket successfully</div>\r\n            <div style=\"margin-top: 12px\">\r\n              <img\r\n                class=\"otp-banner\"\r\n                src=\"https://raw.githubusercontent.com/ninehcobra/free-host-image/main/congrat.png\"\r\n                alt=\"otp-banner\"\r\n                style=\"height: 200px\"\r\n              />\r\n              <div class=\"content\" style=\"padding: 40px 48px; background-color: #18181a\">\r\n                <div style=\"font-weight: 200; font-size: 14px; text-align: justify; line-height: 1.6\">\r\n                  Thank you for trusting and booking movie tickets from our application. Please use the QR code I send\r\n                  below at the counter to enter the theater.\r\n                </div>\r\n              </div>\r\n            </div>\r\n          </div>\r\n          <div class=\"footer\" style=\"margin-top: 32px; text-align: center; font-size: 14px\">\r\n            Glad you're here, PC Team\r\n          </div>\r\n          <div style=\"margin-top: 24px; text-align: center\">\r\n            <ul style=\"list-style: none; padding: 0\">\r\n              <li style=\"display: inline-block; margin-right: 4px\">\r\n                <a href=\"/\" style=\"color: #103fcc; font-weight: 600; text-decoration: none\">QS</a>\r\n              </li>\r\n              <li style=\"display: inline-block; margin-right: 4px; color: #ffffff\">|</li>\r\n              <li style=\"display: inline-block; margin-right: 4px\">\r\n                <a href=\"/\" style=\"color: #103fcc; font-weight: 600; text-decoration: none\">Privacy Policy</a>\r\n              </li>\r\n              <li style=\"display: inline-block; margin-right: 4px; color: #ffffff\">|</li>\r\n              <li style=\"display: inline-block\">\r\n                <a href=\"/\" style=\"color: #103fcc; font-weight: 600; text-decoration: none\">Support</a>\r\n              </li>\r\n            </ul>\r\n          </div>\r\n        </div>\r\n      </div>\r\n    </div>\r\n  </body>\r\n</html>\r\n"; // Nội dung email là HTML (bắt đầu thẻ html)

                    // Thêm nội dung email, ví dụ:
                  

                    // Gửi email với nội dung là HTML và đính kèm tệp QR Code
                    SendEmail(userEmail, emailSubject, emailBody, attachments);

                    // Khôi phục các giá trị mặc định sau khi mua vé thành công
                    RestoreDefault();

                    // Load lại dữ liệu (tuỳ chọn)
                    this.OnLoad(new EventArgs());
                }
            }
        }


        private Bitmap GenerateQRCode(string data)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            EncodingOptions options = new EncodingOptions()
            {
                Width = 300, // Độ rộng của mã QR
                Height = 300, // Chiều cao của mã QR
                Margin = 0 // Lề ngoài của mã QR
            };
            writer.Options = options;
            Bitmap qrCodeBitmap = writer.Write(data);
            return qrCodeBitmap;
        }

        private void SendEmail(string recipientEmail, string subject, string body, List<Attachment> attachments = null)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("chinhtnc2903@gmail.com"); // Địa chỉ email gửi
                    mail.To.Add(recipientEmail); // Địa chỉ email nhận
                    mail.Subject = subject; // Tiêu đề email
                    mail.Body = body; // Nội dung email
                    mail.IsBodyHtml = true; // Đặt email là HTML

                    // Đính kèm các tệp tin (nếu có)
                    if (attachments != null)
                    {
                        foreach (var attachment in attachments)
                        {
                            mail.Attachments.Add(attachment);
                        }
                    }

                    // Gửi email
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com")) // Thay thế bằng SMTP server của bạn
                    {
                        smtp.Port = 587; // Cổng SMTP
                        smtp.Credentials = new System.Net.NetworkCredential("chinhtnc2903@gmail.com", "nxys xhgi gkip zhnz"); // Thay thế bằng thông tin đăng nhập của bạn
                        smtp.EnableSsl = true; // Bật SSL để bảo vệ thông tin
                        smtp.Send(mail); // Gửi email
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi gửi email: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmClient.clientUC = "movie";
            frmClient.RenderContent();
        }
    }
}
