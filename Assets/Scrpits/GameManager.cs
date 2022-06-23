using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject Player;
    GameObject Hero;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level1")
        {
            Hero = Instantiate(Player);
            Hero.transform.position = new Vector3(-37, 0, 0);
        }
        else if (scene.name == "Level2")
        {
            Hero = Instantiate(Player);
            Hero.transform.position = new Vector3(-4, 2, 0);
        }
        else if (scene.name == "Level3")
        {
            Hero = Instantiate(Player);
            Hero.transform.position = new Vector3(-4, 2, 0);
        }
    }
}
