using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OXO_Engine.Combat
{
    public class Gun : MonoBehaviour
    {
        [Header("Base")]
        public bool isEnemy;
        public Rigidbody2D rb;
        public float force = 200f;
        public Transform shot_point;

        [Space(8)]

        [Header("Shooting")]
        public GameObject bullet;
        public float countdown;
        private float countdown_now;

        [Space(8)]

        [Header("Enemy Only")]
        public LayerMask mask;
        public bool avoiding_waste;

        private void Start()
        {
            countdown_now = countdown;
        }
        void Update()
        {
            Rotation();

            Shooting();
        }

        private void Shooting()
        {
            countdown_now -= Time.deltaTime;

            if (countdown_now < 0)
            {
                if (!isEnemy)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Shoot();
                    }
                }
                else
                {
                    try
                    {
                        float distance = Vector3.Distance(transform.position, FindAnyObjectByType<PlayerMovement>().transform.position);
                        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance, mask);
                        if (hit.collider.CompareTag("PlayerMovement") || !avoiding_waste)
                        {
                            Shoot();
                        }
                    }
                    catch
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }

        private void Shoot()
        {
            GameObject b = Instantiate(bullet);
            b.transform.SetPositionAndRotation(shot_point.position, shot_point.rotation);
            
            if (rb != null)
            {
                rb.AddForce(-transform.right * force);
            }
            countdown_now = countdown;
            GetComponent<AudioSource>().Play();
        }

        private float Rotation()
        {
            if (!isEnemy)
            {
                Vector3 m_position = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
                m_position = new Vector3(m_position.x, m_position.y, 0);

                Vector3 difference = m_position - transform.position;
                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
                return rotZ;
            }
            else
            {
                try
                {
                    Vector3 playerPos = FindAnyObjectByType<PlayerMovement>().transform.position;
                    Vector3 difference = playerPos - transform.position;
                    float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
                    return rotZ;
                }
                catch
                {
                    Destroy(gameObject);
                }
            }
            return 0;
        }
    }
}