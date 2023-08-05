using Microsoft.EntityFrameworkCore;
using System;
using System.Net.WebSockets;
using WebTT.Constant;
using WebTT.Converters;
using WebTT.DTO;
using WebTT.Entities;
using WebTT.IService;

namespace WebTT.Service
{
    public class DonDangKyService : IDonDangKy
    {  
        private readonly AppDbcontext appDbContext;

        public DonDangKyService()
        {
            appDbContext = new AppDbcontext();
          
        }
        public void CapNhatSTV(int? DaoTrangID)
        {
            var daotrangcantim= appDbContext.daotrangs.FirstOrDefault(x=>x.daotrangid==DaoTrangID);
            if (daotrangcantim != null)
            {
                daotrangcantim.sothanhvienthamgia = appDbContext.dondangkys.Count(x => x.daotrangid == DaoTrangID);
                appDbContext.daotrangs.Update(daotrangcantim);
                appDbContext.SaveChanges();
            }
        }

        public IEnumerable<dondangkys> LayDSDonDK()
        {
           var res = appDbContext.dondangkys.AsQueryable();
           return res;
        }
        public ErrorMessage SuaDonDk(dondangkys DonDK)
        {
             var dondangkycantim = appDbContext.dondangkys.FirstOrDefault(x=>x.dondangkyid==DonDK.dondangkyid);
            if(dondangkycantim!=null)
            {
                dondangkycantim.dondangkyid= DonDK.dondangkyid;
                dondangkycantim.ngayguidon = DonDK.ngayguidon;
                dondangkycantim.ngayxuly = DonDK.ngayxuly;
                dondangkycantim.nguoixuly = DonDK.nguoixuly;
                dondangkycantim.trangthaidon = DonDK.trangthaidon;
                dondangkycantim.daotrangid= DonDK.daotrangid;
                dondangkycantim.phattuid = DonDK.phattuid;
               
                appDbContext.dondangkys.Update(dondangkycantim);
                appDbContext.SaveChanges();
                if (DonDK.trangthaidon == 1)
                {
                    CapNhatSTV(DonDK.daotrangid);
                }
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.ThatBai;
            }
        }
        public ErrorMessage ThemDonDK(dondangkys DonDK, int DaoTrangid)
        {   
            var tokencantim = appDbContext.token.FirstOrDefault(x=>x.stoken.ToLower().Contains(TokenMail.matoken));
            var daotrangcantim = appDbContext.daotrangs.FirstOrDefault(x=>x.daotrangid == DaoTrangid);
            var phattucantim = appDbContext.phattus.FirstOrDefault(x=>x.phattuid== tokencantim.phattuid);
            var phattutrongdon = appDbContext.dondangkys.FirstOrDefault(x => x.phattuid == tokencantim.phattuid);
            if (daotrangcantim != null && phattucantim !=null&& phattutrongdon==null)
            {  
                    DonDK.daotrangid = DaoTrangid;
                    DonDK.phattuid = tokencantim.phattuid;
                    appDbContext.dondangkys.Add(DonDK);
                    appDbContext.SaveChanges();
                if(DonDK.trangthaidon==1)
                {
                    CapNhatSTV(DaoTrangid);
                }
                    return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.ThatBai;
            }
        }

        public ErrorMessage XNDonDk(int DonDKId, int XNId)
        {
            var dondkcantim = appDbContext.dondangkys.FirstOrDefault(x=>x.dondangkyid== DonDKId);
            var tokencantim = appDbContext.token.FirstOrDefault(x => x.stoken.ToLower().Contains(TokenMail.matoken));
            var phattucantim = appDbContext.phattus.FirstOrDefault(x => x.phattuid == tokencantim.phattuid);
            if(dondkcantim != null && phattucantim.AdminId == 1)
            {
                dondkcantim.trangthaidon = XNId;
                dondkcantim.nguoixuly = phattucantim.phattuid;
                appDbContext.dondangkys.Update(dondkcantim);
                appDbContext.SaveChanges();
                if (dondkcantim.trangthaidon == 1)
                {
                    CapNhatSTV(dondkcantim.daotrangid);
                }
                return ErrorMessage.ThanhCong;
            }else
            {
                return ErrorMessage.khongadmin; 
            }

        }

        public ErrorMessage XoaDonDk(int DonDKId)
        {
            var dondangkycantim = appDbContext.dondangkys.FirstOrDefault(x=>x.dondangkyid== DonDKId);
            if(dondangkycantim != null)
            {
                appDbContext.dondangkys.Remove(dondangkycantim);
                appDbContext.SaveChanges();
                CapNhatSTV(dondangkycantim.daotrangid);
                return ErrorMessage.ThanhCong;
            }else
            {
                return ErrorMessage.ThatBai;
            }
        }
    }
}
