using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Crypto.Macs;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Text;
using WebTT.Constant;
using WebTT.DTO;
using WebTT.Entities;
using WebTT.Help;
using WebTT.IService;
using WebTT.Service;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace WebTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhatTuController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IPhattu _PhatTu;
        private readonly AppDbcontext appDbcontext;
        public PhatTuController(IConfiguration configuration)
        {
            _configuration = configuration;
            _PhatTu = new PhattuService();
            appDbcontext = new AppDbcontext();
        }

        // Token pw
        private string GenerateToken(string Email, string Password)
        {
            List<Claim> claims = new List<Claim>
                {
                    new Claim (ClaimTypes.Email, Email),
                    new Claim ("password", Password ),
                    new Claim ("TokenId",Guid.NewGuid().ToString() ),
                };
            var sercuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(sercuritykey, SecurityAlgorithms.HmacSha256);

            var tocken = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(tocken);
        }
        //tokenMail
        // Token pw
        private string GenerateToken1(string Email)
        {
            List<Claim> claims = new List<Claim>
                {
                    new Claim (ClaimTypes.Email, Email),
                    new Claim ("TokenId",Guid.NewGuid().ToString() ),
                };
            var sercuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(sercuritykey, SecurityAlgorithms.HmacSha256);

            var tocken = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(tocken);
        }

        // Lay danh sach phattu
        [HttpGet("lay danh sach phat tu")]
        public IActionResult LayDanhSachPhatTu()
        {
            var ret = _PhatTu.LayDanhSachPhatTu();
            if (ret != null)
            {

                return Ok(ret);
            }
            else
            {
                return BadRequest("That bai");
            }
        }
        //get Ds panigation
        [HttpGet("lay danh sach phan trang")]
        public IActionResult LayDanhSachPhatTuPhanTrang([FromQuery] Pagination pagination = null)
        {
            var result = _PhatTu.LayDanhSachPhatTuPhanTrang();
            var phatTu = PageResult<PhatTuDTO>.ToPageResult(pagination, result).AsEnumerable();
            pagination.TotalCount = result.Count();
            var ret = new PageResult<PhatTuDTO>(pagination, phatTu);
            if (ret != null)
            {
                return Ok(ret);
            }
            else
            {
                return BadRequest("That bai");
            }
        }

        // Gui lai Email
        [HttpPost("gui lai Email")]
        public IActionResult GuiEmail([FromQuery] string Email)
        {
            var ret = _PhatTu.GuiEmail(Email);
            if (ret == ErrorMessage.ThanhCong)
            {
                string token = GenerateToken1(Email);
                TokenMail.matoken = token;
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("datcpok987@gmail.com"));
                email.To.Add(MailboxAddress.Parse(Email));
                email.Subject = "Ma Token doi Mk";
                email.Body = new TextPart(TextFormat.Html) { Text = TokenMail.matoken };
                using var smtp = new SmtpClient();

                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("datcpok987@gmail.com", "fcotmfjgceybndaj");
                smtp.Send(email);
                smtp.Disconnect(true);
                return Ok("gui email thanh cong");
            }
            else
            {
                return BadRequest("Dang ky that bai");
            };
        }

        // Dang ki phat tu
        [HttpPost("DangKy")]
        public IActionResult DangKyPhatTu(phattu phatTu)
        {
            var ret = _PhatTu.DangKyPhatTu(phatTu);
            if (ret == ErrorMessage.ThanhCong)
            {
                string token = GenerateToken(phatTu.email, phatTu.password);
                var phattucantim = appDbcontext.phattus.FirstOrDefault(x => x.email.ToLower().Contains(phatTu.email.ToLower()));
                if (phattucantim != null)
                {
                    var token1 = new token();
                    token1.stoken = token;
                    token1.phattuid = phattucantim.phattuid;
                    appDbcontext.token.Add(token1);
                    appDbcontext.SaveChanges();
                }
                return Ok("Dang ky thanh cong");
            }
            else
            {
                return BadRequest("Dang ky that bai");
            };
        }

        // Dang nhap
        [HttpPost("DangNhap")]
        public IActionResult DangNhapPhatTu([FromQuery] string Email, string Password)
        {
            var ret = _PhatTu.DangNhapPhattu(Email, Password);
            if (ret == ErrorMessage.ThanhCong)
            {
                string token = GenerateToken(Email, Password);
                var phattucantim = appDbcontext.phattus.FirstOrDefault(x => x.email.ToLower().Contains(Email.ToLower()));
                var tokencantim = appDbcontext.token.FirstOrDefault(x => x.phattuid == phattucantim.phattuid);
                if (tokencantim != null)
                {
                    tokencantim.stoken = token;
                    appDbcontext.token.Update(tokencantim);
                    appDbcontext.SaveChanges();
                }
                TokenMail.matoken = token;
                return Ok(token);
            }
            else
            {
                return BadRequest("Dang ky that bai");
            };
        }

        //Them thong tin phat tu 
        [HttpPut("Them thong tin phan tu")]
        public IActionResult ThemThongTinPhatTu([FromForm] phattu phatTu, [FromQuery] int kieuthanhvienId, [FromQuery] int chuaId, IFormFile file)
        {
            var ret = _PhatTu.ThemThongTinPhatTu(phatTu, kieuthanhvienId, chuaId, file);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("Theem thong tin thanh cong");
            }
            else
            {
                return BadRequest("Them thong tin that bai");
            };
        }
        // sua thong tin phan tu 
        [HttpPut("sua thong tin phan tu")]
        public IActionResult SuaPhatTu(phattu phatTu)
        {
            var ret = _PhatTu.SuaPhatTu(phatTu);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("Theem thong tin thanh cong");
            }
            else
            {
                return BadRequest("Them thong tin that bai");
            };
        }
        // xac thuc sua mat khau phat tu 
        [HttpPut("sua mat khau phan tu")]
        public IActionResult SuaMatKhau(string Email, string token, string passnew, string passconfig)
        {
            var ret = _PhatTu.SuaMatKhau(Email, token, passnew, passconfig);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("Thay doi mK thanh cong");
            }
            else
            {
                return BadRequest("Thay doi mk that bai");
            };
        }

        // xoa phan tu 
        [HttpDelete("Xoa phat tu/{phatTuid}")]
        public IActionResult XoaPhatTu(int phatTuid)
        {
            var ret = _PhatTu.XoaPhatTu(phatTuid);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("xoa thong tin thanh cong");
            }
            else
            {
                return BadRequest("xoa thong tin that bai");
            };
        }
    }
}
