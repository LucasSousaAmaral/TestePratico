using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaAgendaMinhaVidaAPI.Models
{
    [Table("Agendas")]
    public class Agenda
    {
        [Key]
        public int AgendaId { get; set; }
        [Required]
        [StringLength(30)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        public DateTime Data { get; set; }
    }
}
