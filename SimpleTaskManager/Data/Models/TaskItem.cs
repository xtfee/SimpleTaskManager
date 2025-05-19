using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleTaskManager.Data.Models
{
    public class TaskItem
    {
        public int TaskItemId { get; set; }

        [Required(ErrorMessage = "Tytuł zadania jest wymagany.")]
        [StringLength(200, ErrorMessage = "Tytuł nie może być dłuższy niż 200 znaków.")]
        public string Title { get; set; }

        [StringLength(1000, ErrorMessage = "Opis nie może być dłuższy niż 1000 znaków.")]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;

        public int? PriorityId { get; set; }
        [ForeignKey("PriorityId")]
        public virtual Priority Priority { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}