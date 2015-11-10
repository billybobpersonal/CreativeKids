using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogWalking.Models
{
    public class ClassTermModel
    {
        [Key]
        public Guid ClassTermId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual List<BakingClassModel> Classes { get; set; }
    }
}