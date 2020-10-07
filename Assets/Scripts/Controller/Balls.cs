using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Balls : MonoBehaviour
{
    public static Balls instance = null;

    [SerializeField] private float NumberGoldGem;
    [SerializeField] private Image FillAmount;

    [SerializeField] private GameObject Massege_1;

    public static int progressLevel;

    bool isFlag_1;
    bool isFlag_2;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ScaleProgress(GameObject gameItem)
    {
        if (gameItem.tag == "Gold")
        {
            FillAmount.fillAmount += 1f / NumberGoldGem;
            CheckPoints();
        }

        if (gameItem.tag == "Gem")
        {
            FillAmount.fillAmount += 1f / NumberGoldGem * 5f;
            CheckPoints();
        }
    }

    private void CheckPoints()
    {
        if(FillAmount.fillAmount >= 0.6f && isFlag_1 == false)
        {
            if(progressLevel < 1)
            {
                progressLevel = 1;
            }
            Massege_1.SetActive(true);
            isFlag_1 = true;
            Invoke("Delay", 3);
        }
        if (FillAmount.fillAmount >= 0.8f && isFlag_2 == false)
        {
            if (progressLevel < 2)
            {
                progressLevel = 2;

            }
            isFlag_2 = true;
        }
        if (FillAmount.fillAmount == 1f)
        {
            if (progressLevel < 3)
            {
                progressLevel = 3;
            }
        }
    }

    private void Delay()
    {
        Massege_1.SetActive(false);
    }
}
