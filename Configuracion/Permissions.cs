using System.Collections.Generic;
using System.Linq;


namespace RGNRK.Configuracion
{
    public static class Permissions
    {
        public static string Admin_Role = "Admin";
        public static string Manager_Role = "Manager";
        public static string Coach_Role = "Coach";
        public static string User_Role = "User";

        public static string Admin_Claim = "AccesoAdmin";
        public static string Manager_Claim = "AccesoManager";
        public static string Coach_Claim = "AccesoCoach";
        public static string User_Claim = "AccesoUser";


        public static List<string> GetRolesPermissions()
        {
            string[] RolePermissions = new string[]
            {
                Permissions.Admin_Role,
                Permissions.Manager_Role,
                Permissions.Coach_Role,
                Permissions.User_Role
            };
            return RolePermissions.ToList();
        }

        public static string GetRoleAdminPermissions()
        {
            return Permissions.Admin_Role;
        }
    }


}
