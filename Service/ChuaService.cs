using System.Security.Cryptography.Xml;
using WebTT.Constant;
using WebTT.Converters;
using WebTT.DTO;
using WebTT.Entities;
using WebTT.Help;
using WebTT.IService;

namespace WebTT.Service
{
    public class ChuaService : IChua
    {
        private readonly AppDbcontext appDbContext;
        private readonly ChuaConverter chuaConverter;
        public ChuaService()
        {  
            
            chuaConverter = new ChuaConverter();
            appDbContext = new AppDbcontext();
         
        }
        public IEnumerable<ChuaDTO> LayDanhSachChuaPhanTrang(Pagination pagination = null)
        {
            var res = appDbContext.chuas.Select(x => chuaConverter.ChuaToDTO(x)). AsQueryable();
            return res;

        }

        public IEnumerable<chuas> LayDanhSachChua()
        {
            var res = appDbContext.chuas.AsQueryable();
            return res;
        }

        public ErrorMessage SuaChua(chuas Chua)
        {
            var chuacantim = appDbContext.chuas.FirstOrDefault(x=>x.chuaid == Chua.chuaid);
            if(chuacantim!=null)
            {
                chuacantim.chuaid = Chua.chuaid;
                chuacantim.capnhat= Chua.capnhat;
                chuacantim.diachi= Chua.diachi;
                chuacantim.ngaythanhlap= Chua.ngaythanhlap;
                chuacantim.tenchua= Chua.tenchua;
                chuacantim.trutri= Chua.trutri;
                appDbContext.chuas.Update(chuacantim);
                appDbContext.SaveChanges();
                return ErrorMessage.ThanhCong;
            }else
            {
                return ErrorMessage.khongcochua;
            }
        }

        public ErrorMessage ThemChua(chuas Chua)
        {

                Chua.capnhat = DateTime.Now;
                appDbContext.chuas.Add(Chua);
                appDbContext.SaveChanges() ;
                return ErrorMessage.ThanhCong;
        }

        public ErrorMessage XoaChua(int ChuaId)
        {
            var chuacantim = appDbContext.chuas.FirstOrDefault(x=>x.chuaid == ChuaId); 
            if(chuacantim == null)
            {
                return ErrorMessage.khongcochua;
            }else
            {
                appDbContext.chuas.Remove(chuacantim);
                appDbContext.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
        }
    }
}


