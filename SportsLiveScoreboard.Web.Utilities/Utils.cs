using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportsLiveScoreboard.Web.Utilities
{
    public class Utils
    {
        public static string NameOfPage<T>() where T : PageModel
        {
            return typeof(T).Name.Replace("Model", "");
        }

        public static string NameOfPage<T>(string prependWith) where T : PageModel
        {
            return prependWith + NameOfPage<T>();
        }

        public static string NameOfPage<T>(string prependWith, string endWith) where T : PageModel
        {
            return prependWith + NameOfPage<T>() + endWith;
        }
    }
}