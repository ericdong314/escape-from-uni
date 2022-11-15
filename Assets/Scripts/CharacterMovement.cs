using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//author: Leo and Kehan
public class CharacterMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    
    private Vector3 moveDirection;
    private Vector3 verticalVelocity;
    
    [SerializeField] private bool isGrounded;
    //[SerializeField] Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    
    [SerializeField] private float jumpHeight;

    //REFERENCES
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    private void Move()
    {

        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        
        if (isGrounded && verticalVelocity.y < 0)
        {
            verticalVelocity.y = -2f;

        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveX,0,moveZ);

        
        if(isGrounded)
        {  
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }
            moveDirection *= moveSpeed;
            
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
       
        


        controller.Move(moveDirection * Time.deltaTime);

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }
    
    private void Jump()
    {
        verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
    
    private void Idle(){
        
    }
    private void Run()
    {
        moveSpeed = runSpeed;
    }
    private void Walk()
    {
        moveSpeed = walkSpeed;
    }
}
