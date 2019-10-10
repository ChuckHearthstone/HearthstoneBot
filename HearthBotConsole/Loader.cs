using UnityEngine;

namespace HearthBotConsole
{
    public class Loader
    {
        private static GameObject _Load;
        public static void Init()
        {
            _Load = new GameObject();
            _Load.AddComponent<Main>();
            GameObject.DontDestroyOnLoad(_Load);
        }
        public static void Unload()
        {
            _Unload();
        }
        private static void _Unload()
        {
            GameObject.Destroy(_Load);
        }
        private GameObject _gameObject;
    }
}
