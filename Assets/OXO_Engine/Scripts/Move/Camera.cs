using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OXO_Engine
{
    public class Camera : MonoBehaviour
    {
        public Transform folowObject;
        public float maxX;
        public float maxY;
        public float speed;

        private void Update()
        {

            if (folowObject.position.x - transform.position.x > maxX || folowObject.position.x - transform.position.x < -maxX)
            {
                transform.Translate(speed * Time.deltaTime * new Vector3(folowObject.position.x - transform.position.x, 0, 0));
            }

            if (folowObject.position.y - transform.position.y > maxY || folowObject.position.y - transform.position.y < -maxY)
            {
                transform.Translate(speed * Time.deltaTime * new Vector3(0, folowObject.position.y - transform.position.y, 0));
            }
        }

        [ExecuteInEditMode]
        private void OnDrawGizmos()
        {
            Vector3 pos = transform.position;

            Vector3 posA = pos + new Vector3(-maxX, maxY, -pos.z);
            Vector3 posB = pos + new Vector3(maxX, maxY, -pos.z);
            Vector3 posC = pos + new Vector3(maxX, -maxY, -pos.z);
            Vector3 posD = pos + new Vector3(-maxX, -maxY, -pos.z);

            Debug.DrawLine(posA, posB, Color.red);
            Debug.DrawLine(posB, posC, Color.red);
            Debug.DrawLine(posC, posD, Color.red);
            Debug.DrawLine(posD, posA, Color.red);
        }
    }
}