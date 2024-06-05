using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace solution.Models;

[Table("Accounts")]
public class Account
{
    [Column("PK_account")]
    [Key]
    public int AccountId { get; set; }
    
    [Column("FK_role")]
    [ForeignKey("Role")]
    public int RoleId { get; set; }
    public Role Role { get; set; }
    
    [Column("first_name")]
    [MaxLength(50)]
    public string AccountFirstName { get; set; }
    
    [Column("last_name")]
    [MaxLength(50)]
    public string AccountLastName { get; set; }
    
    [Column("email")]
    [MaxLength(80)]
    public string AccountEmail { get; set; }
    
    [Column("phone")]
    [MaxLength(9)]
    public string? AccountPhone { get; set; }
    
    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
}