using System.ComponentModel.DataAnnotations;

namespace ExclusiveVillaApi.Models.DTO
{
    public class VilleNumberDTO
    {
        [Required]
        public int VilleNo { get; set; }
        [Required]
        public int VilleID { get; set; }
        public string SpecialDetails { get; set; }
        public VilleDTO Ville { get; set; }
    }
}
