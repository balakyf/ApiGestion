using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestion
{

    public static class ApiRoutes
    {
        public const string Version = "v1";
        public const string Root = "Api";
        public const string Base = Root + "/" + Version;

        public static class Posts
        {

            public const string ControllersRoute = Base + "/[controller]";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";
        }
    }
}
