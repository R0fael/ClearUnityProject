using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OXO_Engine
{
    /// <summary>
    /// Door Open / Closer class.
    /// </summary>
    public class Door : MonoBehaviour
    {
        public EventTrigger trigger;

        public float state;

        private Vector3 startPoint;

        private void Start()
        {
            UnityEvent open = trigger.functions[0];
            UnityEvent close = trigger.functions[1];

            open.AddListener(Open);
            close.AddListener(Close);

            startPoint = transform.position;
        }

        private void FixedUpdate()
        {
            transform.Translate(transform.localScale.y * state * Time.fixedDeltaTime * Vector3.up);

            if (startPoint == transform.position)
            {
                state = 0;
            }

            if((startPoint.y + transform.localScale.y) < transform.position.y || (startPoint.y - transform.localScale.y) > transform.position.y)
            {
                state = 0;
            }
        }

        public void StopMovement()
        {
            state = 0;
        }

        public void Open()
        {
            state = 1;
        }

        public void Close()
        {
            state = -1;
        }
    }
}