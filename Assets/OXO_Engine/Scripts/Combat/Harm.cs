using OXO_Engine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harm : MonoBehaviour
{
    [Tooltip("Harm points per second")]
    public float harm;
    public bool isHarming = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent<HealthSystem>(out HealthSystem hp))
        {
            hp.health -= harm * Time.deltaTime;
        }
    }
}
