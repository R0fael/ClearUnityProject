using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OXO_Engine
{
    public class Folow : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset;

        private void Update()
        {
            if (target == null)
            {
                Destroy(gameObject);
            }
            if (target != null)
            {
                transform.position = target.position + offset;
            }
        }
    }
}