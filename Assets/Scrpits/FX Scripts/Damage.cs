using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int damage = 10;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Health>() != null)
        {
            if(this.gameObject.tag == other.tag) return;
            other.GetComponent<Health>().Damage(damage);
        }
    }
}
