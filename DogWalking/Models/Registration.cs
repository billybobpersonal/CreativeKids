using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogWalking.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        public virtual ParentModel Parent { get; set; }

        public virtual ChildModel Child { get; set; }
    }
}