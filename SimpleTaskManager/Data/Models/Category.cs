using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleTaskManager.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Nazwa kategorii jest wymagana.")]
        [StringLength(100, ErrorMessage = "Nazwa kategorii nie może być dłuższa niż 100 znaków.")]
        public string Name { get; set; }

        public virtual ICollection<TaskItem> TaskItems { get; set; }

        public Category()
        {
            TaskItems = new HashSet<TaskItem>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}