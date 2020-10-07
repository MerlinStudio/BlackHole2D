using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTrigger : MonoBehaviour
{
    [SerializeField] private GameObject TriggerOff;
    [SerializeField] private GameObject TriggerOn;
    [SerializeField] private float Time;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && TriggerOff != null)
            TriggerOff.SetActive(false);

        if (collision.tag == "Player" && TriggerOn != null)
            TriggerOn.SetActive(true);

        Invoke("Delay", Time);
    }

    private void Delay()
    {
        if(TriggerOff != null)
            TriggerOff.SetActive(true);

        if (TriggerOn != null)
            TriggerOn.SetActive(false);
    }

}
