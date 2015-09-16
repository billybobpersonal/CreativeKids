using System;
using System.ComponentModel.DataAnnotations;

namespace DogWalking.Models
{
    public class MedicalInformationModel
    {
        [Key]
        public Guid MedicalInformationId { get; set; }
        public string Alergies { get; set; }
        public string MedicalAidName { get; set; }
        public int MedicalAidNumber { get; set; }
        public string PrincipalMember { get; set; }
        public string HouseDoctorName { get; set; }
        public int HouseDoctorNumber { get; set; }
    }
}