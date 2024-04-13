using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 14f;
    private float dashingTime = 0.1f;
    private float dashingCooldown = 1f;

    private Animator animator;

    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
    
        Vector2 PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.velocity = PlayerInput * moveSpeed;

        if(PlayerInput.x != 0 || PlayerInput.y != 0)
        {
            SetMovementAnimator(PlayerInput);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
        

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        Vector2 PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.velocity = PlayerInput * dashingPower;
       

        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void SetMovementAnimator(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("xDir", direction.x);
        animator.SetFloat("yDir", direction.y);
        //print(animator.GetFloat("xDir"));
    }
}
