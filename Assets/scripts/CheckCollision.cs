using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCollision : MonoBehaviour
{
    public int pointsToAdd = 0; // Сколько очков добавлять при столкновении с этим NPC

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Проверяем, что столкнулись с игроком
            GameManager.instance.UpdateScore(pointsToAdd); // Обновляем счет в GameManager
            Destroy(gameObject); // Уничтожаем этот NPC
        }
    }
}
