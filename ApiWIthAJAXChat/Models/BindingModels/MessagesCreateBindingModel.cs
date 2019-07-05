using System.ComponentModel.DataAnnotations;

namespace ApiWIthAJAXChat.Models.BindingModels
{
    public class MessagesCreateBindingModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }
    }
}
