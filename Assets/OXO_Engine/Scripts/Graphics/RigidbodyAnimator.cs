using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OXO_Engine.Graphics
{
    [RequireComponent(typeof(DrawAnimation))]
    [RequireComponent (typeof(Rigidbody2D))]
    [Tooltip("Animates frame animation by velocity of the object")]
    public class RigidbodyAnimator : MonoBehaviour
    {

        public SpriteAnimation run;
        public SpriteAnimation idle;
        public SpriteAnimation fall;

        private Rigidbody2D rb;
        private DrawAnimation anim;

        void Start ()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<DrawAnimation>();
        }

        private void Update()
        {
            if (rb.linearVelocity.y != 0)
            {
                anim.cycle = fall;
            }
            else
            {
                if (rb.linearVelocity.x == 0)
                {
                    anim.cycle = idle;
                }
                else
                {
                    anim.cycle = run;
                }
            }

            if (GetComponent<Rigidbody2D>().linearVelocity.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (GetComponent<Rigidbody2D>().linearVelocity.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}
