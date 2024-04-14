using UnityEngine;

public class TackShooter : MonoBehaviour
{
    public GameObject tackPrefab;
    public Transform firePoint;
    public float shootInterval = 1f;
    public float tackSpeed = 2f;
    public LayerMask targetLayer;
    public float detectionRange = 3f;

    public float minDamage;
    public float maxDamage;

    private float shootTimer = 0f;

    [SerializeField] Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Update the shoot timer
        shootTimer += Time.deltaTime;

        // Check if it's time to shoot
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    private void Shoot()
    {
        // Detect targets within the detection range
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, detectionRange, targetLayer);

        // Instantiate and shoot tacks towards each target
        foreach (Collider2D target in targets)
        {
            animator.SetFloat("isShooting", 1f);
            GameObject tack = Instantiate(tackPrefab, firePoint.position, Quaternion.identity);
            Vector2 direction = (target.transform.position - firePoint.position).normalized;
            tack.GetComponent<Rigidbody2D>().velocity = direction * tackSpeed;
            tack.GetComponent<testprojectile>().damage = Random.Range(minDamage, maxDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a gizmo to visualize the detection range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
