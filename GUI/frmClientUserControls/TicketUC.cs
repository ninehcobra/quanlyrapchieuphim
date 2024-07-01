using GUI.DAO;
using GUI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.frmClientUserControls
{
    public partial class TicketUC : UserControl
    {
        User User;
        public TicketUC(User user)
        {
            InitializeComponent();
            User = user;
            LoadTicketsBoughtByShowTimes(User.ID);


        }

        void LoadTicketsBoughtByShowTimes(string id)
        {
            List<Ticket> listTicket = TicketDAO.GetUserListTickets(id);
            dtgvTicket.DataSource = listTicket;
        }

        private void dtgvTicket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dtgvTicket.Rows[e.RowIndex];

                // Lấy dữ liệu từ dòng hiện tại để lấy thông tin vé
                Ticket ticket = new Ticket()
                {
                    ID = row.Cells["ID"].Value.ToString(), // Thay "ID" bằng tên cột ID trong DataGridView
                    SeatName = row.Cells["SeatName"].Value.ToString(),
                    // Lấy các thông tin khác tương tự
                    // Ví dụ: ticket.Price = Convert.ToSingle(row.Cells["Price"].Value);
                };

                // Hiển thị thông tin vé (ví dụ: MessageBox)
                frmQRCODE frmQRCODE = new frmQRCODE(ticket.ID);
                frmQRCODE.ShowDialog();

            }
        }
    }
}
