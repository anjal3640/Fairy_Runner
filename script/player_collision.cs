using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_collision : MonoBehaviour
{
    [SerializeField] AudioSource coinsound;
    [SerializeField] AudioSource sadsound;
    [SerializeField] AudioSource BGsound;
    [SerializeField] GameObject canvas1;
    [SerializeField] GameObject canvasEndGame;
    [SerializeField] TMP_Text finalPoints;
    
    public static int points = 0;
    public static bool shieldOn = false;
    public static float speed = -6f;
    
    private int updatespeed = 0;
    [SerializeField] private TMP_Text points_text;
    private bool endgame=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void gameRestart()
    {
        Debug.Log("load screeeeeennnnnnnnnnnnnnnnnnnnnnnn");
        SceneManager.LoadScene(0);
        speed = -6f;
        points = 0;
    }

    private IEnumerator ShieldActivated()
    {
        // shield ON
        shieldOn = true;

        // Wait 
        yield return new WaitForSeconds(10f);

        shieldOn = false;
    }

    private void OnTriggerEnter(Collider other)


    {
        
         if (other.gameObject.CompareTag("gem"))
        {
            points = points + 5;
            Destroy(other.gameObject);
            coinsound.Play();
            updatespeed = points % 5;
            if (updatespeed == 0)
            {
                speed = speed - 0.5f;
            }

        }
        else if (other.gameObject.CompareTag("coin"))
        {
            points = points + 1;
            Destroy(other.gameObject);
            coinsound.Play();
            updatespeed = points % 5;
            if (updatespeed == 0)
            {
                speed = speed - 0.5f;
            }

        }
        else if (other.gameObject.CompareTag("Shield"))
        {
            //Debug.Log("shild taken");
            StartCoroutine(ShieldActivated());
        }
        else if (!shieldOn)
        {
            //Debug.Log("shiled OFF");
            if (other.gameObject.CompareTag("obstacle") || other.gameObject.CompareTag("obstacle3"))
            {
                Debug.Log("OBSTACLEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
                speed = 0;
                endgame = true;
                sadsound.Play();
                BGsound.Pause();
            }
        }
        
        
        

    }

    // Update is called once per frame
    void Update()
    {
        points_text.text = "points: " + points ;
        if (endgame)
        {
            canvas1.gameObject.SetActive(false);
            finalPoints.text = "Points: " + points;
            canvasEndGame.gameObject.SetActive(true);
            endgame = false;
        }
        
    }
}
