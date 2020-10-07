using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventMagnet : MonoBehaviour
{
    public static EventMagnet instance = null;

    [SerializeField] private GameObject Character;
    [SerializeField] private GameObject Char;
    [SerializeField] private GameObject ParticelSystem;
    [SerializeField] private string TagSizePlayer;
    [SerializeField] private Image FillAmount;
    [SerializeField] private float Coefficient;
    [SerializeField] private GameObject[] HingeJoint;
    [Header("false = left, true = right")]
    [SerializeField] private bool DirectionEyes;

    private bool isFlagPressed;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void FixedUpdate()
    {
        if(isFlagPressed == true)
        {
            FillAmount.fillAmount += Coefficient * Time.fixedDeltaTime;
            if (FillAmount.fillAmount == 1)
            {
                NoUseMotor();
            }
        }
        else
        {
            FillAmount.fillAmount -= Coefficient * 2 * Time.fixedDeltaTime;              
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Char.tag == TagSizePlayer)
            {
                FillAmount.gameObject.SetActive(true);
            }
            if (Char.tag != TagSizePlayer)
            {
                FillAmount.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FillAmount.gameObject.SetActive(false);
        }
    }

    public void UseMotor()
    {
        if (DirectionEyes)
        {
            Char.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            Char.GetComponent<SpriteRenderer>().flipX = false;
        }
        Char.GetComponent<SpriteRenderer>().sprite = MoveCharacter.instance.CharSprites[1];
        isFlagPressed = true;
        ParticelSystem.SetActive(true);
        Character.GetComponent<MoveCharacter>().enabled = false;
        for (int i = 0; i < HingeJoint.Length; i++)
        {
            HingeJoint[i].GetComponent<HingeJoint2D>().useMotor = true;
        }
    }

    public void NoUseMotor()
    {
        isFlagPressed = false;
        ParticelSystem.SetActive(false);
        Character.GetComponent<MoveCharacter>().enabled = true;
        for (int i = 0; i < HingeJoint.Length; i++)
        {
            HingeJoint[i].GetComponent<HingeJoint2D>().useMotor = false;
        }
    }
}
