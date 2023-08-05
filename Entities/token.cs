using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using WebTT.Enum;

namespace WebTT.Entities
{
    public class token
    {
        [Key]
        public int id { get; set; }
        public string? stoken { get; set; }
        public bool? expired { get; set; }
        public bool? revoked { get; set; }
        public TokenEnum? token_type { get; set; }
        public int? phattuid { get; set; }
        public phattu? phattu { get; set; }

    }
}
