using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLV : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    [SerializeField] private string Level;
    GameObject Hero;
    float zAngle;
    Vector3 temp = Vector3.zero;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        zAngle = Time.deltaTime*20f;
        temp.z = zAngle;
        transform.Rotate(-temp);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player"){
            UnityEngine.SceneManagement.SceneManager.LoadScene(Level);
        }
    }
}
