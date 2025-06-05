using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleTaskManager.Modele
{
    public class ElementZadania
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Opis { get; set; }

        public bool CzyWykonane { get; set; }
        public DateTime DataUtworzenia { get; set; }
        public DateTime? DataZakonczenia { get; set; }

        public int KategoriaId { get; set; }

        [ForeignKey("KategoriaId")]
        public virtual Kategoria Kategoria { get; set; }
    }
}