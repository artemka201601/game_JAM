using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetection : MonoBehaviour
{
    public start_timer start_timer; // Ссылка на скрипт, в котором нужно изменить переменную
    public float plus = 10f;
    public GameObject npcPrefab; // Префаб для создания новых экземпляров NPC

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Изменяем переменную в другом скрипте на +5
            start_timer.timeLeft += plus;
            Destroy(gameObject);
        }
    }
}