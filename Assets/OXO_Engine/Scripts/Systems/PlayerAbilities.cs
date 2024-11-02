using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OXO_Engine.PlayerAbilities
{
    [Serializable]
    public class XJump
    {
        public float maxTime = 1;
        public int maxCount = 1;

        [HideInInspector] 
        public float TimeNow = 1;

        [HideInInspector] 
        public float CountNow = 0;
    }

    [Serializable]
    public class Dash
    {
        public float speed = 2f;
        public float time = 0.1f;
        public float regeneration_time = 2f;
        [HideInInspector]
        public float timeNow;
        
    }
}