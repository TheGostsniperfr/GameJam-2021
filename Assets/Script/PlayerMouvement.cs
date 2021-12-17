using System.Collections;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isGrounded;
    public bool isAttack;

    public Transform groundCheck;
    public float goundCheckRadius;
    public LayerMask collisionLayers;

    //attack system
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;

    public static PlayerMouvement instance;
    private float horizontalMouvement;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;
    }

    

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        

    }

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }



        if(isGrounded == true)
        {
            animator.SetBool("isJump", false);
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("isJump", true);
                isJumping = true;
            }
        }
        


        horizontalMouvement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        Flip(rb.velocity.x);

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, goundCheckRadius, collisionLayers);

        MovePlayer(horizontalMouvement);



    }

    void MovePlayer(float _horizontalMouvement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMouvement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, goundCheckRadius);
    }

    public void addJump(int addJumpForce)
    {
        jumpForce += addJumpForce;
    }
}
