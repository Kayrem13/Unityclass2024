using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    //declarations vor any game object, variable etc. that the script will need to interact with later
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
        //upon starting the game, the rigidbody component will be taken and the rotation freezed
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        //every frame the counter goes up by one
        frameCounter = frameCounter + 1;
        
        // Debug.Log("Update..." + frameCounter); 
    }

    private void FixedUpdate()
    {
        //the speed equation is set for the rigidbodies movement via vertors
        rb.velocity = new Vector2(inputDirection * movementspeed, rb.velocity.y);
    }
    

    void OnJump()
    {
        //if the groundcheck is overlapping with objects from the ground layer the following function will be used
        if (Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, layerGroundcheck))
        {
            //this is the equation for the height of the jump plus a counter, that goes up with every jump
            rb.velocity = new Vector2(0f, jumpforce);
            jumpCounter = jumpCounter + 1;
            Debug.Log("jump " + jumpCounter);  
        }
            
        
    }

    void OnMove(InputValue inputValue)
    {
        //first the input direction will be taken using a float
        inputDirection = inputValue.Get<float>();
        Debug.Log("move " + inputDirection);
        
        //if the input direction float is bigger than 0 the character is NOT facing right, it fill get flipped
        if (inputDirection > 0 && !isFacingRight)
        {
            flipp();
        }
        //if the input direction is smaller than zero and the character is facing right, it will get flipped
        else if (inputDirection < 0 && isFacingRight)
        {
            flipp();
        }
    }

    void flipp()
    {
        //upon flipp is used the character will face the other direction
        Vector3 currentScale = transform.localScale;
        currentScale.x = currentScale.x * -1;
        transform.localScale = currentScale;

        //now "is facing right" is declared as NOT facing right anymore
        isFacingRight = !isFacingRight;
    }

    //function to sneak
    void OnSneak(InputValue inputValue)
    {
        //gets the float value upon sneaking
        float isSneaking = inputValue.Get<float>();
        
        //if the character is sneaking, the movement speed is reduced by 3 units
        if (isSneaking == 1)
        {
            movementspeed -= 3f;
        }
        //if the character is no longer sneaking, the speed will be increased by 3 to it's default 
        else if (isSneaking == 0)
        {
            movementspeed += 3f;
        }
        Debug.Log("sneak " + isSneaking); 
    }

    //function to sprint
    void OnSprint(InputValue inputValue)
    {
        //gets the float value upon sprinting
        float isSprinting = inputValue.Get<float>();
        
        //if the character is sprinting, the movement speed is increased by 3 units
        if (isSprinting == 1)
        {
            movementspeed += 3f;
        }
        //if the character is no longer sprinting, the speed will be decreased by 3 units to the default walking speed
        else if (isSprinting == 0)
        {
            movementspeed -= 3f;
        }
        Debug.Log("sprint " + isSprinting); 
    }
    
}
