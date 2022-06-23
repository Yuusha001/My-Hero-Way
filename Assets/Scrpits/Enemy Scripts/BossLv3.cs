using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossLv3 : MonoBehaviour
    {
        Health health;
        Vector2 moveDir;
        private Player target;

        private GameObject attack,
            fire,
            tempTarget;

        [SerializeField]
        private GameObject Fire,
            TargetMark;

        [SerializeField]
        private List<GameObject> Bullet;
        private Transform FirePoint,
            FirePoint1;

        // Start is called before the first frame update
        void Start()
        {
            health = GetComponent<Health>();
            target = GameObject.FindObjectOfType<Player>();
            FirePoint = transform.GetChild(0);
            StartCoroutine(Shoot());
            StartCoroutine(DropMissile());
        }

        // Update is called once per frame
        void Update() { }

        IEnumerator Shoot()
        {
            while (true)
            {
                float distance = Vector3.Distance(target.transform.position, transform.position);
                yield return new WaitForSeconds(2f);
                if (distance <= 10f)
                {
                    fire = Instantiate(Fire);
                    fire.transform.position = FirePoint.position;
                    yield return new WaitForSeconds(0.6f);
                    Destroy(fire);
                    attack = Instantiate(Bullet[0]);
                    attack.transform.position = FirePoint.position;
                    attack.GetComponent<ChasingBullet>().speed = 10;
                }
            }
        }

        IEnumerator DropMissile()
        {
            while (true)
            {
                float distance = Vector3.Distance(target.transform.position, transform.position);
                yield return new WaitForSeconds(2f);
                if (distance <= 15f)
                {
                    tempTarget = Instantiate(TargetMark);
                    tempTarget.transform.position = target.transform.position;
                    attack = Instantiate(Bullet[1]);
                    Vector3 temp = target.transform.position;
                    temp.y += 10;
                    Vector3 direction = target.transform.position - temp;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    attack.transform.position = temp;
                    attack.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    attack.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3);
                    yield return new WaitForSeconds(1f);
                    Destroy(tempTarget);
                }
            }
        }
    }
}
