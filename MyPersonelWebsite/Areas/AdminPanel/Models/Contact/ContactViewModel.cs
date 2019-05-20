using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonelWebsite.Areas.AdminPanel.Models.Contact
{
    public class ContactViewModel
    {
        public IEnumerable<ContactList> contacts { get; set; }
    }
}
