using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Mana : MonoBehaviour
{
    [SerializeField] private int mana = 100;
    private Slider MPbar;
    private int Max_MP = 100;
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.tag == "Player"){
            MPbar = GameObject.Find("MP bar").GetComponent<Slider>();
            MPbar.maxValue = Max_MP;
            MPbar.minValue = 0f;
            MPbar.value = Max_MP;
        }
    }

    private void Update() {
        if(this.gameObject.tag == "Player" && MPbar != null){
            MPbar.value = mana;
        }
    }

    public float GetMana(){
        return mana;
    }

    public void Skill(int amount){
        if(amount < 0){
            Debug.Log("No Negative !");
        }
        
        this.mana -= amount;
        if(this.gameObject.tag == "Player")
            MPbar.value = this.mana;
        if(mana <= 0) Debug.Log("No Mana !");
    }

    public void Gain(int amount){
         if(amount < 0){
            Debug.Log("No Negative !");
        }
        if(mana+amount > Max_MP) this.mana = Max_MP;
        else this.mana += amount;
    }
}
