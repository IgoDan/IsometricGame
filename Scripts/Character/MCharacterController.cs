using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCharacterController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]private float speed = 3.0f;

    [HideInInspector] public bool canMove;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;

    }
    void FixedUpdate()
    {
        
        Vector2 currentPos = rb.position;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontal, vertical/2);
        //Debug.Log("przed: " + inputVector.magnitude);
        inputVector = Vector2.ClampMagnitude(inputVector*2, 1);
        //Debug.Log("po: " + inputVector.magnitude);
        Vector2 movment = inputVector * speed;
        Vector2 newPos = currentPos + movment * Time.fixedDeltaTime;
        if(canMove)
            rb.MovePosition(newPos);
        if (horizontal == 0 && vertical == 0)
            rb.velocity = new Vector2(0,0);
        

        FindObjectOfType<PlayerAnimation>().SetDirection(new Vector2(horizontal, vertical));



    }

    


}
