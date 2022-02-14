using IKnowTheAnswer.Core.Interfaces.Repositories;
using IKnowTheAnswer.Core.Interfaces.Services;
using IKnowTheAnswer.Infrastructure.Repositories;
using IKnowTheAnswer.Infrastructure.Services;

namespace IKnowTheAnswer.PresentationLayer.Helpers
{
    public class DependecyInjection
    {
        private static bool _injected = false;

        public static void Inject(IServiceCollection services)
        {
            if (_injected)
                return;

            InjectServices(services);
            InjectRepositories(services);

            SetInjected();
        }

        private static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }

        private static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IQuestionLoggerRepository, QuestionLoggerRepostory>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        private static void SetInjected()
            => _injected = true;
    }
}
