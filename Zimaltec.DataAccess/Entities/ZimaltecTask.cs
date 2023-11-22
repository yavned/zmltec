using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zimaltec.Entities.Models
{
    public class ZimaltecTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public int OrderNum { get; set; }
    }
}
