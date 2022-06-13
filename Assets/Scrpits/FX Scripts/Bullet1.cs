using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    [HideInInspector]
    public int speed;
    GameObject Explosion;
    private Rigidbody2D rb2D;
    private SpriteRenderer sr;
    private Animator animator;

    Player target;
    Vector2 moveDir;
    GameObject ex;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        target = GameObject.FindObjectOfType<Player>();
        moveDir = (target.transform.position - transform.position).normalized*speed;
        rb2D.velocity = new Vector2(moveDir.x,moveDir.y);
        Explosion = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.CompareTag("Player")){ 
            sr.sprite = null;
            Explosion.transform.position = transform.position;
            Explosion.SetActive(true);
            StartCoroutine(destroy());
        }
    }

    IEnumerator destroy(){
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
