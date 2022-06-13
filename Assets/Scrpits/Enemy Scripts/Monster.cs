using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour,Enemy
{
    private float scaleVal;
    private Transform GroundPoint,Player;

    [SerializeField] private int damage;
    [SerializeField] private Transform attackArea;

    [SerializeField] private float attackRangeX,attackRangeY;
    private Vector3 tempScale,tempPos;
    private bool Left, attacking = false;

    [SerializeField]
    private LayerMask groundLayer, playerLayer;

    [SerializeField] float speed = 1f;
    private RaycastHit2D groundHit;
    private Rigidbody2D mybody;
    private SpriteRenderer sr;
    private Animator animator;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        Left = Random.Range(0,2) > 0 ? true : false;
        GroundPoint = transform.GetChild(1);
        scaleVal = transform.localScale.x;
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindObjectOfType<Player>().transform;
        if(Player != null) StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        Enemy.Moving(transform,Left,scaleVal,speed);
        checkGround();
    }
    void checkGround(){
        groundHit = Physics2D.Raycast(GroundPoint.position,Vector2.down,0.1f,groundLayer);
        if(!groundHit)
            Left = !Left;
    }

    IEnumerator Attack(){
        while(true){
            yield return new WaitForSeconds(1f);
            float distance= Vector3.Distance(attackArea.position, Player.position);
            Collider2D hitsEnemy = Physics2D.OverlapBox(
                attackArea.position,new Vector2(attackRangeX, attackRangeY),0,playerLayer);
            if(distance <= 2f && groundHit && hitsEnemy != null){
                animator.SetBool("Attack",true);
                hitsEnemy.GetComponent<Health>().Damage(damage);
            } else animator.SetBool("Attack",false);
        }
        
    }

    private void OnDrawGizmosSelected() {
        if(!attackArea) return;
        Gizmos.DrawWireCube(attackArea.position,new Vector2(attackRangeX, attackRangeY));
    }
    
}
