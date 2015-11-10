using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogWalking.Models
{
    public class ChildModel
    {
        [Key]
        public Guid ChildId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public virtual EmergencyContactModel EmergencyContact { get; set; }
        public virtual MedicalInformationModel MedicalInformation { get; set; }
        public bool ReceivedIndemnityForm { get; set; }
        public virtual List<ParentModel> Parents { get; set; }
    }
}