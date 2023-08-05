using WebTT.Constant;
using WebTT.DTO;
using WebTT.Entities;

namespace WebTT.IService
{
    public interface IDonDangKy
    {
        IEnumerable<dondangkys> LayDSDonDK();
        ErrorMessage ThemDonDK(dondangkys DonDK, int DaoTrangid);
        ErrorMessage SuaDonDk (dondangkys DonDK);  
        ErrorMessage XoaDonDk (int DonDKId);
        ErrorMessage XNDonDk(int DonDKId, int XNId);
    }
}
