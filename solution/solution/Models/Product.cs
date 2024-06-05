using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace solution.Models;

[Table("Products")]
public class Product
{
    [Column("PK_product")]
    [Key]
    public int ProductId { get; set; }
    
    [MaxLength(100)]
    [Column("name")]
    public string ProductName { get; set; }

    [Column("weight")]
    public double ProductWeight { get; set; }
    
    [Column("width")]
    public double ProductWidth { get; set; }
    
    [Column("height")]
    public double ProductHeight { get; set; }
    
    [Column("depth")]
    public double ProductDepth { get; set; }
    
    public IEnumerable<Category> Categories { get; set; }
    
    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
    
}