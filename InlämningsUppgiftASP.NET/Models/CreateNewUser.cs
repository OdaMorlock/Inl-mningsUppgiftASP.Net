using InlämningsUppgiftASP.NET.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlämningsUppgiftASP.NET.Models
{
    public class CreateNewUser
    {
        public ApplicationUser User { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
