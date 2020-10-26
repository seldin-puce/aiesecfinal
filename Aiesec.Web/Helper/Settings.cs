using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aiesec.Web.Helper
{
    public class Settings
    {
        public static class Constants
        {
            public static string ResourcePath = "Resources";
            public static string Empty = "";
        }
        public static class Routes
        {
            public static class User
            {
                public static string Index = "/administration/users/index";
                public static string Details = "/administration/users/details";
                public static string Update = "/administration/users/update";
                public static string Insert = "/administration/users/insert";
                public static string UpdateUser = "/administration/users/updateuser";
                public static string ChangeActiveStatus = "/administration/users/changeactivestatus";
                public static string RegisterUser = "/administration/users/registeruser";
            }

            public static class LocalCommittee
            {
                public static string Insert = "/administration/localcommittees/insert";
                public static string Details = "/administration/localcommittees/details";
                public static string ChangeActiveStatus = "/administration/localcommittees/changeactivestatus";
                public static string Edit = "/administration/localcommittees/edit";
                public static string Delete = "/administration/localcommittees/delete";
            }

            public static class MemberCommittee
            {
                public static string Insert = "/administration/membercommittees/insert";
                public static string Details = "/administration/membercommittees/details";
                public static string ChangeActiveStatus = "/administration/membercommittees/changeactivestatus";
                public static string Edit = "/administration/membercommittees/edit";
                public static string Delete = "/administration/membercommittees/delete";
            }


            public static class Team
            {
                public static string Insert = "/administration/teams/insert";
                public static string Details = "/administration/teams/details";
                public static string ChangeActiveStatus = "/administration/teams/changeactivestatus";
                public static string Edit = "/administration/teams/edit";
                public static string Delete = "/administration/teams/delete";
            }

            public static class Office
            {
                public static string Insert = "/administration/offices/insert";
            }

            public static class Profile
            {
                public static string ChangeProfilePhoto = "teammember/profiles/changeprofilephoto";
            }
        }
    }
}
