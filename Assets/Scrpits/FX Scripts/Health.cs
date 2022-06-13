using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private Slider HPbar;
    public static Action PlayerDead, EnemyDead;
    private int Max_Health = 100;
     
    void Start()
    {
        if(this.gameObject.tag == "Player"){
            HPbar = GameObject.Find("HP bar").GetComponent<Slider>();
            HPbar.maxValue = Max_Health;
            HPbar.minValue = 0f;
            HPbar.value = Max_Health;
        }
    }

    private void Update() {
        if(this.gameObject.tag == "Player" && HPbar !=null){
            HPbar.value = health;
        }
        if(health <= 0) Die();
    }

    public void Damage(int amount){
        if(amount < 0){
            Debug.Log("No Negative Damage !");
        }
        StartCoroutine(VisualIndicactor(Color.red));
        this.health -= amount;
        if(this.gameObject.tag == "Player"){
            HPbar.value = this.health;
        }   
        if(health <= 0) Die();
    }

    public void Heal(int amount){
         if(amount < 0){
            Debug.Log("No Negative Healing !");
        }
        if(health+amount > Max_Health) this.health = Max_Health;
        else this.health += amount;
    }

    public void Die(){
        Debug.Log("I am Dead !");   
        if(this.CompareTag("Player")){
            Time.timeScale = 0;
            PlayerDead?.Invoke();
            Destroy(gameObject);
        }else {
            StartCoroutine(DieAnimation());
        }
    }

    public float GetHealth(){
        return health;
    }

    private IEnumerator VisualIndicactor(Color color){
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private IEnumerator DieAnimation(){
        this.gameObject.GetComponent<Animator>().SetTrigger("Die");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
