using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.ViewModels
{
    public class PasswordViewModel
    {
        public int ID { get; set; }

        public string Password { get; set; }

        public string Site { get; set; }

        public string MasterPassword { get; set; }
    }
}
