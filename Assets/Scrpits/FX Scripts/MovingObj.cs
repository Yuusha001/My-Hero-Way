using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour
{
    [SerializeField] private Transform point1,point2;
    [SerializeField] private float moveSpeed = 2;

    private Transform targetPos;
    private bool firstMov;
    // Start is called before the first frame update
    private void Awake() {
        if(Random.Range(0,2) > 0){
            firstMov = false;
            targetPos = point2;
        }else{
            firstMov = true;
            targetPos = point1;
        }
    }

    private void Update() {
        HandleMov();
    }

    private void HandleMov(){
        transform.position = Vector3.MoveTowards(transform.position,targetPos.position,moveSpeed*Time.deltaTime);
        if(Vector3.Distance(transform.position,targetPos.position) < 0.1){
            if(firstMov){
                firstMov = false;
                targetPos = point2;
            }else{
                firstMov = true;
                targetPos = point1;
            }
        }
    }
}
