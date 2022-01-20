using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaAgendaMinhaVidaAPI.Models
{
    public enum Role
    {
        Admin, Common
    }

    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public Role? Role { get; set; }

        [ForeignKey("UserId")]
        public ICollection<Agenda> Agendas { get; set; }
    }
}
