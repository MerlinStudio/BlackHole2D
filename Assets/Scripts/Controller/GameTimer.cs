using System;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private GameObject BlockDisplay;
    [SerializeField] private GameObject TimeIsOver;
    [SerializeField] private GameObject Character;
    [SerializeField] private GameObject Countdown;
    [SerializeField] private Text TextTimer;
    [SerializeField] private float seconds;

    [SerializeField] private GameObject TheFine;

    public static float theFine;
    public static bool _start;

    private void Start()
    {
        BlockDisplay.SetActive(true);
        Character.GetComponent<Animation>().Play("Start");
        _start = false;
        TimeSpan ts = TimeSpan.FromSeconds(seconds);
        TextTimer.text = ts.ToString(@"mm\:ss\:ff");
    }

    void Update()
    {
        if(_start == true)
        {
            seconds -= 1 * Time.deltaTime;
            if(theFine != 0)
            {
                TheFine.SetActive(true);
                Invoke("Delay_2", 2);
                seconds -= theFine;
                theFine = 0;
                print("1");
            }
            if (seconds < 0)
            {
                seconds = 0;
            }
            TimeSpan ts = TimeSpan.FromSeconds(seconds);
            TextTimer.text = ts.ToString(@"mm\:ss\:ff");

            if (seconds <= 30)
            {
                TextTimer.GetComponent<Text>().color = new Color(1, 0, 0);
            }

            if (seconds <= 0)
            {
                BlockDisplay.SetActive(true);
                TimeIsOver.SetActive(true);
                gameObject.GetComponent<GameTimer>().enabled = false;
            }
        }
    }

    public void StartGame()
    {
        Countdown.GetComponent<Animation>().Play("Countdown");
        Invoke("Delay", 2.5f);
    }

    private void Delay()
    {
        BlockDisplay.SetActive(false);
        _start = true;
    }

    private void Delay_2()
    {
        TheFine.SetActive(false);
    }

    public void Pause(bool pause)
    {
        if(pause == true)
        {
            Time.timeScale = 0;
        }

        else
        {
            Time.timeScale = 1;
        }
    }
}
