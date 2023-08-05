using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTT.Constant;
using WebTT.Entities;
using WebTT.IService;
using WebTT.Service;

namespace WebTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonDkController : ControllerBase
    {
        private readonly IDonDangKy _DonDK;
        public DonDkController()
        {
            _DonDK = new DonDangKyService();
        }

        // Lay danh sach don dk
        [HttpGet("lay danh sach don dk")]
        public IActionResult LayDSDonDK()
        {
            var ret = _DonDK.LayDSDonDK();
            if (ret != null)
            {

                return Ok(ret);
            }
            else
            {
                return BadRequest("That bai");
            }
        }
        // Them don dang ky
        [HttpPost("Them don dang ky")]
        public IActionResult ThemDonDK(dondangkys DonDK, int DaoTrangid)
        {
            var ret = _DonDK.ThemDonDK(DonDK,DaoTrangid);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("Them đon dk thanh cong");
            }
            else
            {
                return BadRequest("Them don dk that bai");
            };
        }
        // Sua don dang ky
        [HttpPut("Sua don dang ky")]
        public IActionResult SuaDonDk(dondangkys DonDK)
        {
            var ret = _DonDK.SuaDonDk(DonDK);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("sua don dk thanh cong");
            }
            else
            {
                return BadRequest("sua don dk that bai");
            };
        }
        // Xac nhan don dang ky
        [HttpPut("Xac nhan don dang ky")]
        public IActionResult XNDonDk(int DonDKId, int XNId)
        {
            var ret = _DonDK.XNDonDk(DonDKId,XNId);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("Xac nhan don dk thanh cong");
            }
            else
            {
                return BadRequest("Xac nhan don dk that bai");
            };
        }
        [HttpDelete("Xoa don dang ky")]
        public IActionResult XoaDonDk(int DonDKId)
        {
            var ret = _DonDK.XoaDonDk(DonDKId);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("xoa don dk thanh cong");
            }
            else
            {
                return BadRequest("xoa don dk that bai");
            };
        }
    }
}
