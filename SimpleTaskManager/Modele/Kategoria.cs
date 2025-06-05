using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleTaskManager.Modele
{
    public class Kategoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nazwa { get; set; }

        public virtual ICollection<ElementZadania> Zadania { get; set; } = new List<ElementZadania>();

        public override string ToString()
        {
            return Nazwa;
        }
    }
}