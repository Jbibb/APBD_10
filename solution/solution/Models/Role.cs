using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace solution.Models;

[Table("Roles")]
public class Role
{
    [Column("PK_role")]
    [Key]
    public int RoleId { get; set; }
    
    [Column("name")]
    [MaxLength(100)]
    public string RoleName { get; set; }
    
    public IEnumerable<Product> Products { get; set; }
}