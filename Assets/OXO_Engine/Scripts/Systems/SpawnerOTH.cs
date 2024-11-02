using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace OXO_Engine
{
    public class SpawnerOTH : MonoBehaviour
    {
        public float time;
        private float time_now;
        public GameObject prefab;
        public Transform points;
        void Update()
        {
            if (time_now < 0)
            {
                GameObject b = Instantiate(prefab);

                Transform[] children = new Transform[points.childCount];

                int index = 0;

                foreach (Transform t in points)
                {
                    children.SetValue(t, index);
                    index++;
                }

                b.transform.position = children[Random.Range(0, points.childCount)].position;

                time_now = time;
            }
            time_now -= Time.deltaTime;
        }
    }
}