using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startgame : MonoBehaviour
{
    public Canvas canvasToDisable;
    public Text text;
    private void Start(){
        
    }
    
    public void Hide()
    {
        canvasToDisable.gameObject.SetActive(false);
        //start_timer start_timer = GetComponent<start_timer>();
        start_timer start_timer_script = text.GetComponent<start_timer>();
        start_timer_script.enabled = true;
        Cursor.visible = false;
    }
}
