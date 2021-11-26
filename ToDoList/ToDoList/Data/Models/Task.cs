using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Data.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заглавието е задължително")]
        [MaxLength(200, ErrorMessage = "Заглавието трябва да е максимум 200 символа.")]
        [Display(Name = "Заглавие", AutoGenerateFilter = false)]
        public string Title { get; set; }

        [Display(Name = "Съдържание", AutoGenerateFilter = false)]
        public string Description { get; set; }

        [Display(Name = "Дата и час", AutoGenerateFilter = false)]
        public DateTime? DateAndTime { get; set; }

        public ICollection<UserTask> UserTasks { get; set; }
    }
}
