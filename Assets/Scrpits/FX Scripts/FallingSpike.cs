using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    [SerializeField] GameObject Spike;
    [SerializeField] float speed;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Spike.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-speed);
            Destroy(gameObject);
        }
    }
}
