using OXO_Engine.PlayerAbilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OXO_Engine
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        public bool isTopDown;
        public float gravity = 1f;
        public float speed = 2f;
        public float jump_height;
        public string jump_tag;

        [Space(8)]
        [Header("Abilities")]
        public XJump xJump;
        public Dash dash;

        private Rigidbody2D rb;


        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            Movement();

            if (isTopDown)
            {
                rb.gravityScale = 0;
            }
            else
            {
                rb.gravityScale = gravity;
            }
        }

        #region Functions

        void Movement()
        {
            Dash();

            if (isTopDown)
            {
                rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
            }
            else
            {
                rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.linearVelocity.y);
                XJump();
            }
        }

        #endregion

        #region abilities

        void XJump()
        {
            xJump.TimeNow = xJump.maxTime;
            if (xJump.TimeNow > 0 && xJump.CountNow < xJump.maxCount && Input.GetKeyDown(KeyCode.W))
            {
                xJump.CountNow++;
                xJump.TimeNow = xJump.maxTime;
                rb.AddForce(new Vector2(0, Mathf.Round(Input.GetAxis("Vertical")) * jump_height * 20));
            }
        }

        void Dash()
        {
            if (Input.GetKey(KeyCode.Mouse0) && dash.timeNow > 0)
            {
                Vector3 mouse_position = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 direction = new(mouse_position.x - transform.position.x, mouse_position.y - transform.position.y, 0);
                transform.Translate(dash.speed * Time.deltaTime * direction.normalized);
                dash.timeNow -= Time.deltaTime;
            }
            else
            {
                if (dash.timeNow < dash.time && !Input.GetKey(KeyCode.Mouse0))
                {
                    dash.timeNow += Time.deltaTime / dash.regeneration_time;
                }
            }
        }

        #endregion

        #region Collision
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag(jump_tag) && !isTopDown)
            {
                rb.AddForce(new Vector2(0, Mathf.Round(Input.GetAxis("Vertical")) * jump_height * 10));
                xJump.TimeNow = xJump.maxTime;
                xJump.CountNow = 1;
            }
        }
        #endregion

    }
}
