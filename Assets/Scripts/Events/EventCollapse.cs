using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventCollapse : MonoBehaviour
{
    public static EventCollapse instance = null;

    [SerializeField] private GameObject ObjForOn;
    [SerializeField] private GameObject ObjForDestoy;
    [SerializeField] private Image FillAmount;
    [SerializeField] private float Coefficient;
    [Space]
    [SerializeField] private GameObject MainObject;
    [SerializeField] private GameObject ObjAnimaion;
    [SerializeField] private string TagAnimation;
    [Space]
    [SerializeField] private GameObject Character;
    [SerializeField] private GameObject Char;
    [SerializeField] private GameObject ParticelSystem;
    [SerializeField] private string TagSizePlayer;
    [Space]
    [SerializeField] private float Timer;
    [Header ("false = left, true = right")]
    [SerializeField] private bool DirectionEyes;

    private Coroutine isCoroutine;
    private bool isFlagPressed;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        ObjAnimaion.GetComponent<Animator>().enabled = false;
        MainObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void FixedUpdate()
    {
        if (isFlagPressed == true)
        {
            FillAmount.fillAmount += Coefficient * Time.fixedDeltaTime / 0.9f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            ObjAnimaion.GetComponent<Animator>().enabled = true;
            if (Char.tag == TagSizePlayer)
            {
                ObjForOn.SetActive(true);
                FillAmount.gameObject.SetActive(true);
            }
            if (Char.tag != TagSizePlayer)
            {
                ObjForOn.SetActive(false);
                FillAmount.gameObject.SetActive(false);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StopAllCoroutines();
            FillAmount.gameObject.SetActive(false);
        }
    }

    public void StartEvent()
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
        ObjAnimaion.GetComponent<Animator>().SetTrigger(TagAnimation);
        Character.GetComponent<MoveCharacter>().enabled = false;
        ParticelSystem.SetActive(true);
        isCoroutine = StartCoroutine(EndEvent());
    }

    public void StopEvent()
    {
        isFlagPressed = false;
        FillAmount.fillAmount = 0;
        ObjAnimaion.GetComponent<Animator>().SetTrigger("Event interruption");
        Character.GetComponent<MoveCharacter>().enabled = true;
        ParticelSystem.SetActive(false);
        StopCoroutine(isCoroutine);
    }

    IEnumerator EndEvent()
    {
        yield return new WaitForSeconds(Timer);
        {
            ParticelSystem.SetActive(false);
            MainObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Character.GetComponent<MoveCharacter>().enabled = true;
            FillAmount.gameObject.SetActive(false);
            StopCoroutine(isCoroutine);
            Destroy(ObjForDestoy);
            Destroy(gameObject);
        }
    }
}
