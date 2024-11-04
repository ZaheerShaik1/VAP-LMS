using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LibrarayManagementSystem.Entities
{
    public class Otp
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OtpValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }

        public Admin Admin { get; set; } 
    }
}
