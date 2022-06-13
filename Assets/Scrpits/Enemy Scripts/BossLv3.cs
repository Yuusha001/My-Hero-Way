using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLv3 : MonoBehaviour
{
    Health health;
    private Slider HPbar;
    private Player target;

    private GameObject attack,fire;
    [SerializeField] private GameObject Bullet, Fire;
    private Transform FirePoint, FirePoint1;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        target = GameObject.FindObjectOfType<Player>();
        HPbar = GameObject.Find("BossBar").GetComponent<Slider>();
        FirePoint = transform.GetChild(0);
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        HPbar.value = health.GetHealth();
    }

    IEnumerator Attack(){
        while(true){
            float distance = Vector3.Distance (target.transform.position, transform.position);
            if(health.GetHealth() > 400){
                yield return new WaitForSeconds(1);
                if(distance > 5){
                    fire = Instantiate(Fire);
                    fire.transform.position = FirePoint.position;
                    yield return new WaitForSeconds(0.6f);
                    Destroy(fire);
                    attack = Instantiate(Bullet);
                    attack.transform.position = FirePoint.position;
                    attack.GetComponent<Bullet1>().speed = 10;
                }
            }
        }
    }
}
