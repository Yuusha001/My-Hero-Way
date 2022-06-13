using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{

    [SerializeField] private int healPoint;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Health>() != null)
        {
            if(this.gameObject.tag == other.tag) return;
            other.GetComponent<Health>().Heal(healPoint);
        }
        Destroy(gameObject);
    }
}
