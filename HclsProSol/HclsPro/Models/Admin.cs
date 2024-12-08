using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HclsPro.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminId {  get; set; }
        public string AdminName { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Id_Proof { get; set; }
        public bool ActiveStatus { get; set; }
        [ForeignKey("AdminTypes")]
        public int AdminTypeId { get; set; }
        public AdminTypes AdminTypes { get; set; }
    }
}
