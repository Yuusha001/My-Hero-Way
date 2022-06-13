using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_08 : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D mybody;
    private SpriteRenderer sr;
    private Animator animator;

    [SerializeField]
    private GameObject Bullet, Fire;
    private GameObject attack, fire;
    private Transform FirePoint;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        FirePoint = transform.GetChild(0);
    }

    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot(){
        fire = Instantiate(Fire);
        fire.transform.position = FirePoint.position;
        yield return new WaitForSeconds(0.6f);
        Destroy(fire);
        attack = Instantiate(Bullet);
        attack.transform.position = FirePoint.position;
        attack.GetComponent<Rigidbody2D>().velocity = new Vector2(10,0);
    }
}
