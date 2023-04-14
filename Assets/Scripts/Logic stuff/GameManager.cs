using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public UnityEvent PlayerCaught = new UnityEvent(), PlayerWon = new UnityEvent(), PlayerSpotted = new UnityEvent();

    

    public List<Transform> Swarmers = new List<Transform>();
    public GameObject WinUIParent;
    private Scene currentScene;
    public void Start()
    {
        
        PlayerCaught.AddListener(this.LoseGame);
        PlayerWon.AddListener(this.WinGame);
    }
    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        currentScene = scene;
    }
    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Destroy(this.gameObject);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(currentScene.name);
    }
    public void WinGame()
    {
        SceneManager.LoadScene(currentScene.buildIndex + 1);
        //WinUIParent.SetActive(true);
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject e in enemies)
        {
            e.TryGetComponent<NavMeshAgent>(out var navMesh);
            if (navMesh)
                navMesh.isStopped = true;
        }

    }
    public void LoseGame()
    {
        SceneManager.LoadScene(currentScene.name);
    }
    public void openScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void CloseGame()
    {
        Application.Quit();
    }

    

}
