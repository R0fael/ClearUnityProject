using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool isNegative;
    public float time;
    public UnityEvent onTimerEnd;

    private void Update()
    {
        if (isNegative)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                onTimerEnd.Invoke();
            }
        }
        else
        {
            time += Time.deltaTime;
        }
        text.text = ((int)time).ToString();
    }
}
