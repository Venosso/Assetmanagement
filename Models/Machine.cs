using System.ComponentModel.DataAnnotations;

namespace Assetmanagement.Models
{
    public class Machine
    { public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
        public string Status { get; set; }  




    }
}
