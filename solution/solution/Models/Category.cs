using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace solution.Models;

[Table("Categories")]
public class Category
{
    [Column("PK_category")]
    [Key]
    public int CategoryId { get; set; }
    
    [Column("name")]
    [MaxLength(100)]
    public string CategoryName { get; set; }
    
    public IEnumerable<Product> Products { get; set; }
}