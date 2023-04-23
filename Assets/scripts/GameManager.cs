using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    private int score = 0; // Текущее значение счета

    private void Awake()
    {
        // Инициализируем singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd; // Добавляем очки
        Debug.Log("Score: " + score); // Выводим значение счета в консоль для отладки
    }
}
