using IKnowTheAnswer.Presentation.Services;
using IKnowTheAnswer.Presentation.Services.Interfaces;

namespace IKnowTheAnswer.Presentation.Helpers
{
    public class DependecyInjection
    {
        private static bool _injected = false;

        public static void Inject(IServiceCollection services)
        {
            if (_injected)
                return;

            InjectServices(services);

            SetInjected();
        }

        private static void InjectServices(IServiceCollection services)
        {
            services.AddHttpClient<IUserService, UserService>();

            services.AddScoped<IUserService, UserService>();
        }

        private static void SetInjected()
            => _injected = true;
    }
}
