using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_04 : MonoBehaviour
{
    [SerializeField]
    private GameObject Boom;
    private GameObject boom;
    private Transform dropSpot;

    // Start is called before the first frame update
    void Start()
    {
        dropSpot = transform.GetChild(0);
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            boom = Instantiate(Boom);
            boom.transform.position = dropSpot.position;
            boom.GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 0);
        }
    }
}
