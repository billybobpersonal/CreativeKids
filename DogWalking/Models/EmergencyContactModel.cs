
using System;
using System.ComponentModel.DataAnnotations;

namespace DogWalking.Models
{
    public class EmergencyContactModel
    {
        [Key]
        public Guid EmergencyContactId { get; set; }
        public string FirstName { get; set; }
        public string RelationshipToChild { get; set; }
        public int HomePhoneNumber { get; set; }
        public int CellPhoneNumber { get; set; }
    }
}