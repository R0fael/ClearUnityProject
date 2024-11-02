using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OXO_Engine
{
    public class GameManager : MonoBehaviour
    {
        public float time = 1.0f;
        public float fixedTime = 0.02f;
        void Update()
        {
            Time.timeScale = time;
            Time.fixedDeltaTime = fixedTime * time;
        }

        public void ChangeLevel(int number)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + number);
        }

        public void SetLevel(int number)
        {
            SceneManager.LoadScene(number);
        }
    }
}
