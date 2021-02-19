using InlämningsUppgiftASP.NET.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InlämningsUppgiftASP.NET.Models
{
    public class SchoolClasses
    {
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Id { get; set; }

        [Required]
        [Column(TypeName ="date")]
        public DateTime Year { get; set; }
        
        public string ClassName { get; set; }

        public string TeacherId { get; set; }
        public string StudentId { get; set; }

        public  ApplicationUser Teacher { get; set; }

        public ApplicationUser Student { get; set; }

        public virtual ICollection<ApplicationUser> Students { get; set; }

    }
}
