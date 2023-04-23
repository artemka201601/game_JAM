using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start_timer : MonoBehaviour
{
    public float totalTime = 60f; // общее время в секундах
    private float timeLeft; // оставшееся время
    public Text timerText; // текстовое поле, в котором будет отображаться время

    void Start()
    {
        timeLeft = totalTime; // установка начального времени
    }

    void Update()
    {
        timeLeft -= Time.deltaTime; // уменьшение времени на прошедшее время
        if (timeLeft < 0)
        {
            timeLeft = 0; // если время истекло, остановить таймер
        }
        timerText.text = FormatTime(timeLeft); // обновление текста с отформатированным временем
    }

    // метод для форматирования времени в формат ММ:СС
    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        return timeString;
    }
}
