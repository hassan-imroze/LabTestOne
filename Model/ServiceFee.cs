using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class ServiceFee : Entity
    {
        [Required]
        public string ServiceName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double ServicePrice { get; set; }

        public virtual ICollection<PaidServiceFee> PaidFeesByService { get; set; }

    }
}