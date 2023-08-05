using MimeKit;
using System;
using System.Net.WebSockets;
using WebTT.Constant;
using WebTT.Converters;
using WebTT.DTO;
using WebTT.Entities;
using WebTT.Help;
using WebTT.IService;

namespace WebTT.Service
{
    public class PhattuService : IPhattu
    {
        private readonly AppDbcontext appDbContext;
        private readonly PhatTuConverter phatTuConverter;
        public PhattuService()
        {
            appDbContext = new AppDbcontext();
            phatTuConverter = new PhatTuConverter();
        }

        public string ConvertIFormFileToString(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                return reader.ReadToEnd();
            }
        }
        //Dang ky phat tu
        public ErrorMessage DangKyPhatTu(phattu phatTu)
        {
            var emailcantim = appDbContext.phattus.FirstOrDefault(x => x.email.ToLower().Equals(phatTu.email.ToLower()));
            var passwordcantim = appDbContext.phattus.FirstOrDefault(x => x.password.ToLower().Equals(phatTu.password.ToLower()));
            if (emailcantim == null && passwordcantim == null)
            {
                phatTu.email = phatTu.email;
                phatTu.password = phatTu.password;
                phatTu.trangthai = true;
                appDbContext.phattus.Add(phatTu);
                appDbContext.SaveChanges();
                
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.Datontai;
            }
        }


        // dang nhap phattu
        public ErrorMessage DangNhapPhattu(string Email, string Password)
        {
            var emailcantim = appDbContext.phattus.FirstOrDefault(x => x.email.ToLower().Equals(Email.ToLower()));
            var passwordcantim = appDbContext.phattus.FirstOrDefault(x => x.password.ToLower().Equals(Password.ToLower()));
            if (emailcantim != null && passwordcantim != null)
            {

                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.ThatBai;
            }
        }
        
        //gui email token
        public ErrorMessage GuiEmail(string Email)
        {
            var emailcantim = appDbContext.phattus.FirstOrDefault(x => x.email.ToLower().Contains(Email.ToLower()));
            if (emailcantim != null)
            {
                
                return ErrorMessage.ThanhCong;
            }else { 
                return ErrorMessage.ThatBai; 
            }
        }


        // lay danh sach co xac thuc
        public IEnumerable<PhatTuDTO> LayDanhSachPhatTu()
        {    
            var res = appDbContext.phattus.Where(x=>x.trangthai==true).OrderByDescending(x => x.ngaycapnhap).Select(x => phatTuConverter.EntityToDTO(x)).AsQueryable();
            return res;
        }
        // lay danh sach phan trang
        public IEnumerable<PhatTuDTO> LayDanhSachPhatTuPhanTrang(Pagination pagination = null)
        {
            var res = appDbContext.phattus.Where(x => x.trangthai == true).OrderByDescending(x => x.ngaycapnhap).Select(x => phatTuConverter.EntityToDTO(x)).AsQueryable();
            return res;
        }

        public ErrorMessage SuaMatKhau(string Email, string token, string passnew, string passconfig)
        {
            var phattucantim = appDbContext.phattus.FirstOrDefault(x=>x.email.ToLower().Contains(Email.ToLower()));
            if( phattucantim != null &&  TokenMail.matoken == token )
            {
                if (passnew == passconfig)
                {
                    phattucantim.password = passconfig;
                    appDbContext.phattus.Update(phattucantim);
                    appDbContext.SaveChanges();
                   return ErrorMessage.ThanhCong;
                }
                else
                {
                   return ErrorMessage.ThatBai;
                }
            }else
            {
                return ErrorMessage.Khongcophattu;
            }
        }

        // sua phat tu 
        public ErrorMessage SuaPhatTu(phattu phatTu)
        {
          
                var phattucantim = appDbContext.phattus.FirstOrDefault(x => x.phattuid==phatTu.phattuid);
                if (phattucantim != null)
                {  
                    phattucantim.anhchup = phatTu.anhchup;
                    phattucantim.dahoantuc = phatTu.dahoantuc;
                    phattucantim.email = phatTu.email;
                    phattucantim.gioitinh = phatTu.gioitinh;
                    phattucantim.ho = phatTu.ho;
                    phattucantim.ngaycapnhap = phatTu.ngaycapnhap;
                    phattucantim.ngayhoantuc = phatTu.ngayhoantuc;
                    phattucantim.ngaysinh = phatTu.ngaysinh;
                    phattucantim.ngayxuatgia = phatTu.ngayxuatgia;
                    phattucantim.password = phatTu.password;
                    phattucantim.phapdanh = phatTu.phapdanh;
                    phattucantim.sodienthoai = phatTu.sodienthoai;
                    phattucantim.ten = phatTu.ten;
                    phattucantim.tendem = phatTu.tendem;
                    phattucantim.kieuthanhvienid = phatTu.kieuthanhvienid;
                    appDbContext.phattus.Update(phattucantim);
                    appDbContext.SaveChanges();
                    return ErrorMessage.ThanhCong;
                }
                else
                {
                    return ErrorMessage.Khongcophattu;
                }
        }


        // them thong tin phat tu 
        public ErrorMessage ThemThongTinPhatTu(phattu phatTu, int chuaId, int kieuthanhvienId , IFormFile file)
        {
            var kieuthanhviencantim = appDbContext.kieuthanhviens.FirstOrDefault(x => x.kieuthanhvienid == kieuthanhvienId);
            var chuacantim = appDbContext.chuas.FirstOrDefault(x => x.chuaid == chuaId);
            if (kieuthanhviencantim != null && chuacantim != null)
            {
                var phattucantim = appDbContext.phattus.FirstOrDefault(x => x.phattuid == phatTu.phattuid);
                if (phattucantim != null)
                {
                    phattucantim.kieuthanhvienid = kieuthanhvienId;
                    phattucantim.anhchup = ConvertIFormFileToString(file);
                    phattucantim.dahoantuc = phatTu.dahoantuc;
                    phattucantim.gioitinh = phatTu.gioitinh;
                    phattucantim.ho = phatTu.ho;
                    phattucantim.ngaycapnhap = phatTu.ngaycapnhap;
                    phattucantim.ngayhoantuc = phatTu.ngayhoantuc;
                    phattucantim.ngaysinh = phatTu.ngaysinh;
                    phattucantim.ngayxuatgia = phatTu.ngayxuatgia;
                    phattucantim.phapdanh = phatTu.phapdanh;
                    phattucantim.sodienthoai = phatTu.sodienthoai;
                    phattucantim.ten = phatTu.ten;
                    phattucantim.tendem = phatTu.tendem;
                    appDbContext.phattus.Update(phattucantim);
                    appDbContext.SaveChanges();
                    return ErrorMessage.ThanhCong;
                }
                else
                {
                    return ErrorMessage.Khongcophattu;
                }
            }
            else
            {
                return ErrorMessage.KhongKTVvachua;
            }
        }


        // xoa phat tu 
        public ErrorMessage XoaPhatTu(int phatTuid)
        {   
            var phattucantim = appDbContext.phattus.FirstOrDefault(x => x.phattuid == phatTuid);
            var tokencantim = appDbContext.token.FirstOrDefault(x => x.phattuid == phatTuid);
                if (phattucantim != null )
                {
                    phattucantim.trangthai = false; 
                    appDbContext.phattus.Remove(phattucantim);
                    appDbContext.token.Remove(tokencantim);
                    appDbContext.SaveChanges();
                    
                return ErrorMessage.ThanhCong;
                }
                else
                {
                return ErrorMessage.ThatBai;
                }
            
        }

    }
}
