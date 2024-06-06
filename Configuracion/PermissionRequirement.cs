using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE_ServicesClassRCL.Models.Permission
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public List<string> Roles { get; set; }
        public List<string> Claims { get; set; }

        public PermissionRequirement(string[] Roles, string[] Claims)
        {
            if (Roles != null)
                this.Roles = Roles.ToList();
            else
                this.Roles = new List<string>();

            if (Claims != null)
                this.Claims = Claims.ToList();
            else
                this.Claims = new List<string>();
        }
    }
}