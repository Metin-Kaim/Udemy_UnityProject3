using UnityEngine;

namespace UdemyProject3.Abstracts.Helpers
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get;private set; }

        protected void SetSingletonThisGameObject(T instance)
        {
            if(instance != null)
            {
                Instance = instance;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
