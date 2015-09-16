using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogWalking.Models
{
    public class BakingClassModel
    {
        [Key]
        public virtual Guid BakingClassId { get; set; }
        public virtual DateTime ClassTime { get; set; }
        public virtual int MaxNumberOfAttendees { get; set; }
        public virtual List<ChildModel> Attendees { get; set; }
        public virtual int MinAge { get; set; }
        public virtual int MaxAge { get; set; }
    }
}