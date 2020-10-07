using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameTimer.theFine = 10;
        }

    }
}
