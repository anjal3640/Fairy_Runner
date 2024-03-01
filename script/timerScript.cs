using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
    Image timerBar;
    private float maxTime = 10f;
    public static float timeLeft;

   

    // Start is called before the first frame update
    void Start()
    {
        
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        timerBar.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (player_script.reverseOn)
        {
            timerBar.enabled = true;
            //Debug.Log("ENTERED THE FIRST LOOP");
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - Time.deltaTime;
               // Debug.Log("timeleft"+ timeLeft);
                timerBar.fillAmount = timeLeft / maxTime;
               // Debug.Log("TIMERBAR" + timerBar);
            }
        }
        else
        {
            timerBar.enabled = false;
        }

    }
}
