using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExclusiveVillaApi.Models
{
    public class VilleNumber
    {
         [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VilleNo { get; set; }
        public string? SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
