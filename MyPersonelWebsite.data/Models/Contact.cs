using System;

namespace MyPersonelWebsite.data.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public DateTime Post_at { get; set; }
    }
}
