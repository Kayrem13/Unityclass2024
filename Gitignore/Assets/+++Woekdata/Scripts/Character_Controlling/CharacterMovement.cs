using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private int frameCounter = 0;
    private int jumpCounter = 0;
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        frameCounter = frameCounter + 1;
        
        // Debug.Log("Update..." + frameCounter); 
    }

    void OnJump()
    { 
        jumpCounter = jumpCounter + 1;
       Debug.Log("jump " + jumpCounter); 
    }

    void OnMove()
    {
        
    }

    void OnSneak()
    {
        
    }

    void OnSprint()
    {
        
    }
    
}
