using WebTT.Constant;
using WebTT.DTO;
using WebTT.Entities;
using WebTT.Help;

namespace WebTT.IService
{
    public interface IPhattu
    {
        ErrorMessage DangKyPhatTu(phattu phatTu);//
        ErrorMessage DangNhapPhattu(string Email, string Password);//
        ErrorMessage ThemThongTinPhatTu(phattu phatTu, int kieuthanhvienId, int chuaId, IFormFile file); // 
        ErrorMessage SuaPhatTu(phattu phatTu); //
        ErrorMessage XoaPhatTu(int phatTuid); // 
        IEnumerable<PhatTuDTO> LayDanhSachPhatTu();
       
        IEnumerable<PhatTuDTO> LayDanhSachPhatTuPhanTrang(Pagination pagination = null);

        ErrorMessage GuiEmail(string Email);

        ErrorMessage SuaMatKhau(string Email ,string token ,string passnew ,string passconfig);
    }
}
