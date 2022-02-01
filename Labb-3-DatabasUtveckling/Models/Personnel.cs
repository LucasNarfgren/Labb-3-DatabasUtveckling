using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb_3_DatabasUtveckling.Models
{
    public partial class Personnel
    {
        public Personnel()
        {
            StudentClasses = new HashSet<StudentClass>();
        }

        public int Id { get; set; }
        public string PFirstName { get; set; }
        public string PLastName { get; set; }
        public int? FkroleId { get; set; }

        public virtual PersonnelRank Fkrole { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
