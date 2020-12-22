using System.Web;
using System.Web.Mvc;

namespace Random_Restaurant_Picker
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
