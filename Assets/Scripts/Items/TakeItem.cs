using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    [SerializeField] private bool NeedNormalPlayer;
    [SerializeField] private bool NeedLittlePlayer;
    [SerializeField] private bool NeedMicroPlayer;

    [SerializeField] private float Speed;
    [SerializeField] private GameObject Item;
    [SerializeField] private string TagAnimation;

    private Transform target;
    private bool isFlag;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isFlag = false;
    }

    private void Update()
    {
        if (isFlag)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);          
        }       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "NormalPlayer" && NeedNormalPlayer == true)
        {
            PlayAnim();
        }

        if (collision.tag == "LittlePlayer" && NeedLittlePlayer == true)
        {
            PlayAnim();
        }

        if (collision.tag == "MicroPlayer" && NeedMicroPlayer == true)
        {
            PlayAnim();
        }
    }

    private void PlayAnim()
    {
        isFlag = true;
        if(Item != null)
        {
            Item.GetComponent<Animation>().Play(TagAnimation);           
        }

        NeedNormalPlayer = false;
        NeedLittlePlayer = false; 
        NeedMicroPlayer = false;
        Balls.instance.ScaleProgress(gameObject);
        Destroy(gameObject, 0.2f);
    }
}
