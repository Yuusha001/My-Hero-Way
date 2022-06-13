using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBait : MonoBehaviour
{
    [SerializeField]
    private GameObject Lightning;
    // Start is called before the first frame update
    private GameObject spot;
    private void Awake() {
        spot = transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        GameObject boom = Instantiate(Lightning);
        Vector3 temp = transform.position;
        temp.y +=3;
        boom.transform.position = temp;
        spot.SetActive(true);
        StartCoroutine(BOOM(boom));
    }

    IEnumerator BOOM(GameObject boom){
        yield return new WaitForSeconds(0.5f);
        Destroy(boom);
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
