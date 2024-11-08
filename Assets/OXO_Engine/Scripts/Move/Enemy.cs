using OXO_Engine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OXO_Engine
{
    public class Enemy : MonoBehaviour
    {
        [Header("Enemy Script")]
        [Tooltip("The player, that has to be folowed")]
        public Transform player;
        [Tooltip("Is the movement will be Top-Down")]
        public bool isTopDown;
        [Tooltip("Speed")]
        public float speed;

        [Space(16)]

        [Header("Jumping")]
        [Tooltip("Height, but of a jump")]
        public float jumpHeight;
        [Tooltip("Tag, on which the enemy can jump")]
        public string jump_tag;
        [Tooltip("The difference of a player and an enemy to jump")]
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
                player = FindAnyObjectByType<PlayerMovement>().transform;
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
