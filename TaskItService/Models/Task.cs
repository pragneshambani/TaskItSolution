using System.ComponentModel.DataAnnotations;

namespace TaskItService.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
