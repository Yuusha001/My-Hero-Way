using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI Text;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    public void Change(int coinValue){
        score += coinValue;
        Text.text = "X" + score.ToString();
    }
    
}
