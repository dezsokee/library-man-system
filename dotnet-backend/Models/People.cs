using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi;

public class People {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public int Age { get; set; }
    
    public string? Address { get; set; }
    
    public string? Email { get; set; }
}