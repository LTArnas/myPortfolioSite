using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace myPortfolioSite.Models
{
    public class ContactEmailForm
    {
        [Required, Display(Name = "Your name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Your email")]
        public string FromEmail { get; set; }
        [Required, Display(Name = "Your message")]
        public string Message { get; set; }
    }
}
