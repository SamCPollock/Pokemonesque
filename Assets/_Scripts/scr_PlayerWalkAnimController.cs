using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum CardinalDirection
{
    North = 0,
    East = 1,
    South = 2,
    West = 3
}

public class scr_PlayerWalkAnimController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private CardinalDirection facing = CardinalDirection.South;

    private Rigidbody2D rb;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector2 velocity = new Vector2(inputX, inputY);
        //Vector2 velocity = rb.velocity;

        bool isWalking = velocity.sqrMagnitude > float.Epsilon;
        bool isMovingMoreHorizontally = Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y);    //Check if moving more horizontally than vertically. 

        if (isMovingMoreHorizontally)
        {
            if (velocity.x > 0)
            {
                facing = CardinalDirection.East;
            }
            else
            {
                facing = CardinalDirection.West;
            }
        }
        else
        {
            if (velocity.y > 0)
            {
                facing = CardinalDirection.North;
            }
            else
            {
                facing = CardinalDirection.South;
            }
        }

        animator.SetBool("isMoving", isWalking);
        animator.SetInteger("moveDirection", (int)facing);
    }
}
