using Microsoft.Extensions.DependencyInjection;
using Programming_Test_Core.BusinessLayer;
using Programming_Test_Core.BusinessLayer.Interface;
using Programming_Test_Core.DataLayer;
using Programming_Test_Core.DataLayer.Interface;

namespace Programming_Test_Core.DependencyContainer
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection Services)
        {
            #region BusinessLayer...
            Services.AddTransient<IContactoBAL, ContactosBAL>();
            #endregion

            #region DataLayer...
            Services.AddTransient<IContactoDAL, ContactosDAL>();
            #endregion
        }
    }
}
