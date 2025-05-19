using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleTaskManager.Data.Models
{
    public class Priority
    {
        public int PriorityId { get; set; }

        [Required(ErrorMessage = "Nazwa priorytetu jest wymagana.")]
        [StringLength(50, ErrorMessage = "Nazwa priorytetu nie może być dłuższa niż 50 znaków.")]
        public string Name { get; set; }

        [StringLength(7, ErrorMessage = "Kod koloru musi być w formacie #RRGGBB.")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "Niepoprawny format kodu koloru (np. #FF0000).")]
        public string ColorCode { get; set; }

        public virtual ICollection<TaskItem> TaskItems { get; set; }

        public Priority()
        {
            TaskItems = new HashSet<TaskItem>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}