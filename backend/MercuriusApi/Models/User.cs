using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MercuriusApi.Models
{
    public class User
    {
        [Key]
        public string User_Id { get; set; }

        public string User_FirstName { get; set; }

        public string User_LastName { get; set; }

        public string User_Name { get; set; }

        public string User_Mail { get; set; }

        public string User_Salt { get; set; }

        public string User_Password { get; set; }
    }
}
