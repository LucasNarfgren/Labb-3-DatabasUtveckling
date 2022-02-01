using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb_3_DatabasUtveckling.Models
{
    public partial class Grade
    {
        public Grade()
        {
            StudentClasses = new HashSet<StudentClass>();
        }

        public int Id { get; set; }
        public string _Grade { get; set; }

        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
