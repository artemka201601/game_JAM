using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;

        // Получаем текущий угол поворота спрайта по оси z
        float currentZRotation = transform.rotation.eulerAngles.z;

        // Вычисляем новый угол поворота в зависимости от направления движения
        float targetZRotation = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90;

        // Интерполируем между текущим и новым углом поворота, чтобы изменение было плавным
        float newZRotation = Mathf.LerpAngle(currentZRotation, targetZRotation, Time.deltaTime * 10f);

        // Применяем новый угол поворота
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newZRotation);
    }
}
