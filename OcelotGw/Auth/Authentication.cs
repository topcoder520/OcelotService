namespace Microsoft.Extensions.DependencyInjection
{
    public static class Authentication
    {
        /// <summary>
        /// 对上游的请求对应的下游地址进行认证
        /// </summary>
        /// <param name="services"></param>
        public static void AuthenticationRoute(this IServiceCollection services)
        {
            var AuthenticationProviderKey = "TestKey";
            services.AddAuthentication()
                    .AddJwtBearer(AuthenticationProviderKey, option =>
                    {
                        option.Authority = "test";
                        option.Audience = "test";
                    })
                    //其他认证
                    ;

        }
    }
}
