using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool isNegative;
    public UnityEvent onStop;
    public float time;

    private void Update()
    {
        if (!isNegative)
        {
            time += Time.deltaTime;
        }
        else
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                onStop.Invoke();
            }
        }
        text.text = ((int)time).ToString();
    }

    public void AddTime(float seconds) {
        time += seconds;
    }
}
