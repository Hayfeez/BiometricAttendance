using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.BaseClass;

namespace AttendanceLibrary.Model
{
    public class AppSetting
    {
        [Key]
        public string Id { get; set; }
        public string ApplicationName { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string LogoBase64 { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }



        public string DatabaseName { get; set; }
        public string DatabaseServer { get; set; }
        public string DbUsername { get; set; }
        public string DbPassword { get; set; }
        //{
        //    get => StringCipher.Decrypt(_dbPassword);
        //    set => _dbPassword = StringCipher.Encrypt(value);
        //}

        //private string _dbPassword;

    }
}
