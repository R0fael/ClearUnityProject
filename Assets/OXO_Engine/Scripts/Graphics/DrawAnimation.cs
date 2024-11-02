using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OXO_Engine.Graphics {
    public class DrawAnimation : MonoBehaviour
    {
        public SpriteAnimation cycle;
        public int imageid = 0;
        private SpriteRenderer sr;

        private float timeToEnd = 0;

        void Start ()
        {
            imageid = 0;
            sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if(0 > timeToEnd)
            {
                timeToEnd = 1 / cycle.fps;
                imageid ++;
            }
            if(imageid > cycle.images.Length - 1)
            {
                imageid = 0;
            }
            timeToEnd -= Time.deltaTime;
            sr.sprite = cycle.images[imageid];
        }
    }
}
