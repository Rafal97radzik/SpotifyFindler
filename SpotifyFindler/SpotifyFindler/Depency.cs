using SpotifyFindler.Web;
using SpotifyFindler.Web.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyFindler
{
    public static class Depency
    {
        private static Dictionary<Type, Type> typesDepency;

        static Depency()
        {
            typesDepency = new Dictionary<Type, Type>();

            typesDepency.Add(typeof(IWebClient), typeof(SpotifyAuthorization));
        }

        public static T GetInstance<T>() where T: class
        {
            Type type = typesDepency[typeof(T)];
            return Activator.CreateInstance(type) as T;
        }
    }
}
