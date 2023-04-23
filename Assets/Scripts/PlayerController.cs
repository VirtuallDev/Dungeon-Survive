using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

enum PlayerStates
{
    Idle,
    Walking
}

public class PlayerController : Singleton
{
    [SerializeField]
    private Transform cameraTransform;


    [SerializeField]
    private float moveSpeed = 5f;


    Rigidbody2D rb;
    Animator animator;

    Vector2 moveDir;

    PlayerStates pState = PlayerStates.Idle;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");


        // Animations
        animator.SetFloat("Horizontal", moveDir.x);
        animator.SetFloat("Vertical", moveDir.y);
        animator.SetFloat("Speed", moveDir.sqrMagnitude);


        UpdateState();
    }

    private void LateUpdate()
    {
        cameraTransform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDir.normalized * moveSpeed;
    }

    void UpdateState()
    {


        if (moveDir.sqrMagnitude > 0)
        {
            pState = PlayerStates.Walking;
        }
        else
        {
            pState = PlayerStates.Idle;
        }

    }
}
