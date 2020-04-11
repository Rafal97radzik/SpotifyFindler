using SpotifyFindler.Web;
using SpotifyFindler.Web.Spotify;
using SpotifyFindler.Web.Spotify.Auth;
using System;
using System.Collections.Generic;

namespace SpotifyFindler
{
    public static class Depency
    {
        private static Dictionary<Type, Type> typesDepency;


        static Depency()
        {
            typesDepency = new Dictionary<Type, Type>();

            AddDepency<IWebClient, WebClient>();
            AddDepency<ISpotifyAuth, SpotifyAuthorization>();
            AddDepency<ISpotifyAPI, SpotifyWebAPI>();
        }


        public static K GetInstance<K>() where K : class
        {
            Type type = typesDepency[typeof(K)];
            return Activator.CreateInstance(type) as K;
        }

        public static void AddDepency<K, T>() where K : class where T : class, new()
        {
            typesDepency.Add(typeof(K), typeof(T));
        }

        public static void RemoveDepency<K>() where K : class
        {
            typesDepency.Remove(typeof(K));
        }

        public static void ChangeDepency<K, T>() where K : class where T : class, new()
        {
            typesDepency[typeof(K)] = typeof(T);
        }
    }
}
