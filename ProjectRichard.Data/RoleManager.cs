using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectRichard.Data
{
    public static class RoleManager
    {
        public static List<string> GetRoles(BotRoles role)
        {
            ProjectRichardDBEntities context = new ProjectRichardDBEntities();
              
            return context.RoleConformities
                .Where(conformity => conformity.RealRole.ToUpper() == role.ToString().ToUpper())
                .Select(conformity => conformity.Role)
                .ToList();
        } 

        public static BotRoles GetRealRole(string role)
        {
            ProjectRichardDBEntities context = new ProjectRichardDBEntities();

            var realRole = context.RoleConformities
                .Where(conformity => conformity.Role.ToUpper() == role.ToUpper())
                .Select(conformity => conformity.RealRole)
                .FirstOrDefault();

            return realRole == null ? BotRoles.User : (BotRoles)Enum.Parse(typeof(BotRoles), realRole);
        }
    }
}
