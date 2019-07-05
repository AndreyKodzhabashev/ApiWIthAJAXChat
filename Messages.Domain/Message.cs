using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Messages.Domain
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
        [Required]
        public string User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
