using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string Full_Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public long Mobile  { get; set; }

        public int Employee_Id { get; set; }


        public DateTime Date_of_Birth { get; set; }

        public string Address { get; set; } = string.Empty;

        

    }
}
