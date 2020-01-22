namespace TestApp.Http
{
    public static class ApiRoutes
    {
        private const string Base = "/api";

        public static class Posts
        {
            private const string PostBase = Base + "/posts";

            public const string GetAll = PostBase + "";
            public const string GetOne = PostBase + "/{postId}";
            public const string Create = PostBase + "";
            public const string Update = PostBase + "/{postId}";
            public const string Delete = PostBase + "/{postId}";
        }

        public static class Identity
        {
            private const string IdentityBase = Base + "/auth";

            public const string Register = IdentityBase + "/register";
            public const string Login = IdentityBase + "/login";
            public const string Logout = IdentityBase + "/logout";
        }
    }
}