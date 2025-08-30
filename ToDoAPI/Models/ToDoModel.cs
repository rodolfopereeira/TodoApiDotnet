using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models;

public class ToDoModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Title { get; set; }
    [Required]
    [MaxLength(300)]
    public string? Description { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
}