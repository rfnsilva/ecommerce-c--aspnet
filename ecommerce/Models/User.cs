using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ecommerce.Models
{
    public class User
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "nome:")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha:")]
        public string senha { get; set; }

        public string senha_salt { get; set; }

        public string Audience = "ExemploAudience";
        public string Issuer = "ExemploIssuer";
        public int Seconds = 60;

        public SecurityKey Key { get; set;  }
        public SigningCredentials SigningCredentials { get; }

        public SigningCredentials signConfig()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }
            return new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature
            );
        }
    }
}