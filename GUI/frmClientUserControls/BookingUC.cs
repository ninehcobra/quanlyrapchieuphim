using GUI.DAO;
using GUI.DTO;
using GUI.frmAdminUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using static GUI.DAO.TicketDAO;

namespace GUI.frmClientUserControls
{
    public partial class BookingUC : UserControl
    {
        ShowTimes Times;
        Movie Movie;

        int SIZE = 25;//Size của ghế
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
        Customer customer;
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

            lblPoint.Text = plusPoint.ToString();

            DataTable data = CustomerDAO.GetCustomerMember(User.ID, User.HoTen);
            customer = new Customer(data.Rows[0]);
            lblPoint.Text = customer.Point.ToString();

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
                lblPlusPoint.Text = plusPoint + "";

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
            StringBuilder ticketIDs = new StringBuilder();
            foreach (Button btn in listSeatSelected)
            {
                message += "[" + btn.Text + "] ";
                Ticket ticket = btn.Tag as Ticket;
                ticketIDs.Append(ticket.ID + ",");
            }
            message += "\nKhông?";
            DialogResult result = MessageBox.Show(message, "Hỏi Mua",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                int ret = 0;

                // Xóa dấu phẩy cuối cùng
                if (ticketIDs.Length > 0)
                {
                    ticketIDs.Length--;
                }

                // Tạo mã QR duy nhất cho chuỗi tất cả các mã vé đã đặt
                Bitmap qrCode = GenerateQRCode(ticketIDs.ToString());

                // Lưu mã QR vào một tệp tạm thời
                string qrCodeFilePath = Path.Combine(Path.GetTempPath(), $"QRCode_{Guid.NewGuid()}.png");
                qrCode.Save(qrCodeFilePath);

                List<Attachment> attachments = new List<Attachment>
        {
            new Attachment(qrCodeFilePath)
        };

                // Lưu thông tin về các vé và tính toán tổng tiền
                List<string> seatNames = new List<string>();
                float totalAmount = 0;

                foreach (Button btn in listSeatSelected)
                {
                    Ticket ticket = btn.Tag as Ticket;
                    ret += TicketDAO.BuyTicket(ticket.ID, ticket.Type, User.ID, ticket.Price);
                    seatNames.Add(ticket.SeatName);
                    totalAmount += ticket.Price;
                }

                customer.Point += plusPoint;
                CustomerDAO.UpdatePointCustomer(customer.ID, customer.Point);

                if (ret == listSeatSelected.Count)
                {
                    MessageBox.Show("Bạn đã mua vé thành công!");
                    plusPoint = 0;
                    lblPlusPoint.Text = plusPoint.ToString();

                    // Render lại form (tuỳ chọn)
                    RenderForm();

                    // Lấy thông tin chi tiết về phim và giờ chiếu dựa trên ID vé đầu tiên
                    Ticket firstTicket = listSeatSelected[0].Tag as Ticket;
                    MovieShowTime movieShowTime = TicketDAO.GetMovieShowTimeByTicketId(firstTicket.ID);

                    // Tính toán tổng tiền, số tiền giảm và số tiền cần trả
                    float discountAmount = discount;
                    float amountToPay = totalAmount - discountAmount;

                    // Tạo định dạng tiền tệ VNĐ
                    CultureInfo culture = new CultureInfo("vi-VN");
                    NumberFormatInfo nfi = culture.NumberFormat;
                    nfi.CurrencySymbol = "VNĐ";

                    // Gửi email chứa các thông tin mua vé và mã QR cho người mua
                    string userEmail = User.Email; // Địa chỉ email người mua
                    string emailSubject = "Xác nhận mua vé"; // Tiêu đề email

                    string emailBody = $@"
            <!doctype html>
            <html lang='en'>
            <head>
                <meta charset='UTF-8' />
                <meta name='viewport' content='width=device-width, initial-scale=1.0' />
                <title>OTP</title>
                <style>
                    /* Styles for small screens */
                    @media (max-width: 767px) {{
                        .container {{
                            width: 90%;
                            padding: 12px;
                        }}
                        .logo img {{
                            height: 30px;
                        }}
                        .heading {{
                            font-size: 24px;
                        }}
                        .otp-banner img {{
                            max-width: 100%;
                            height: auto;
                        }}
                        .content {{
                            padding: 20px;
                        }}
                        .footer {{
                            font-size: 12px;
                        }}
                    }}

                    /* Styles for medium screens */
                    @media (min-width: 768px) and (max-width: 1023px) {{
                        .container {{
                            width: 80%;
                        }}
                        .logo img {{
                            height: 40px;
                        }}
                        .heading {{
                            font-size: 32px;
                        }}
                        .otp-banner img {{
                            max-width: 100%;
                            height: auto;
                        }}
                        .content {{
                            padding: 30px;
                        }}
                        .footer {{
                            font-size: 14px;
                        }}
                    }}

                    /* Styles for large screens */
                    @media (min-width: 1024px) {{
                        .container {{
                            width: 60%;
                            max-width: 800px; /* Giới hạn chiều rộng tối đa */
                        }}
                        .logo img {{
                            height: 45px;
                        }}
                        .heading {{
                            font-size: 38px;
                        }}
                        .otp-banner img {{
                            max-width: 100%;
                            height: auto;
                        }}
                        .content {{
                            padding: 40px 48px;
                        }}
                        .footer {{
                            font-size: 16px;
                        }}
                    }}

                    /* Căn giữa nội dung */
                    .container {{
                        margin: 0 auto;
                    }}
                </style>
            </head>
            <body style='font-family: Poppins, sans-serif; background-color: #101010; color: #ffffff; border-radius: 16px'>
                <div style='display: table; width: 100%'>
                    <div style='display: table-cell; vertical-align: middle'>
                        <div class='container' style='padding: 24px'>
                            <div class='logo' style='width: 100%'>
                                <img
                                    src='https://raw.githubusercontent.com/ninehcobra/free-host-image/main/cinema-logo.png'
                                    alt='logo'
                                    style='height: 45px'
                                />
                            </div>
                            <div style='margin-top: 32px; text-align: center'>
                                <div class='heading' style='font-size: 38px; font-weight: 700'>Buy ticket successfully</div>
                                <div style='margin-top: 12px'>
                                    <img
                                        class='otp-banner'
                                        src='https://raw.githubusercontent.com/ninehcobra/free-host-image/main/congrat.png'
                                        alt='otp-banner'
                                        style='height: 200px'
                                    />
                                    <div class='content' style='padding: 40px 48px; background-color: #18181a; color:white !important'>
                                        <div style='font-weight: 200; font-size: 14px; text-align: justify; line-height: 1.6'>
                                            Thank you for trusting and booking movie tickets from our application. Please use the QR code attached below at the counter to enter the theater.
                                        </div>
                                        <div style='font-weight: 200; font-size: 14px; text-align: justify; line-height: 1.6; margin-top: 20px;'>
                                            <p><strong>Movie:</strong> {movieShowTime.TenPhim}</p>
                                            <p><strong>Showtime:</strong> {movieShowTime.ThoiGianChieu}</p>
                                            <p><strong>Room:</strong> {movieShowTime.TenPhong}</p>
                                            <p><strong>Screen Type:</strong> {movieShowTime.TenMH}</p>
                                            <p><strong>Seats:</strong> {string.Join(", ", seatNames)}</p>
                                            <p><strong>Total Price:</strong> {totalAmount.ToString("C", nfi)}</p>
                                            <p><strong>Discount:</strong> {discountAmount.ToString("C", nfi)}</p>
                                            <p><strong>Amount to Pay:</strong> {amountToPay.ToString("C", nfi)}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class='footer' style='margin-top: 32px; text-align: center; font-size: 14px'>
                                Glad you're here, PC Team
                            </div>
                            <div style='margin-top: 24px; text-align: center'>
                                <ul style='list-style: none; padding: 0'>
                                    <li style='display: inline-block; margin-right: 4px'>
                                        <a href='/' style='color: #103fcc; font-weight: 600; text-decoration: none'>QS</a>
                                    </li>
                                    <li style='display: inline-block; margin-right: 4px; color: #ffffff'>|</li>
                                    <li style='display: inline-block; margin-right: 4px'>
                                        <a href='/' style='color: #103fcc; font-weight: 600; text-decoration: none'>Privacy Policy</a>
                                    </li>
                                    <li style='display: inline-block; margin-right: 4px; color: #ffffff'>|</li>
                                    <li style='display: inline-block'>
                                        <a href='/' style='color: #103fcc; font-weight: 600; text-decoration: none'>Support</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </body>
            </html>
            "; // Nội dung email là HTML (bắt đầu thẻ html)

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
            catch (SmtpException smtpEx)
            {
                MessageBox.Show("Đã xảy ra lỗi SMTP khi gửi email: " + smtpEx.Message + "\n" + smtpEx.StackTrace);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi gửi email: " + ex.Message + "\n" + ex.StackTrace);
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmClient.clientUC = "movie";
            frmClient.RenderContent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int freeTickets = (int)numericFreeTickets.Value;
            if (freeTickets <= 0) return;

            if (freeTickets > listSeat.Count)
            {
                MessageBox.Show("BẠN CHỈ ĐỔI ĐƯỢC TỐT ĐA [" + listSeatSelected.Count + "] VÉ", "THÔNG BÁO");
                return;
            }
            int pointFreeTicket = freeTickets * 20;
            if (customer.Point < pointFreeTicket)
            {
                MessageBox.Show("BẠN KHÔNG ĐỦ ĐIỂM TÍCH LŨY ĐỂ ĐỔI [" + freeTickets + "] VÉ", "THÔNG BÁO");
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("BẠN CÓ MUỐN DÙNG ĐIỂM TÍCH LŨY ĐỂ ĐỔI [" + freeTickets + "] VÉ MIỄN PHÍ KHÔNG?",
                                        "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    customer.Point -= pointFreeTicket;
                    plusPoint -= freeTickets;

                    if (CustomerDAO.UpdatePointCustomer(customer.ID, customer.Point))
                    {
                        MessageBox.Show("BẠN ĐÃ DỔI ĐƯỢC [" + freeTickets + "] VÉ MIỄN PHÍ THÀNH CÔNG", "THÔNG BÁO");
                    }
                    lblPoint.Text = "" + customer.Point;
                    lblPlusPoint.Text = "" + plusPoint;

                    for (int i = 0; i < listSeatSelected.Count && freeTickets > 0; i++)
                    {
                        Ticket ticket = listSeatSelected[i].Tag as Ticket;
                        if (ticket.Price != 0)
                        {
                            discount += ticket.Price;
                            ticket.Price = 0;
                            freeTickets--;
                        }
                    }

                    payment = total - discount;
                    LoadBill();
                }
            }
        }
    }
}
