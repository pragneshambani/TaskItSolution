using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskItService.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
