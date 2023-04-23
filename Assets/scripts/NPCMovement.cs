using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float moveSpeed;

    void Start () {
        StartCoroutine(Move());
    }

    IEnumerator Move() {
        while (true) {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            Vector2 movement = new Vector2(x, y);
            GetComponent<Rigidbody2D>().velocity = movement * moveSpeed;
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }
}
