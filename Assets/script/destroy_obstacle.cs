using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("obstacle3")|| other.gameObject.CompareTag("obstacle")){
            Destroy(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
