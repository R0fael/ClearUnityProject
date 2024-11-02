using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OXO_Engine
{
    public class HealthSystem : MonoBehaviour
    {
        public float health;
        public float maxHealth = 100f;
        public UnityEvent death;

        [Header("Health Bar")]
        public Image image;
        public TextMeshProUGUI text;

        private void Update()
        {
            health = Mathf.Clamp(health,0,maxHealth);

            if(health == 0)
            {
                death.Invoke();
            }

            if (text != null)
            {
                text.text = Mathf.Round(health).ToString();
            }

            if (image != null)
            {
                image.fillAmount = health/maxHealth;
            }
        }
    }
}