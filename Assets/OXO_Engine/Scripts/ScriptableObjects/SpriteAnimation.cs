using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OXO_Engine.Graphics
{
    /// <summary>
    /// The animation for changing sprites
    /// </summary>
    [CreateAssetMenu]
    public class SpriteAnimation : ScriptableObject
    {
        [Tooltip("All frames for the animation")]
        public Sprite[] images;
        [Tooltip("The speed of drawing the animation in Frames Per Second")]
        public float fps = 5f;
    }
}