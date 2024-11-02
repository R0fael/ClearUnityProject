using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    private float time;

    private void Update()
    {
        time += Time.deltaTime;
        text.text = ((int)time).ToString();
    }
}
