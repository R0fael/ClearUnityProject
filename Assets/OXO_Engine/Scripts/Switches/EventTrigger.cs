using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace OXO_Engine
{
    /// <summary>
    /// 0X0 Engine Button Class.
    /// </summary>
    public class EventTrigger : MonoBehaviour
    {
        public enum PressEvent
        {
            EnterAndExit,
            State
        }

        public int id = 0;
        public PressEvent pressEvent;
        public string[] tags;
        public UnityEvent[] functions;

        private int state;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.isTrigger)
            {
                Press();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.isTrigger)
            {
                if (pressEvent == 0)
                {
                    functions[1]?.Invoke();
                }
            }
        }

        public void Press()
        {
            if (pressEvent == PressEvent.EnterAndExit)
            {
                functions[0]?.Invoke();
            }

            if (pressEvent == PressEvent.State)
            {
                state++;
                if (state > functions.Length - 1)
                {
                    state = 0;
                }
                functions[state]?.Invoke();
            }
        }
    }
}
