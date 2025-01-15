using System.ComponentModel.DataAnnotations;

namespace TPTodoList.Models
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Ce champ est obligatoire")]
        [Display(Name = "Tâche")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="La tâche doit contenir entre 3 et 50 caractères")]
        public string Task { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Date et heure de réalisation")]
        public DateTime DueDateTime { get; set; }

        public bool IsComplete { get; set; } = false;
    }
}