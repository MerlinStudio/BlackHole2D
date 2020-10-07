
using UnityEngine;

public class EventSize : MonoBehaviour
{
    [SerializeField] private bool NeedBigPlayer;
    [SerializeField] private bool NeedNormalPlayer;
    [SerializeField] private bool NeedLittlePlayer;
    [SerializeField] private bool NeedMicroPlayer;

    [SerializeField] private bool TurnOffOn;

    [SerializeField] private GameObject[] Event;
    private void OnTriggerStay2D(Collider2D col)
    {
        if (NeedBigPlayer == true)
        {
            if (col.tag == "BigPlayer")
            {
                if (TurnOffOn == true)
                    OnColloder();
                else
                    OffColloder();
            }
        }

        if (NeedNormalPlayer == true)
        {
            if (col.tag == "NormalPlayer")
            {
                if (TurnOffOn == true)
                    OnColloder();
                else
                    OffColloder();
            }
        }

        if (NeedLittlePlayer == true)
        {
            if (col.tag == "LittlePlayer")
            {
                if (TurnOffOn == true)
                    OnColloder();
                else
                    OffColloder();
            }
        }

        if (NeedMicroPlayer == true)
        {
            if (col.tag == "MicroPlayer")
            {
                if (TurnOffOn == true)
                    OnColloder();
                else
                    OffColloder();
            }
        }
    }

    private void OnColloder()
    {
        for (int i = 0; i < Event.Length; i++)
        {
            Event[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OffColloder()
    {
        for (int i = 0; i < Event.Length; i++)
        {
            Event[i].GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
