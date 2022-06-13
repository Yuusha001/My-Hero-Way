using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f, jumpForce = 10f,
    midleDmg = 5, rangeDmg = 10,
    attackRangeX,attackRangeY;

    [SerializeField]
    private GameObject fireball;

    [SerializeField]
    private LayerMask EnemyLayer;
    private GameObject attack;

    [SerializeField]
    private Transform attackArea;
    private float movementX,scaleVal;
    private Rigidbody2D mybody;
    private SpriteRenderer sr;
    private Animator animator;
   
    private Mana MP;
    private string RUN_ANIMATION = "Run";
    private string GROUND_TAG = "Ground";
    private bool isGrounded;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        MP = GetComponent<Mana>();
        scaleVal = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatedPlayer();
        PlayerShoot();
        PlayerPunch();
        animator.SetFloat("yVelocity",mybody.velocity.y);
    }

    private void FixedUpdate() {
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    void PlayerJump(){
        if(Input.GetButton("Jump") && isGrounded){
            isGrounded = false;
            animator.SetBool("Grounded",isGrounded);
            mybody.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
        }
    }

    void PlayerShoot(){
        if(Input.GetMouseButtonDown(0) && (MP.GetMana() > 0)){
            MP.Skill(10);
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot(){
        animator.SetBool(RUN_ANIMATION,false);
        animator.Play("shoot");
        Vector3 temp = attackArea.transform.position;
        if(transform.localScale.x > 0){
            attack = Instantiate(fireball);
            attack.transform.position = temp;
            attack.GetComponent<Rigidbody2D>().velocity =new Vector2(10,0);
        }else{
            attack = Instantiate(fireball);
            attack.transform.position = temp;
            attack.GetComponent<Rigidbody2D>().velocity =new Vector2(-10,0);
            attack.transform.localScale = new Vector3(-2f,2f,1);
        }
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Fire", false);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Fire", true);
    }

    void PlayerPunch(){
        if(Input.GetKeyDown(KeyCode.J)){
            animator.SetTrigger("Punch");
            Collider2D[]hitsEnemy = Physics2D.OverlapBoxAll(
           attackArea.position,new Vector2(attackRangeX, attackRangeY),0,EnemyLayer);
           foreach (Collider2D enemy in hitsEnemy)
           {
               enemy.GetComponent<Health>().Damage(((int)midleDmg));
               MP.Gain(2);
           }
        }
    }

    private void OnDrawGizmosSelected() {
        if(!attackArea) return;

        Gizmos.DrawWireCube(attackArea.position,new Vector2(attackRangeX, attackRangeY));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(GROUND_TAG)){
            isGrounded = true;
            animator.SetBool("Grounded",isGrounded);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Coin")){
            Destroy(other.gameObject);
        }
    }

    void AnimatedPlayer()
    {
        Vector3 tempScale = transform.localScale;
        if (movementX > 0) {
            animator.SetBool(RUN_ANIMATION, true);
            tempScale.x =scaleVal;
        }
        else if (movementX < 0) {
            animator.SetBool(RUN_ANIMATION, true);
            tempScale.x =-scaleVal;
        }
        else { 
            animator.SetBool(RUN_ANIMATION, false);
        }
        transform.localScale = tempScale;
    }

    
}
