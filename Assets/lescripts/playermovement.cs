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
    private float dashingCooldown = 0.5f;
    public bool kasJooksisParemale;

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

        if((PlayerInput.x != 0 || PlayerInput.y != 0) && isDashing == false) //kui mängija liigub
        {
            if(PlayerInput.x < 0) //vasakule
            {
                animator.SetFloat("xDir", -1f);
                kasJooksisParemale = false;
            }
            else if (PlayerInput.x > 0) //paremale
            {
                animator.SetFloat("xDir", 1f);
                kasJooksisParemale = true;
            }
            
            else if (PlayerInput.x == 0)
            {
                if (kasJooksisParemale)
                {
                    animator.SetFloat("xDir", 1f);
                }

                else animator.SetFloat("xDir", -1f);
            }
            
        }
        else if (isDashing)
        {
            animator.SetFloat("xDir", 2);
        }
        else { animator.SetFloat("xDir", 3); }


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
}
