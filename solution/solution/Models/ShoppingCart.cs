using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace solution.Models;

[Table("Shopping_Carts")]
public class ShoppingCart
{
    [Column("FK_Account")]
    [ForeignKey("Account")]
    public int AccountId { get; set; }
    public Account Account { get; set; }

    [Column("FK_Product")]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    [Column("amount")]
    public int ShoppingCartAmount { get; set; }
}