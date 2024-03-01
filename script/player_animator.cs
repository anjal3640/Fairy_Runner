using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animator : MonoBehaviour
{

    private Animator animator;
    private bool fall=false;
    private bool slide;
    private bool jump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        slide = false;
        jump = false;
        if (Input.GetKey(KeyCode.S))
        {
            slide = true;

            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            
        }
        if (player_collision.speed == 0)
        {
            fall = true;
            animator.SetBool("fall",fall);
            // Debug.Log("fall");
        }
        else
        {
            fall = false;
            animator.SetBool("fall", fall);
        }
        animator.SetBool("slide", slide);
        animator.SetBool("jump", jump);

    }
}
