using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OXO_Engine
{
    public class WaitToNextLevel : MonoBehaviour
    {
        public float time;
        public int change;

        private void Start()
        {
            Invoke(nameof(Change), time);
        }

        private void Change()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + change);
        }
    }
}