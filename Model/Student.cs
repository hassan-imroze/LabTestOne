using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Student : Entity
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Roll { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Address { get; set; }

        public virtual ICollection<PaidServiceFee> PaidFees { get; set; }

    }
}