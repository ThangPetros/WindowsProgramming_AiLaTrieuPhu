using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace BTL_AiLaTrieuPhu_Thang
{
    public partial class AiLaTrieuPhu : Form
    {
        BLL bll = new BLL();

        List<string> noiDungCauHoi;
        List<string> dapAnA;
        List<string> dapAnB;
        List<string> dapAnC;
        List<string> dapAnD;
        List<string> dapAnDung;
        List<string> chuThich;
        List<int> tienThuong = new List<int>();

        int tienRaVe;
        int viTriCauHoi;
        string luuDapAn;

        bool troGiup5050;
        bool troGiupGoiDT;
        bool troGiupKhanGia;
        bool troGiupToTuVan;

        int demnguoc;
        int chondapan;
        int time5050;
        int doidapan;
        int goidt;
        int totuvan;
        int khangia;
        int chuthich;

        string luuTenDangNhap;
        int luuMaxCauHoi;
        int luuSumTienThuong;
        
        SoundPlayer soundDangNhap = new SoundPlayer("NhacDangNhap.wav");
        SoundPlayer soundTrangChu = new SoundPlayer("ChoTrangChu.wav");
        SoundPlayer soundCauHoi = new SoundPlayer("CauHoi.wav");
        SoundPlayer soundToTuVan = new SoundPlayer("NhacToTuVan.wav");
        SoundPlayer soundKhanGia = new SoundPlayer("NhacKhanGia.wav");
        SoundPlayer soundNhanThuong = new SoundPlayer("NhacNhanThuong.wav");

        public AiLaTrieuPhu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tienThuong.Add(200000);
            tienThuong.Add(400000);
            tienThuong.Add(600000);
            tienThuong.Add(1000000);
            tienThuong.Add(2000000);
            tienThuong.Add(3000000);
            tienThuong.Add(6000000);
            tienThuong.Add(10000000);
            tienThuong.Add(14000000);
            tienThuong.Add(22000000);
            tienThuong.Add(30000000);
            tienThuong.Add(40000000);
            tienThuong.Add(60000000);
            tienThuong.Add(85000000);
            tienThuong.Add(150000000);

            grbDangNhap.Visible = true;
            grbDangKy.Visible = false;
            grbTrangChu.Visible = false;
            grbGiaoDienChoi.Visible = false;
            grbHuongDan.Visible = false;
            grbGiaoDienNhanThuong.Visible = false;
            grbGiaoDienGoiDT.Visible = false;
            grbGiaoDienToTuVan.Visible = false;
            grbGiaoDienKhanGia.Visible = false;
            grbXepHang.Visible = false;
            grbGiaoDienChuThich.Visible = false;

            
            soundDangNhap.Play();
        }

        public void getDSCauHoi()
        {
            noiDungCauHoi = new List<string>();
            dapAnA = new List<string>();
            dapAnB = new List<string>();
            dapAnC = new List<string>();
            dapAnD = new List<string>();
            dapAnDung = new List<string>();
            chuThich = new List<string>();

            DataTable tblCapDo1 = new DataTable();
            tblCapDo1 = bll.selectCauHoi("CAPDO1");
            DataTable tblCapDo2 = new DataTable();
            tblCapDo2 = bll.selectCauHoi("CAPDO2");
            DataTable tblCapDo3 = new DataTable();
            tblCapDo3 = bll.selectCauHoi("CAPDO3");

            getDongCauHoi(tblCapDo1);
            getDongCauHoi(tblCapDo2);
            getDongCauHoi(tblCapDo3);
        }

        public void getDongCauHoi(DataTable tl)
        {
            List<int> listViTriCauHoi = new List<int>();
            List<int> da = new List<int>();
            listViTriCauHoi = randomDSCauHoi(tl.Rows.Count);

            foreach(int vt in listViTriCauHoi)
            {
                da = randomDSDapAn();
                noiDungCauHoi.Add(tl.Rows[vt][1].ToString());
                dapAnA.Add(tl.Rows[vt][da[0]].ToString());
                dapAnB.Add(tl.Rows[vt][da[1]].ToString());
                dapAnC.Add(tl.Rows[vt][da[2]].ToString());
                dapAnD.Add(tl.Rows[vt][da[3]].ToString());
                dapAnDung.Add(tl.Rows[vt][6].ToString());
                chuThich.Add(tl.Rows[vt][7].ToString());
            }
        }

        public List<int> randomDSCauHoi(int soluong)
        {
            List<int> ret = new List<int>();
            Random ran = new Random();
            int vitri;
            List<int> list = new List<int>();
            for(int i = 0; i < soluong; i++)
            {
                list.Add(i);
            }
            for(int i = 0; i < 5; i++)
            {
                vitri = ran.Next(list.Count - 1);
                ret.Add(list[vitri]);
                list.RemoveAt(vitri);
            }
            return ret;
        }

        public List<int> randomDSDapAn()
        {
            List<int> ret = new List<int>();
            Random ran = new Random();
            int vitri;
            List<int> list = new List<int>();
            for (int i = 2; i < 6; i++)
            {
                list.Add(i);
            }
            for (int i = 0; i < 4; i++)
            {
                vitri = ran.Next(list.Count - 1);
                ret.Add(list[vitri]);
                list.RemoveAt(vitri);
            }
            return ret;
        }

        public void batDauChoi()
        {
            tmRangBuoc.Start();

            goidt = 40;
            time5050 = 2;
            totuvan = 10;
            khangia = 20;

            btn5050.Enabled = true;
            btnGoiDT.Enabled = true;
            btnKhanGia.Enabled = true;
            btnToTuVan.Enabled = false;

            troGiup5050 = false;
            troGiupGoiDT = false;
            troGiupKhanGia = false;
            troGiupToTuVan = true;

            viTriCauHoi = 0;
            tienRaVe = 0;

            getDSCauHoi();
            hienThiCauHoi();
        }

        public void hienThiCauHoi()
        {
            doidapan = 0;
            chondapan = 0;
            demnguoc = 30;
            chuthich = 10;
            soundCauHoi.Play();
            tmRangBuoc.Start();

            btnDapAnA.BackColor = Color.Transparent;
            btnDapAnB.BackColor = Color.Transparent;
            btnDapAnC.BackColor = Color.Transparent;
            btnDapAnD.BackColor = Color.Transparent;
            btnDapAnA.Enabled = true;
            btnDapAnB.Enabled = true;
            btnDapAnC.Enabled = true;
            btnDapAnD.Enabled = true;

            btnCauHoi.Text = noiDungCauHoi[viTriCauHoi];
            btnDapAnA.Text = dapAnA[viTriCauHoi];
            btnDapAnB.Text = dapAnB[viTriCauHoi];
            btnDapAnC.Text = dapAnC[viTriCauHoi];
            btnDapAnD.Text = dapAnD[viTriCauHoi];
            lblSoTien.Text = tienThuong[viTriCauHoi].ToString();
            lblViTri.Text = (viTriCauHoi + 1).ToString();
        }

        public void kiemTraCauHoi(string dapan)
        {
            if(dapan == dapAnDung[viTriCauHoi])
            {
                traLoiDung();
            }
            else
            {
                traLoiSai();
            }
        }

        public void traLoiDung()
        {
            SoundPlayer soundDapAnDung = new SoundPlayer("DapAnDung.wav");
            soundDapAnDung.Play();
            if (luuDapAn == btnDapAnA.Text)
            {
                btnDapAnA.BackColor = Color.Lime;
            }
            else if (luuDapAn == btnDapAnB.Text)
            {
                btnDapAnB.BackColor = Color.Lime;
            }
            else if (luuDapAn == btnDapAnC.Text)
            {
                btnDapAnC.BackColor = Color.Lime;
            }
            else if (luuDapAn == btnDapAnD.Text)
            {
                btnDapAnD.BackColor = Color.Lime;
            }
            tmDoiDapAnDung.Start();
        }

        public void nextCauHoi()
        {
            if (viTriCauHoi == 14)
            {
                soundNhanThuong.Play();
                tienRaVe = tienThuong[viTriCauHoi];
                btnThongTinNhanThuong.Text = "Chúc mừng!" + Environment.NewLine + "Bạn đã trở thành người chiến thắng!" + Environment.NewLine + "Số tiền thưởng bạn nhận được là:" + Environment.NewLine + tienRaVe.ToString() + " VND";
                grbGiaoDienNhanThuong.Visible = true;
                grbGiaoDienChoi.Visible = false;
            }
            else
            {
                if (viTriCauHoi == 4)
                {
                    tienRaVe = tienThuong[viTriCauHoi];
                    troGiupToTuVan = false;
                    btnToTuVan.Enabled = true;
                }
                if (viTriCauHoi == 9)
                {
                    tienRaVe = tienThuong[viTriCauHoi];
                }
                viTriCauHoi++;
                hienThiCauHoi();
            }
        }

        public void traLoiSai()
        {
            SoundPlayer soundDapAnSai = new SoundPlayer("DapAnSai.wav");
            soundDapAnSai.Play();

            if(luuDapAn == btnDapAnA.Text)
            {
                btnDapAnA.BackColor = Color.Red;
            }
            else if (luuDapAn == btnDapAnB.Text)
            {
                btnDapAnB.BackColor = Color.Red;
            }
            else if (luuDapAn == btnDapAnC.Text)
            {
                btnDapAnC.BackColor = Color.Red;
            }
            else if (luuDapAn == btnDapAnD.Text)
            {
                btnDapAnD.BackColor = Color.Red;
            }
            if (dapAnDung[viTriCauHoi] == btnDapAnA.Text)
            {
                btnDapAnA.BackColor = Color.Lime;
            }
            else if (dapAnDung[viTriCauHoi] == btnDapAnB.Text)
            {
                btnDapAnB.BackColor = Color.Lime;
            }
            else if (dapAnDung[viTriCauHoi] == btnDapAnC.Text)
            {
                btnDapAnC.BackColor = Color.Lime;
            }
            else if (dapAnDung[viTriCauHoi] == btnDapAnD.Text)
            {
                btnDapAnD.BackColor = Color.Lime;
            }
            tmDoiDapAnSai.Start();
        }

        public void clickDapAn()
        {
            SoundPlayer soundChonDapAn = new SoundPlayer("ChonDapAn.wav");
            soundChonDapAn.Play();
        }

        public void rangBuocChonDapAn()
        {
            btnDapAnA.Enabled = false;
            btnDapAnB.Enabled = false;
            btnDapAnC.Enabled = false;
            btnDapAnD.Enabled = false;
            soundCauHoi.Stop();
            clickDapAn();
            tmRangBuoc.Stop();
            tmChonDapAn.Start();
        }


        private void btnThoatGame_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc muốn thoát chứ?", "Thông báo!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                soundDangNhap.Stop();
                this.Close();
            }
        }

        private void btnBatDauChoi_Click(object sender, EventArgs e)
        {
            soundTrangChu.Stop();
            grbGiaoDienChoi.Visible = true;
            grbTrangChu.Visible = false;
            batDauChoi();
        }

        private void btnDapAnA_Click(object sender, EventArgs e)
        {
            btnDapAnA.BackColor = Color.Orange;
            luuDapAn = btnDapAnA.Text;
            rangBuocChonDapAn();
        }

        private void btnDapAnB_Click(object sender, EventArgs e)
        {
            btnDapAnB.BackColor = Color.Orange;
            luuDapAn = btnDapAnB.Text;
            rangBuocChonDapAn();

        }

        private void btnDapAnC_Click(object sender, EventArgs e)
        {
            btnDapAnC.BackColor = Color.Orange;
            luuDapAn = btnDapAnC.Text;
            rangBuocChonDapAn();
        }

        private void btnDapAnD_Click(object sender, EventArgs e)
        {
            btnDapAnD.BackColor = Color.Orange;
            luuDapAn = btnDapAnD.Text;
            rangBuocChonDapAn();
        }

        private void btnDungChoi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc muốn dừng chơi chứ?", "Thông báo!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tmChonDapAn.Stop();
                soundCauHoi.Stop();
                soundNhanThuong.Play();
                btnThongTinNhanThuong.Text = "Bạn sẽ ra về với số tiền thưởng là:" + Environment.NewLine + tienRaVe.ToString() + " VND";
                grbGiaoDienNhanThuong.Visible = true;
                grbGiaoDienChoi.Visible = false;
            }
        }

        private void btnHuongDanQuayLai_Click(object sender, EventArgs e)
        {
            grbTrangChu.Visible = true;
            grbHuongDan.Visible = false;
        }

        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            grbHuongDan.Visible = true;
            grbTrangChu.Visible = false;
        }

        private void btnXepHang_Click(object sender, EventArgs e)
        {
            grbXepHang.Visible = true;
            grbTrangChu.Visible = false;
            soundTrangChu.Stop();
            soundCauHoi.Play();
            DataTable dsTaiKhoan = new DataTable();
            dsTaiKhoan = bll.getDSXepHang();

            DataView dtv = dsTaiKhoan.DefaultView;
            dtv.Sort = "maxCauHoi DESC";
            dsTaiKhoan = dtv.ToTable();
            dgvDSNguoiChoi.DataSource = dsTaiKhoan;
        }

        private void btnNhanThuong_Click(object sender, EventArgs e)
        {
            soundNhanThuong.Stop();
            if (luuMaxCauHoi < viTriCauHoi) luuMaxCauHoi = viTriCauHoi;
            luuSumTienThuong += tienRaVe;
            bll.updateTaiKhoan(luuTenDangNhap, luuMaxCauHoi, luuSumTienThuong);
            grbTrangChu.Visible = true;
            grbGiaoDienNhanThuong.Visible = false;
            soundTrangChu.Play();
        }

        private void btn5050_Click(object sender, EventArgs e)
        {
            if (!troGiup5050)
            {
                if(dapAnDung[viTriCauHoi] == btnDapAnA.Text)
                {
                    btnDapAnB.Enabled = false;
                    btnDapAnB.Text = "";
                    btnDapAnD.Enabled = false;
                    btnDapAnD.Text = "";
                }
                if (dapAnDung[viTriCauHoi] == btnDapAnB.Text)
                {
                    btnDapAnA.Enabled = false;
                    btnDapAnA.Text = "";
                    btnDapAnC.Enabled = false;
                    btnDapAnC.Text = "";
                }
                if (dapAnDung[viTriCauHoi] == btnDapAnC.Text)
                {
                    btnDapAnA.Enabled = false;
                    btnDapAnA.Text = "";
                    btnDapAnD.Enabled = false;
                    btnDapAnD.Text = "";
                }
                if (dapAnDung[viTriCauHoi] == btnDapAnD.Text)
                {
                    btnDapAnB.Enabled = false;
                    btnDapAnB.Text = "";
                    btnDapAnC.Enabled = false;
                    btnDapAnC.Text = "";
                }
                troGiup5050 = true;
                btn5050.Enabled = false;
                soundCauHoi.Stop();
                SoundPlayer sound5050 = new SoundPlayer("5050.wav");
                sound5050.Play();
                tm5050.Start();
            }
        }

        private void btnGoiDT_Click(object sender, EventArgs e)
        {
            if (!troGiupGoiDT)
            {
                troGiupGoiDT = true;
                btnGoiDT.Enabled = false;
                grbGiaoDienGoiDT.Visible = true;
                grbGiaoDienChoi.Visible = false;

                lblKetNoiGoiDT.Text = "";
                lblNguoiHoi.Text = "";
                lblNguoiDuocHoi.Text = "";
                lblCauHoi.Text = "";
                lblA.Text = "";
                lblB.Text = "";
                lblC.Text = "";
                lblD.Text = "";

                soundCauHoi.Stop();
                soundTrangChu.Play();
                tmRangBuoc.Stop();
                tmGoiDT.Start();
            }
        }

        private void btnToTuVan_Click(object sender, EventArgs e)
        {
            if (!troGiupToTuVan)
            {
                troGiupToTuVan = true;
                btnToTuVan.Enabled = false;
                grbGiaoDienToTuVan.Visible = true;
                grbGiaoDienChoi.Visible = false;

                tmRangBuoc.Stop();
                tmToTuVan.Start();
                soundCauHoi.Stop();
                soundToTuVan.Play();
            }
        }

        private void btnKhanGia_Click(object sender, EventArgs e)
        {
            if (!troGiupKhanGia)
            {
                troGiupKhanGia = true;
                btnKhanGia.Enabled = false;
                grbGiaoDienKhanGia.Visible = true;
                grbGiaoDienChoi.Visible = false;

                tmRangBuoc.Stop();
                tmKhanGia.Start();
                soundCauHoi.Stop();
                soundKhanGia.Play();
            }
        }
        
        private void tmRangBuoc_Tick(object sender, EventArgs e)
        {
            lblDemNguoc.Text = demnguoc.ToString();
            if(demnguoc == 0)
            {
                soundCauHoi.Stop();
                btnThongTinNhanThuong.Text = "Bạn đã hết thời gian trả lời câu hỏi!" + Environment.NewLine + "Số tiền thưởng bạn nhận được là:" + Environment.NewLine + tienRaVe.ToString();
                grbGiaoDienNhanThuong.Visible = true;
                grbGiaoDienChoi.Visible = false;
                tmRangBuoc.Stop();
            }
            demnguoc--;
        }

        private void tmDoiDapAnSai_Tick(object sender, EventArgs e)
        {
            if (doidapan == 3)
            {
                soundNhanThuong.Play();
                btnThongTinNhanThuong.Text = "Bạn đã trả lời sai!" + Environment.NewLine + "Số tiền thưởng bạn nhận được là:" + Environment.NewLine + tienRaVe.ToString() + " VND";
                grbGiaoDienNhanThuong.Visible = true;
                grbGiaoDienChoi.Visible = false;
                tmDoiDapAnSai.Stop();
            }
            doidapan++;
        }

        private void tmDoiDapAnDung_Tick(object sender, EventArgs e)
        {
            if (doidapan == 3)
            {
                tmChuThich.Start();
                tmDoiDapAnDung.Stop();
            }
            doidapan++;
        }

        private void tmGoiDT_Tick(object sender, EventArgs e)
        {
            switch (goidt)
            {
                case 39:
                    lblKetNoiGoiDT.Text = "Đang kết nối...";
                    break;
                case 37:
                    lblKetNoiGoiDT.Text = "Đã kết nối!";
                    break;
                case 35:
                    lblKetNoiGoiDT.Text = "";
                    lblNguoiHoi.Text = "Alo...o..o Mình đây, câu này khó quá!" + Environment.NewLine + "Bạn giúp mình với!";
                    break;
                case 33:
                    lblNguoiHoi.Text = "";
                    lblNguoiDuocHoi.Text = "Oke, mình sẽ cố gắng" + Environment.NewLine + "Bạn đọc câu hỏi đi!";
                    break;
                case 31:
                    lblNguoiDuocHoi.Text = "";
                    lblNguoiHoi.Text = "Bạn chú ý nghe rõ câu hỏi nhé";
                    break;
                case 29:
                    lblNguoiHoi.Text = "";
                    lblCauHoi.Text = "Câu hỏi: " + noiDungCauHoi[viTriCauHoi];
                    break;
                case 27:
                    lblA.Text = "A: " + dapAnA[viTriCauHoi];
                    break;
                case 25:
                    lblB.Text = "B: " + dapAnB[viTriCauHoi];
                    break;
                case 23:
                    lblC.Text = "C: " + dapAnC[viTriCauHoi];
                    break;
                case 21:
                    lblD.Text = "D: " + dapAnD[viTriCauHoi];
                    break;
                case 19:
                    lblNguoiDuocHoi.Text = "Khó nhỉ =))";
                    break;
                case 18:
                    lblNguoiDuocHoi.Text += Environment.NewLine + "Đợi mình vài giây nhé!";
                    break;
                case 16:
                    lblNguoiDuocHoi.Text += "";
                    lblNguoiHoi.Text = "Oke bạn!";
                    break;
                case 10:
                    lblNguoiHoi.Text = "";
                    lblNguoiDuocHoi.Text = "Đáp án là" + Environment.NewLine + dapAnDung[viTriCauHoi];
                    break;
                case 6:
                    lblNguoiHoi.Text = "Bạn chắc chắn chứ?";
                    break;
                case 4:
                    lblNguoiHoi.Text = "";
                    lblNguoiDuocHoi.Text = "Hãy tin mình!";
                    break;
                case 2:
                    lblNguoiHoi.Text = "Cảm ơn bạn nhiều nhé!";
                    break;
                case 0:
                    soundTrangChu.Stop();
                    soundCauHoi.Play();
                    grbGiaoDienChoi.Visible = true;
                    tmRangBuoc.Start();
                    grbGiaoDienGoiDT.Visible = false;
                    tmGoiDT.Stop();
                    break;
            }
            goidt--;
        }

        private void tmToTuVan_Tick(object sender, EventArgs e)
        {
            if (totuvan == 9)
            {
                if (dapAnA[viTriCauHoi] == dapAnDung[viTriCauHoi])
                {
                    lblDAN1.Text = "A";
                    lblDAN2.Text = "C";
                    lblDAN3.Text = "A";
                }
                if (dapAnB[viTriCauHoi] == dapAnDung[viTriCauHoi])
                {
                    lblDAN1.Text = "B";
                    lblDAN2.Text = "B";
                    lblDAN3.Text = "A";
                }
                if (dapAnC[viTriCauHoi] == dapAnDung[viTriCauHoi])
                {
                    lblDAN1.Text = "C";
                    lblDAN2.Text = "C";
                    lblDAN3.Text = "C";
                }
                if (dapAnD[viTriCauHoi] == dapAnDung[viTriCauHoi])
                {
                    lblDAN1.Text = "C";
                    lblDAN2.Text = "D";
                    lblDAN3.Text = "D";
                }
            }
            if (totuvan == 0)
            {
                soundToTuVan.Stop();
                soundCauHoi.Play();
                grbGiaoDienChoi.Visible = true;
                tmRangBuoc.Start();
                grbGiaoDienToTuVan.Visible = false;
                tmToTuVan.Stop();
            }
            totuvan--;
        }

        private void tmKhanGia_Tick(object sender, EventArgs e)
        {
            if (khangia == 9)
            {
                if (dapAnA[viTriCauHoi] == dapAnDung[viTriCauHoi])
                {
                    lblPhanTramA.Text = "70%";
                    lblPhanTramB.Text = "13%";
                    lblPhanTramC.Text = "7%";
                    lblPhanTramD.Text = "10%";
                }
                if (dapAnB[viTriCauHoi] == dapAnDung[viTriCauHoi])
                {
                    lblPhanTramA.Text = "10%";
                    lblPhanTramB.Text = "60%";
                    lblPhanTramC.Text = "7%";
                    lblPhanTramD.Text = "23%";
                }
                if (dapAnC[viTriCauHoi] == dapAnDung[viTriCauHoi])
                {
                    lblPhanTramA.Text = "20%";
                    lblPhanTramB.Text = "13%";
                    lblPhanTramC.Text = "45%";
                    lblPhanTramD.Text = "22%";
                }
                if (dapAnD[viTriCauHoi] == dapAnDung[viTriCauHoi])
                {
                    lblPhanTramA.Text = "5%";
                    lblPhanTramB.Text = "15%";
                    lblPhanTramC.Text = "25%";
                    lblPhanTramD.Text = "55%";
                }
            }
            if (khangia == 0)
            {
                soundKhanGia.Stop();
                soundCauHoi.Play();
                grbGiaoDienChoi.Visible = true;
                tmRangBuoc.Start();
                grbGiaoDienKhanGia.Visible = false;
                tmKhanGia.Stop();
            }
            khangia--;
        }

        private void tm5050_Tick(object sender, EventArgs e)
        {
            if (time5050 == 1)
            {
                soundCauHoi.Play();
                tm5050.Stop();
            }
            time5050--;
        }

        private void tmChonDapAn_Tick_1(object sender, EventArgs e)
        {
            if (chondapan == 5)
            {
                kiemTraCauHoi(luuDapAn);
                tmChonDapAn.Stop();
            }
            chondapan++;
        }

        private void tmChuThich_Tick(object sender, EventArgs e)
        {
            if (chuthich == 10)
            {
                soundCauHoi.Play();
                btnThongTinChuThich.Text = chuThich[viTriCauHoi];
                grbGiaoDienChuThich.Visible = true;
                grbGiaoDienChoi.Visible = false;
            }
            if (chuthich == 0)
            {
                soundCauHoi.Stop();
                grbGiaoDienChoi.Visible = true;
                grbGiaoDienChuThich.Visible = false;
                nextCauHoi();
                tmChuThich.Stop();
            }
            chuthich--;
        }

        private void btnQuayVeGoiDT_Click(object sender, EventArgs e)
        {
            soundTrangChu.Stop();
            soundCauHoi.Play();
            grbGiaoDienChoi.Visible = true;
            tmRangBuoc.Start();
            grbGiaoDienGoiDT.Visible = false;
            tmGoiDT.Stop();
        }

        private void btnQuayVeToTuVan_Click(object sender, EventArgs e)
        {
            soundToTuVan.Stop();
            soundCauHoi.Play();
            grbGiaoDienChoi.Visible = true;
            tmRangBuoc.Start();
            grbGiaoDienToTuVan.Visible = false;
            tmToTuVan.Stop();
        }
        
        private void btnQuayVeKhanGia_Click(object sender, EventArgs e)
        {
            soundKhanGia.Stop();
            soundCauHoi.Play();
            grbGiaoDienChoi.Visible = true;
            tmRangBuoc.Start();
            grbGiaoDienKhanGia.Visible = false;
            tmKhanGia.Stop();
        }

        private void btnQuayVeXepHang_Click(object sender, EventArgs e)
        {
            grbTrangChu.Visible = true;
            grbXepHang.Visible = false;
            soundCauHoi.Stop();
            soundTrangChu.Play();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tendangnhap = txtTenDangNhap.Text;
            string matkhau = txtMatKhau.Text;

            try
            {
                if (tendangnhap.Length == 0)
                    throw new Exception("Không được để trống tên đăng nhập!");
                if (matkhau.Length == 0)
                    throw new Exception("Không được để trống mật khẩu!");
                if (bll.kiemTraDangNhap(tendangnhap, matkhau) == true)
                {
                    luuTenDangNhap = tendangnhap;
                    luuMaxCauHoi = bll.getMaxCauHoi(luuTenDangNhap);
                    luuSumTienThuong = bll.getSumTienThuong(luuTenDangNhap);
                    soundDangNhap.Stop();
                    soundTrangChu.Play();
                    grbTrangChu.Visible = true;
                    grbDangNhap.Visible = false;
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK);
                    txtMatKhau.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            soundDangNhap.Stop();
            soundTrangChu.Play();
            grbDangKy.Visible = true;
            grbDangNhap.Visible = false;
        }

        private void btnXacNhanDangKy_Click(object sender, EventArgs e)
        {
            string hovaten = txtDKHoVaTen.Text;
            string tendangnhap = txtDKTenDangNhap.Text;
            string matkhau = txtDKMatKhau.Text;

            try
            {
                if (hovaten.Length == 0)
                    throw new Exception("Không được để trống họ và tên!");
                if (tendangnhap.Length == 0)
                    throw new Exception("Không được để trống tên đăng nhập!");
                if (matkhau.Length == 0)
                    throw new Exception("Không được để trống mật khẩu!");
                if (bll.kiemTraDangKy(tendangnhap) == true)
                {
                    throw new Exception("Tên đăng nhập đã tồn tại!");
                }
                else
                {
                    bll.insertTaiKhoan(tendangnhap, matkhau, hovaten);
                    MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo", MessageBoxButtons.OK);
                    soundTrangChu.Stop();
                    soundDangNhap.Play();
                    grbDangNhap.Visible = true;
                    grbDangKy.Visible = false;
                    txtDKHoVaTen.Text = "";
                    txtDKTenDangNhap.Text = "";
                    txtDKMatKhau.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnQuayVeDangKy_Click(object sender, EventArgs e)
        {
            soundTrangChu.Stop();
            soundDangNhap.Play();
            grbDangNhap.Visible = true;
            grbDangKy.Visible = false;
        }

        private void btnDongChuThich_Click(object sender, EventArgs e)
        {
            soundCauHoi.Stop();
            grbGiaoDienChoi.Visible = true;
            grbGiaoDienChuThich.Visible = false;
            nextCauHoi();
            tmChuThich.Stop();
        }

    }
}