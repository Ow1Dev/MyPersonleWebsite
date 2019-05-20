using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonelWebsite.Models.Contakt
{
    public class SendViewModel
    {
        public Input input { get; set; }

        public class Input
        {
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            [MaxLength(10000)]
            [Required]
            public string Content { get; set; }
        }
    }
}
