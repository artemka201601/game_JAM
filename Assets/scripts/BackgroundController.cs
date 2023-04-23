using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float length, length1, startpos, startpos1;
    public GameObject cam;
    public float parallaxEffect;

    void Start(){
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        startpos1 = transform.position.y;
        length1 = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void FixedUpdate(){
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        float temp1 = (cam.transform.position.y * (1 - parallaxEffect));
        float dist1 = (cam.transform.position.y * parallaxEffect);

        //transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        transform.position = new Vector3(startpos + dist, startpos1 + dist1, transform.position.z);
        if(temp> startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -=length;

        if(temp1> startpos1 + length1) startpos1 += length1;
        else if (temp1 < startpos1 - length1) startpos1 -=length1;
    }
}
