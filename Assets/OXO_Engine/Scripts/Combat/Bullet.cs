using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OXO_Engine.Combat
{
    public class Bullet : MonoBehaviour
    {
        //public bool isEnemy;
        public float speed;
        public float damage;
        public LayerMask mask;


        private void Update()
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, 0.5f, mask);

            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.TryGetComponent<HealthSystem>(out HealthSystem hp))
                {
                    hp.health -= damage;
                }
                if (hitInfo.collider.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
                {
                    rb.AddForce(transform.right * speed);
                }
                if (hitInfo.collider.CompareTag("Bounce"))
                {
                    transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 45);
                    transform.Translate(new Vector3(speed * 2 * Time.deltaTime, 0, 0));
                }
                Destroy(gameObject);
            }

            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Untagged"))
            {
                Destroy(gameObject);
            }
        }
    }
}