using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy
{
    public static void Moving(Transform transform, bool Left, float scaleVal,float speed){
        Vector3 tempPos = transform.position;
        Vector3 tempScale = transform.localScale;
        if(Left){  
            tempPos.x -= speed*Time.deltaTime;
            tempScale.x = -scaleVal;
        }
        else 
        {
            tempPos.x += speed*Time.deltaTime;
            tempScale.x = scaleVal;
        }      
        transform.position = tempPos;
        transform.localScale = tempScale;
    }

    public void Moving2(Transform transform, float distance,bool Left, float scaleVal,float speed ){
        Vector3 tempPos = transform.position;
        Vector3 tempScale = transform.localScale;
        float minDis = transform.position.x - distance;
        float maxDis = transform.position.x + distance;
        if(Left){
           tempPos.x -= speed*Time.deltaTime;
            tempScale.x = -scaleVal;
        }else 
        {
            tempPos.x += speed*Time.deltaTime;
            tempScale.x = scaleVal;
        }
        if(tempPos.x < minDis)
        {
            Left = false;
        }
        if(tempPos.x > maxDis)
        {
            Left = true;
        }
        transform.position = tempPos;
        transform.localScale = tempScale;

    }
}
