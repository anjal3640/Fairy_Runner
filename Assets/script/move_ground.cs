using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_ground : MonoBehaviour
{
    //public GameObject[] obstaclePreFabs;
    public float zSpaw = 0;
    public float groundLength = 50;
    private float speed = -6.0f;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    

    // Update is called once per frame
    void Update()
    {
       speed = player_collision.speed;
       ///Debug.Log(speed);

       if (speed != 0)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;

        }
        else
        {
           // Debug.Log("STOP");
        }
        
        if (transform.position.z < -30)
        {
            Destroy(gameObject);
        }
        

    }

   
}
