using UnityEngine;
namespace OXO_Engine
{

    public class DontDestroyOnLoad : MonoBehaviour
    {
        public bool isWorking = true;
        public bool isSingleton = false;
        public int singletonID;
        void Start()
        {
            if (isSingleton)
            {
                DontDestroyOnLoad[] objects = FindObjectsByType<DontDestroyOnLoad>(FindObjectsSortMode.None);
                foreach (DontDestroyOnLoad l in objects)
                {
                    if (l.isSingleton && l.singletonID == singletonID && l.gameObject != gameObject)
                    {
                        Destroy(gameObject);
                    }
                }
            }
            DontDestroyOnLoad(this);
        }
    }
}
