using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public static Countdown instance;

    public float timeLeft;
    public bool stop = true;

    private float minutes;
    private float seconds;
    private Text timerText;

    private void Start()
    {
        instance = this;
        timerText = GetComponent<Text>();
        StartTimer(timeLeft);
    }

    public void StartTimer(float from)
    {
        stop = false;
        timeLeft = from;
        Update();
        StartCoroutine(UpdateCoroutine());
    }

    void Update()
    {
        if (stop) return;
        timeLeft -= Time.deltaTime;

        minutes = Mathf.Floor(timeLeft / 60);
        seconds = timeLeft % 60;
        if (seconds > 59) seconds = 59;
        if (minutes < 0)
        {
            stop = true;
            minutes = 0;
            seconds = 0;


        }
        if (stop) OnTimerFinish();
    }
    private IEnumerator UpdateCoroutine()
    {
        while (!stop)
        {
            timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void OnTimerFinish()
    {
        GameManager.instance.GameOver();
    }
}
