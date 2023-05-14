// Ailand Parriott
// created: 23.01.17
// This script allows for player movement using the "New Input System"
//
// Resources used:
//  Smooth 2D Movement Using the New Input System (Unity Tutorial | 2D Top Down
//          Shooter)
//      https://www.youtube.com/watch?v=V3NR1n-UhI0
//  MELEE COMBAT in Unity
//      https://www.youtube.com/watch?v=sPiVz1k-fEs


// not sure why, had to attach the ScoreController code to the player as well 
// to make the coin work.

using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // animation init
    public Animator animator;

    // movement init
    public float moveSpeed = 4, smoothVal = .2f;
    public Rigidbody2D rb;

    private Vector2 moveInp, moveInpSmoothVel, smoothMoveInp;

    // attack init
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Transform attackPoint;

    // Health / damage init
    public int attackDamage = 10, health = 100, healthMax = 100;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        //attackPoint = attackObj.transform;
    }

    void Update()
    {
        // if left click, attack
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }
    void FixedUpdate()
    {
        smoothMoveInp = Vector2.SmoothDamp(smoothMoveInp, moveInp, 
                ref moveInpSmoothVel, smoothVal);

        rb.velocity = smoothMoveInp * moveSpeed;

        if(rb.velocity != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

    }

    void OnMove(InputValue inputValue)
    {
        moveInp = inputValue.Get<Vector2>();
    }


// ATTACK CODE
    void Attack()
    {
        // sets animation to slashattack
        //animator.SetTrigger("SlashAttack");

        // draws circle on position of dot
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
                attackPoint.position, attackRange, enemyLayers);

        // detect enemies hit
        foreach(Collider2D enemy in hitEnemies)
        {
            // deal tamage to enemies
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
