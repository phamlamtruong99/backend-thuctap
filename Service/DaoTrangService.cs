using WebTT.Constant;
using WebTT.Converters;
using WebTT.DTO;
using WebTT.Entities;
using WebTT.Help;
using WebTT.IService;

namespace WebTT.Service
{
    public class DaoTrangService : IDaoTrang
    {
        private readonly AppDbcontext appDbContext;
        private readonly DaoTrangConverter daoTrangConverter;
        public DaoTrangService()
        {   
            daoTrangConverter = new DaoTrangConverter();
            appDbContext = new AppDbcontext();
        }
        public IEnumerable<DaoTrangDTO> LayDanhSachDaoTrang(Pagination pagination = null)
        {
            var res = appDbContext.daotrangs.Select(x=>daoTrangConverter.DTtoDTO(x)).AsQueryable();
            return res;
        }
        public ErrorMessage ThemDaoTrang(daotrangs DaoTrang)
        {
                appDbContext.daotrangs.Add(DaoTrang);
                appDbContext.SaveChanges();
                return ErrorMessage.ThanhCong;    
        }

        public ErrorMessage SuaDaoTrang(daotrangs DaoTrang)
        {
            var daotrangcantim = appDbContext.daotrangs.FirstOrDefault(x => x.daotrangid == DaoTrang.daotrangid);
            if(daotrangcantim == null)
            {
                return ErrorMessage.khongcodaotrang;
            } else
            {
                daotrangcantim.daotrangid = DaoTrang.daotrangid;
                daotrangcantim.daketthuc = DaoTrang.daketthuc;
                daotrangcantim.noidung = DaoTrang.noidung;
                daotrangcantim.noitochuc = DaoTrang.noitochuc;
                daotrangcantim.sothanhvienthamgia = DaoTrang.sothanhvienthamgia;
                daotrangcantim.thoigiantochuc = DaoTrang.thoigiantochuc;
                daotrangcantim.nguoitrutri = DaoTrang.nguoitrutri;
                appDbContext.daotrangs.Update(daotrangcantim);
                appDbContext.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
        }

        public ErrorMessage XoaDaoTrang(int DaoTrangId)
        {
           var daotrangcantim = appDbContext.daotrangs.FirstOrDefault(x=>x.daotrangid == DaoTrangId);
            if(daotrangcantim == null )
            {
                return ErrorMessage.khongcodaotrang; 
            }else
            {
                appDbContext.daotrangs.Remove(daotrangcantim);
                return ErrorMessage.ThanhCong;
            }
        }

        public IEnumerable<daotrangs> LayDanhDaoTrang()
        {
            var res = appDbContext.daotrangs.AsQueryable();
            return res;
        }
    }
}
