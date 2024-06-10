using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi;

public class LibraryDAL {

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Address { get; set; }
    
    public int ConstructionYear { get; set; }

    public ICollection<BookDAL>? Books { get; set; }

    [DefaultValue(false)]
    public bool Flag { get; set; }
}