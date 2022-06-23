using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Vector3 hpBar;
    float value,
        temp;

    // Start is called before the first frame update
    void Start()
    {
        hpBar = transform.localScale;
        temp = GetComponentInParent<Health>().GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        value = GetComponentInParent<Health>().GetHealth();
        if (value <= temp * 7 / 10 && value > temp * 3 / 10)
            transform.GetComponent<SpriteRenderer>().color = Color.yellow;
        else if (value <= temp * 3 / 10)
            transform.GetComponent<SpriteRenderer>().color = Color.red;
        hpBar.x = value / 100;
        transform.localScale = hpBar;
    }
}
