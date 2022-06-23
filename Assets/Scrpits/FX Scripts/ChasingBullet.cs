using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingBullet : MonoBehaviour
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
        moveDir = (target.transform.position - transform.position).normalized * speed;
        Vector3 direction = transform.position - target.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb2D.velocity = new Vector2(moveDir.x, moveDir.y);
        Explosion = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sr.sprite = null;
            Explosion.transform.position = transform.position;
            Explosion.SetActive(true);
            Invoke("destroy", 0.2f);
        }
        else
            return;
    }

    void destroy()
    {
        Destroy(gameObject);
    }
}
