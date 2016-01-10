using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DR_Annotate.Models
{
    public class DR_AnnotateUser : IdentityUser
    {
        public DateTime FirstAnnotation { get; set; }
    }
}
