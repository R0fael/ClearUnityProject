using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OXO_Engine
{
    public class Test : MonoBehaviour
    {

        [Serializable]
        public class Question
        {
            public string question;
            public string[] answers;
            public int answer;
        }

        public TextMeshProUGUI[] options;

        public TextMeshProUGUI question;
        public AudioSource Wrong;
        public AudioSource Correct;
        public int score;
        public Question[] questions;

        private int selected = 0;
        private int current = 0;

        private void Update()
        {
            options[0].text = questions[current].answers[0];
            options[1].text = questions[current].answers[1];
            options[2].text = questions[current].answers[2];
            options[3].text = questions[current].answers[3];
            question.text = questions[current].question;

            if (selected != 0)
            {
                if (questions[current].answer == selected || questions[current].answer == -1) { Correct.Play(); score++; }
                else { Wrong.Play(); }
                selected = 0;
                current++;
                if (current > questions.Length - 1)
                {
                    SceneManager.LoadScene(4);
                }
            }
        }

        public void One()
        {
            selected = 1;
        }

        public void Two()
        {
            selected = 2;
        }

        public void Three()
        {
            selected = 3;
        }

        public void Four()
        {
            selected = 4;
        }
    }
}
