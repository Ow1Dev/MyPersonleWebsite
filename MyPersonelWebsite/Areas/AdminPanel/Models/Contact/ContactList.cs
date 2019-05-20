using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonelWebsite.Areas.AdminPanel.Models.Contact
{
    public class ContactList
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public bool HasRead { get; set; }
        public DateTime Send_at { get; set; }
    }
}
