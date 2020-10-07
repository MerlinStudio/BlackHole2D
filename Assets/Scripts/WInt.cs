using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WInt : MonoBehaviour
{
    [SerializeField] private GameObject Character;
    [SerializeField] private Transform Plane;
    [SerializeField] private float Speed;

    private bool isFlag;
    void Start()
    {
        isFlag = false;
    }
    private void FixedUpdate()
    {
        if (isFlag)
        {
            Character.transform.position = Vector2.MoveTowards(transform.position, Plane.position, Speed * Time.fixedDeltaTime);
            print("1");
            if (Character.transform.position == Plane.transform.position)
            {
                print("2");
                isFlag = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isFlag = true;
        }
    }
}
