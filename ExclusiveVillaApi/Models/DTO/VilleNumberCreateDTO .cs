using System.ComponentModel.DataAnnotations;

namespace ExclusiveVillaApi.Models.DTO
{
    public class VilleNumberCreateDTO
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaID { get; set; }
        public string SpecialDetails { get; set; }
    }
}
