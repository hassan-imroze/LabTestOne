using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class PaidServiceFee : Entity
    {
        [Required]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [Required]
        public string ServiceFeeId { get; set; }

        [ForeignKey("ServiceFeeId")]
        public virtual ServiceFee ServiceFee { get; set; }

        //[DataType(DataType.Currency)]
        //public double TotalFeeAmount { get; set; }

        [DataType(DataType.Currency)]
        public double PaidAmount { get; set; }


    }
}