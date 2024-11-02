using OXO_Engine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OXO_Engine
{
    public class Enemy : MonoBehaviour
    {
        public Transform player;
        public bool isTopDown;
        public float speed;
        public float jumpHeight;
        public string jump_tag;
        public float jump_difference;

        [HideInInspector]
        public HealthSystem healthSystem;

        private Rigidbody2D rb;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            healthSystem = rb.GetComponent<HealthSystem>();
            if (player == null)
            {
                player = FindObjectOfType<PlayerMovement>().transform;
            }
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 difference = player.position - transform.position;
            if (isTopDown)
            {
                rb.linearVelocity = difference.normalized * speed;
            }
            else 
            {
                rb.linearVelocity = new Vector2(difference.normalized.x * speed,rb.linearVelocity.y);
            }
        }

        private void OnTriggerStay2D(Collider2D collider)
        {
            if(collider.CompareTag(jump_tag) && !isTopDown && player.transform.position.y - jump_difference > transform.position.y)
            {
                rb.AddForce(new Vector2(0, jumpHeight * 10));
            }
        }
    }
}
