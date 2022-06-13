using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    [HideInInspector]
    public int speed;
    GameObject Explosion;
    private Rigidbody2D rb2D;
    private SpriteRenderer sr;
    private Animator animator;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            animator.SetTrigger("Boom");
            StartCoroutine(destroy());
        }else return;
    }

    IEnumerator destroy(){
        
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
