using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models;

public class ToDo
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Title { get; set; }
    [Required]
    [MaxLength(300)]
    public string? Description { get; set; }
    [Required]
    public DateTime DateTime { get; set; } = DateTime.Now;
}