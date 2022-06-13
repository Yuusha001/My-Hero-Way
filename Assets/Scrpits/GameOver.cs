using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Canvas gameover;
    [SerializeField] private Button tryAgain;
     // Start is called before the first frame update
    void Start()
    {
        Health.PlayerDead +=EnableCanvas;
        gameover.enabled = false;
        tryAgain.enabled = false;
    }

    private void OnDestroy() {
        Health.PlayerDead -= EnableCanvas;
    }

    private void EnableCanvas(){
        gameover.enabled = true;
        tryAgain.enabled = true;
    }

    public void TryAgain(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        gameover.enabled = false;
        tryAgain.enabled = false;
    }
    
}
