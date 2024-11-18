using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.authorizations.Authorizations
{
    public class EasilyAuthorizationRequirement: IAuthorizationRequirement
    {
        public string PermissionName { get; }

        public EasilyAuthorizationRequirement([NotNull] string permissionName)
        {
            PermissionName = permissionName;
        }
    }
}
