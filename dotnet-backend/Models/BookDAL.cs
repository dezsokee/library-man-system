using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi;

public class BookDAL {

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateTime PublishYear { get; set; }

    public int Pages { get; set; }

    [ForeignKey("LibraryDAL")]
    public int LibraryId { get; set; }

    public LibraryDAL? Library { get; set; }
}