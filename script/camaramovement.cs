using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaramovement : MonoBehaviour
{
    public int currentline = 2;
    public Vector3 currentposition = new Vector3(0.068950057f, 3.4000001f, -5.32999992f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentposition = transform.position;


        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    if (currentline != 1)
        //    {
        //        currentposition.x = currentposition.x - 1.655f;
        //      //  Debug.Log(currentposition.x.ToString());
        //        currentline--;
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    if (currentline != 3)
        //    {
        //        currentposition.x = currentposition.x + 1.655f;
        //       // Debug.Log(currentposition.x.ToString());
        //        currentline++;
        //    }
        //}


        transform.position = currentposition;



    }
}
