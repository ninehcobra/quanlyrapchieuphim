using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GUI.DAO
{
    public class TicketDAO
    {
        public static List<Ticket> GetListTicketsByShowTimes(string showTimesID)
        {
            List<Ticket> listTicket = new List<Ticket>();
            string query = "select * from Ve where idLichChieu = '" + showTimesID + "'";
            DataTable data = DataProvider.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Ticket ticket = new Ticket(row);
                listTicket.Add(ticket);
            }
            return listTicket;
        }

        public static List<Ticket> GetListTicketsBoughtByShowTimes(string showTimesID)
        {
            List<Ticket> listTicket = new List<Ticket>();
            string query = "select * from Ve where idLichChieu = '" + showTimesID + "' and TrangThai = 1";
            DataTable data = DataProvider.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Ticket ticket = new Ticket(row);
                listTicket.Add(ticket);
            }
            return listTicket;
        }

        public static List<Ticket> GetUserListTickets(string userId)
        {
            List<Ticket> listTicket = new List<Ticket>();
            string query = "select * from Ve where idKhachHang = '" + userId + "' and TrangThai = 1";
            DataTable data = DataProvider.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Ticket ticket = new Ticket(row);
                listTicket.Add(ticket);
            }
            return listTicket;
        }

        public static int CountToltalTicketByShowTime(string showTimesID)
        {
            string query = "Select count (id) from Ve where idLichChieu ='" + showTimesID + "'";
            return (int)DataProvider.ExecuteScalar(query);
        }
        public static int CountTheNumberOfTicketsSoldByShowTime(string showTimesID)
        {
            string query = "Select count (id) from Ve where idLichChieu ='" + showTimesID + "' and TrangThai = 1 ";
            return (int)DataProvider.ExecuteScalar(query);
        }
        public static int BuyTicket(string ticketID, int type, float price)
        {
            string query = "Update dbo.Ve set TrangThai = 1, LoaiVe = "
                + type + ", TienBanVe =" + price + " where id = '" + ticketID + "'";
            return DataProvider.ExecuteNonQuery(query);
        }
        public static int BuyTicket(string ticketID, int type, string customerID, float price)
        {
            string query = "Update dbo.Ve set TrangThai = 1, LoaiVe = "+ type 
                + ", idKhachHang =N'" + customerID + "', TienBanVe =" + price +" where id = '" + ticketID + "'";
            return DataProvider.ExecuteNonQuery(query);
        }

        public static int InsertTicketByShowTimes(string showTimesID, string seatName)
        {
            string query = "USP_InsertTicketByShowTimes @idlichChieu , @maGheNgoi";
            return DataProvider.ExecuteNonQuery(query, new object[] { showTimesID, seatName });
        }

        public static int DeleteTicketsByShowTimes(string showTimesID)
        {
            string query = "USP_DeleteTicketsByShowTimes @idlichChieu";
            return DataProvider.ExecuteNonQuery(query, new object[] { showTimesID });
        }

        public static MovieShowTime GetMovieShowTimeByTicketId(string ticketId)
        {
            string query = @"
                SELECT 
                    p.TenPhim,
                    p.MoTa,
                    p.ThoiLuong,
                    p.NgayKhoiChieu,
                    p.NgayKetThuc,
                    p.SanXuat,
                    p.DaoDien,
                    p.NamSX,
                    p.ApPhich,
                    lc.ThoiGianChieu,
                    lc.GiaVe,
                    pc.TenPhong,
                    mh.TenMH
               FROM dbo.Ve v
JOIN dbo.LichChieu lc ON v.idLichChieu = lc.id
JOIN dbo.DinhDangPhim ddp ON lc.idDinhDang = ddp.id
JOIN dbo.Phim p ON ddp.idPhim = p.id
JOIN dbo.LoaiManHinh mh ON ddp.idLoaiManHinh = mh.id
JOIN dbo.PhongChieu pc ON lc.idPhong = pc.id
                WHERE v.id = @ticketId";

            DataTable data = DataProvider.ExecuteQuery(query, new object[] { ticketId });

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                MovieShowTime movieShowTime = new MovieShowTime
                {
                    TenPhim = row["TenPhim"].ToString(),
                    MoTa = row["MoTa"].ToString(),
                    ThoiLuong = float.Parse(row["ThoiLuong"].ToString()),
                    NgayKhoiChieu = DateTime.Parse(row["NgayKhoiChieu"].ToString()),
                    NgayKetThuc = DateTime.Parse(row["NgayKetThuc"].ToString()),
                    SanXuat = row["SanXuat"].ToString(),
                    DaoDien = row["DaoDien"].ToString(),
                    NamSX = int.Parse(row["NamSX"].ToString()),
                    ApPhich = (byte[])row["ApPhich"],
                    ThoiGianChieu = DateTime.Parse(row["ThoiGianChieu"].ToString()),
                    GiaVe = float.Parse(row["GiaVe"].ToString()),
                    TenPhong = row["TenPhong"].ToString(),
                    TenMH = row["TenMH"].ToString()
                };

                return movieShowTime;
            }

            return null;
        
    }
        public class MovieShowTime
        {
            public string TenPhim { get; set; }
            public string MoTa { get; set; }
            public float ThoiLuong { get; set; }
            public DateTime NgayKhoiChieu { get; set; }
            public DateTime NgayKetThuc { get; set; }
            public string SanXuat { get; set; }
            public string DaoDien { get; set; }
            public int NamSX { get; set; }
            public byte[] ApPhich { get; set; }
            public DateTime ThoiGianChieu { get; set; }
            public float GiaVe { get; set; }
            public string TenPhong { get; set; }
            public string TenMH { get; set; }
        }
    }
}
