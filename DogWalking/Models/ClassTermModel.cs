using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogWalking.Models
{
    public class ClassTermModel
    {
        [Key]
        public virtual Guid ClassTermId { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual List<BakingClassModel> Classes { get; set; }
    }
}