using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HclsPro.Models
{
    [Table("AdminTypes")]
    public class AdminTypes
    {
        [Key] 
        public int AdminTypeId {  get; set; }
        public string AdminTypeName { get; set; }
        public ICollection<Admin> Admin {  get; set; }
    }
}
