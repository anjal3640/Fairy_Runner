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

        transform.position = currentposition;



    }
}
