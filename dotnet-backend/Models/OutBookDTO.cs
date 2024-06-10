using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi;

public class OutBookDTO {
    public string? Title { get; set; }

    public DateTime PublishYear { get; set; }

    public int Pages { get; set; }
    
    public int NumberOfCharacters { get; set; }

    public int LibraryId { get; set; }
}