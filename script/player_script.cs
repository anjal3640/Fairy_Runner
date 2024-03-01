using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player_script : MonoBehaviour
{
    //variables
    public int currentline = 2;
    public Vector3 currentposition = new Vector3(-1.655f, 1.22f, 0f);
    public GameObject[] obstaclePreFabs;
    public GameObject _gameObject;
   

  
    private CapsuleCollider colliderComponent;
    private Vector3 originalcenter;
    private float originalheight;
    private int i = 0;
    private float lerpvalue;
    private float clampvalue;

    public static bool reverseOn = false;
    public static float TimeLeft = 10f;



    // Start is called before the first frame update
    void Start()
    {
        colliderComponent = GetComponent<CapsuleCollider>();
        originalcenter=colliderComponent.center;
        originalheight=colliderComponent.height;
    }

   

    private IEnumerator reverseFunction()
    {
        // set reverse value to negative 
        reverseOn=true;
        timerScript.timeLeft = 10f;

        // Wait 
        yield return new WaitForSeconds(10f);

        // Return the original value
        reverseOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("new_ground")) { 

             _gameObject = Instantiate(obstaclePreFabs[(Random.Range(0,5))], new Vector3(0,0,140), Quaternion.identity);
            
            //Debug.Log("hello");
        }
        else if (other.gameObject.CompareTag("reverse"))
        {
            StartCoroutine(reverseFunction());
            //Debug.Log("reverse");
            Destroy(other.gameObject);
        }
    }

    private IEnumerator MoveColliderUp()
    {
        // Move the collider upward 
        colliderComponent.center = new Vector3(0,1.4f,0);

        // Wait 
        yield return new WaitForSeconds(1f);

        // Return the collider to its original position
        colliderComponent.center = originalcenter;
    }

    private void moveLeft()
    {
        if (currentline != 1)
        {

            currentposition.x = currentposition.x - 1.655f ;

            
            
            //    clampvalue =(i+1)/10; // Normalize time between 0 and 1
            //    Debug.Log("CV"+clampvalue);
            //    lerpvalue = Mathf.Lerp(currentposition.x, currentposition.x - 1.655f, clampvalue);
            //    Debug.Log("LV"+lerpvalue);
            //    transform.position = new Vector3(lerpvalue,currentposition.y, currentposition.z);
            

            currentline--;
        }
    }

    private void moveRight()
    {
        if (currentline != 3)
        {
            currentposition.x = currentposition.x + 1.655f ;
            //for (i = 0; i < 10; i++)
            //{
            //    clampvalue = Mathf.Clamp01((i+1) / 10); // Normalize time between 0 and 1
            //    lerpvalue = Mathf.Lerp(currentposition.x, currentposition.x+1.655f, clampvalue);
            //    transform.position = new Vector3(lerpvalue, currentposition.y, currentposition.z);
            //}

            currentline++;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //moving sides
        currentposition = transform.position;

         
        if(Input.GetKeyDown(KeyCode.A))
        {
            if (reverseOn)
            {
                moveRight();
            }
            else
            {
                 moveLeft();
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (reverseOn) {
                moveLeft();
            }
            else
            {
                moveRight() ;
            }
        }

        //slide
        if (Input.GetKeyDown(KeyCode.S))
        {

            colliderComponent.height = 0.35f;


        }
        if (Input.GetKeyUp(KeyCode.S))
        {

            colliderComponent.height = originalheight;

        }

        //jump
        if (Input.GetKey(KeyCode.Space))
        {
            
            StartCoroutine(MoveColliderUp());

        }

        transform.position = currentposition;

        
                
    }
    
}
