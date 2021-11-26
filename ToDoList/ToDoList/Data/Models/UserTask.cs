using System.ComponentModel.DataAnnotations;

namespace ToDoList.Data.Models
{
    public class UserTask
    {
        public int Id { get; set; }

        public User User { get; set; }

        [Required]
        public int UserId { get; set; }

        public Task Task { get; set; }

        [Required]
        public int TaskId { get; set; }
    }
}
