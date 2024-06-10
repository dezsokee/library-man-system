using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi;

public class OutLibraryDTO {

    public string? Name { get; set; }
    
    public string? Address { get; set; }
    
    public int ConstructionYear { get; set; }

    public List<Book>? Books { get; set; }

    public int NumberOfBooks { get; set; }
}