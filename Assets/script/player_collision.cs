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
    [SerializeField] GameObject heal;
    [SerializeField] TMP_Text High_Score;


    public static int points = 0;
    public static bool shieldOn = false;
    public static float speed = -6f;
    public static int highscorecount;
    
    private int updatespeed = 0;
    [SerializeField] private TMP_Text points_text;
    private bool endgame=false;
    // Start is called before the first frame update
    void Start()
    {
        // Check if the "HighScore" key exists in PlayerPrefs
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscorecount = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highscorecount = 0;
            PlayerPrefs.SetInt("HighScore", highscorecount);
        }
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
        heal.SetActive(true);

        // Wait 
        yield return new WaitForSeconds(10f);

        shieldOn = false;
        heal.SetActive(false);
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
        else if ((other.gameObject.CompareTag("obstacle") || other.gameObject.CompareTag("obstacle3"))&& !shieldOn)
        {
            //Debug.Log("shiled OFF");
            // Debug.Log("OBSTACLEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
                speed = 0;
                endgame = true;
                sadsound.Play();
            BGsound.Pause();
            player_script.reverseOn = false;
            timerScript.timeLeft = 0;
        }
        else if (other.gameObject.CompareTag("Shield"))
        {
            Debug.Log("shild taken");
            StartCoroutine(ShieldActivated());
            Destroy(other.gameObject);
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
            if(points>highscorecount)
            {
                highscorecount = points;
                PlayerPrefs.SetInt("HighScore",highscorecount);
            }
            High_Score.text ="High Score: "+highscorecount;
            canvasEndGame.gameObject.SetActive(true);
            endgame = false;
        }
        
    }
}
