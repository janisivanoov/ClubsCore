using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClubsCore.Models
{
    public class Club : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Type { get; set; }

        public ICollection<StudentClub> Students { get; set; }
    }
}