using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]
public class CharcterController2d : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 2f;
   // Vector2 motionVector;
    Animator animator;
    void Awake()
    {
      
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction and normalize it
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
        rb.velocity = movement * moveSpeed;

        if (moveHorizontal == 0  )
        {
            animator.SetBool("Iswalking", false);
        }
        else
        {

            animator.SetBool("Iswalking", true);
        }
        if (moveVertical == 0 )
        {
            animator.SetBool("Iswalking", false);
        }
        else
        {

            animator.SetBool("Iswalking", true);
        }

    }
   

}
