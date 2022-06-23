using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_02 : MonoBehaviour, Enemy
{
    private Rigidbody2D mybody;
    private SpriteRenderer sr;
    private Animator animator;

    [SerializeField]
    private GameObject Bullet,
        Fire;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    float speed = 2;
    private RaycastHit2D groundHit;
    private GameObject attack,
        fire;
    Player target;
    private bool Left;
    private Transform FirePoint,
        GroundPoint;
    private float scaleVal;
    private Vector3 tempScale,
        tempPos;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        Left = Random.Range(0, 2) > 0 ? true : false;
        FirePoint = transform.GetChild(0);
        GroundPoint = transform.GetChild(1);
        scaleVal = transform.localScale.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        Enemy.Moving(transform, Left, scaleVal, speed);
        checkGround();
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            target = GameObject.FindObjectOfType<Player>();
            float distance = Vector3.Distance(target.transform.position, transform.position);
            yield return new WaitForSeconds(2f);
            if (distance <= 10f)
            {
                fire = Instantiate(Fire);
                fire.transform.position = FirePoint.position;
                yield return new WaitForSeconds(0.6f);
                Destroy(fire);
                attack = Instantiate(Bullet);
                attack.transform.position = FirePoint.position;
                attack.GetComponent<ChasingBullet>().speed = 10;
            }
        }
    }

    void checkGround()
    {
        groundHit = Physics2D.Raycast(GroundPoint.position, Vector2.down, 0.1f, groundLayer);
        if (!groundHit)
            Left = !Left;
    }
}
