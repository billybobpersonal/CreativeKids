using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogWalking.Models
{
    public class ParentModel
    {
        [Key]
        public Guid ParentId { get; set; }
        public Guid ParentUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string HomeContactNumber { get; set; }
        public string CellphoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public virtual List<ChildModel> Children { get; set; }
    }
}