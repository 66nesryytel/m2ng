using System.Collections;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 15f;
    private float dashingTime = 0.25f;
    private float dashingCooldown = 0.5f;
    public bool kasJooksisParemale;

    public ParticleSystem dust;

    [SerializeField] private TrailRenderer tr;

    audio audioManager;

    private Animator animator;

    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioManager = GameObject.Find("helivanem").GetComponent<audio>();
    }

    public void AddSpeed(float a)
    {
        moveSpeed += a;
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

        if((PlayerInput.x != 0 || PlayerInput.y != 0) && isDashing == false) //kui m�ngija liigub
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
            
            else if (PlayerInput.x == 0) //kui ei liigu vasemale ega paremale
            {
                if (kasJooksisParemale)
                {
                    animator.SetFloat("xDir", 1f);
                }

                else animator.SetFloat("xDir", -1f);
            }
            
        }
        else { animator.SetFloat("xDir", 2); }


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
        CreateDust();
        audioManager.PlaySFX(audioManager.sfx1);
        if (kasJooksisParemale)
        {
            animator.SetFloat("xDir", 3); //animatsioonis
        }
        else animator.SetFloat("xDir", 4); //animatsioonis

        Vector2 PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.velocity = PlayerInput * dashingPower;
       // tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        //tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    void CreateDust()
    {
        dust.Play();
    }
}
