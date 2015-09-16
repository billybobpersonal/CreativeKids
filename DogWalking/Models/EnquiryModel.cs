using System;
using System.ComponentModel.DataAnnotations;

namespace DogWalking.Models
{
    public class EnquiryModel
    {
        [Key]
        public Guid EnquiryId { get; set; }
        public DateTime EnquiryDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ChildAge { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
    }

}