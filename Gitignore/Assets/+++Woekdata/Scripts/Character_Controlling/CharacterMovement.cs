using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputDirection;
    [SerializeField] private float jumpforce = 5f;
    [SerializeField] private float movementspeed = 5f;

    [SerializeField] private Transform groundCheckPosition;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask layerGroundcheck;

    private bool isFacingRight = true;
    
    // Start is called before the first frame update    
    private int frameCounter = 0;
    private int jumpCounter = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        frameCounter = frameCounter + 1;
        
        // Debug.Log("Update..." + frameCounter); 
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputDirection * movementspeed, rb.velocity.y);
    }
    

    void OnJump()
    {
        if (Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, layerGroundcheck))
        {
            rb.velocity = new Vector2(0f, jumpforce);
            jumpCounter = jumpCounter + 1;
            Debug.Log("jump " + jumpCounter);  
        }
            
        
    }

    void OnMove(InputValue inputValue)
    {
        inputDirection = inputValue.Get<float>();
        Debug.Log("move " + inputDirection);
        
        if (inputDirection > 0 && !isFacingRight)
        {
            flipp();
        }
        else if (inputDirection < 0 && isFacingRight)
        {
            flipp();
        }
    }

    void flipp()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x = currentScale.x * -1;
        transform.localScale = currentScale;

        isFacingRight = !isFacingRight;
    }

    void OnSneak(InputValue inputValue)
    {
        float isSneaking = inputValue.Get<float>();
        Debug.Log("sneak " + isSneaking); 
    }

    void OnSprint(InputValue inputValue)
    {
        float isSprinting = inputValue.Get<float>();
        Debug.Log("sprint " + isSprinting); 
    }
    
}
