using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OXO_Engine
{
    public class Target : MonoBehaviour
    {
        public GameObject asteroid;
        public float time;
        void Start()
        {
            Invoke(nameof(Launch), time);
        }

        void Launch()
        {
            GameObject modify = asteroid;
            modify.transform.position = transform.position;

            Instantiate(modify);
            Destroy(gameObject);
        }
    }
}