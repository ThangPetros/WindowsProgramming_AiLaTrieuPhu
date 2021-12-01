using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_AiLaTrieuPhu_Thang
{
    class BLL
    {
        DAL dal = new DAL();
        public DataTable selectCauHoi(String capdo)
        {
            String sql = "SELECT * FROM " + capdo +"";
            DataTable table = new DataTable();
            table = dal.GetTable(sql);
            return table;
        }
        public DataTable getDSXepHang()
        {
            String sql = "SELECT tenNguoiChoi, maxCauHoi, sumTienThuong FROM TAIKHOAN";
            DataTable table = new DataTable();
            table = dal.GetTable(sql);
            return table;
        }
        public bool kiemTraDangNhap(string tendn, string mk)
        {
            String sql = "SELECT * FROM TAIKHOAN WHERE tenDangNhap = '" + tendn + "' AND matKhau = '" + mk + "'";
            DataTable table = new DataTable();
            table = dal.GetTable(sql);
            int dem = table.Rows.Count;
            if(dem == 1)
            {
                return true;
            }
            return false;
        }
        public bool kiemTraDangKy(string tendn)
        {
            String sql = "SELECT * FROM TAIKHOAN WHERE tenDangNhap = '" + tendn + "'";
            DataTable table = new DataTable();
            table = dal.GetTable(sql);
            int dem = table.Rows.Count;
            if (dem == 1)
            {
                return true;
            }
            return false;
        }
        public void insertTaiKhoan(string tendangnhap, string matkhau, string tennguoichoi)
        {
            string sql = "insert into TAIKHOAN values('" + tendangnhap + "', '" + matkhau + "', N'" + tennguoichoi + "', 0, 0)";
            dal.ExecNonQuery(sql);
        }
        public void updateTaiKhoan(string tendangnhap, int maxcauhoi, int sumtienthuong)
        {
            String sql = "UPDATE TAIKHOAN SET maxCauHoi = '" + maxcauhoi +"', sumTienThuong = '"+ sumtienthuong +"' WHERE tenDangNhap = '"+ tendangnhap +"'";
            dal.ExecNonQuery(sql);
        }
        public int getMaxCauHoi(string tendn)
        {
            String sql = "SELECT maxCauHoi FROM TAIKHOAN WHERE tenDangNhap = '" + tendn + "'";
            DataTable table = new DataTable();
            table = dal.GetTable(sql);
            int maxcauhoi = Convert.ToInt32(table.Rows[0][0].ToString());
            return maxcauhoi;
        }
        public int getSumTienThuong(string tendn)
        {
            String sql = "SELECT sumTienThuong FROM TAIKHOAN WHERE tenDangNhap = '" + tendn + "'";
            DataTable table = new DataTable();
            table = dal.GetTable(sql);
            int sumtienthuong = Convert.ToInt32(table.Rows[0][0].ToString());
            return sumtienthuong;
        }
    }
}
