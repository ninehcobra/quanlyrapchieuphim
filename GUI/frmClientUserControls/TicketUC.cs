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
using static GUI.DAO.TicketDAO;

namespace GUI.frmClientUserControls
{
    public partial class TicketUC : UserControl
    {
        User User;
        public TicketUC(User user)
        {
            InitializeComponent();
            User = user;
            LoadGroupedTickets(User.ID);
        }

        void LoadGroupedTickets(string userId)
        {
            List<GroupedTicket> listGroupedTicket = TicketDAO.GetGroupedTicketsByUser(userId);
            dtgvTicket.DataSource = listGroupedTicket;
        }

        private void dtgvTicket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dtgvTicket.Rows[e.RowIndex];

                // Lấy dữ liệu từ dòng hiện tại để lấy thông tin vé nhóm
                GroupedTicket groupedTicket = new GroupedTicket()
                {
                    ShowTimeID = row.Cells["ShowTimeID"].Value.ToString(),
                    ShowTime = Convert.ToDateTime(row.Cells["ShowTime"].Value),
                    MovieName = row.Cells["MovieName"].Value.ToString(),
                    RoomName = row.Cells["RoomName"].Value.ToString(),
                    Seats = row.Cells["Seats"].Value.ToString(),
                    TotalPrice = Convert.ToSingle(row.Cells["TotalPrice"].Value)
                };

              

                // Hoặc hiển thị mã QR cho thông tin nhóm vé
                frmQRCODE frmQRCODE = new frmQRCODE(groupedTicket);
                frmQRCODE.ShowDialog();
            }
        }
    }
}
