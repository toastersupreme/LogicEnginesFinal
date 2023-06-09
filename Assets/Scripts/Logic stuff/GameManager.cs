using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UnityEvent PlayerCaught = new UnityEvent(), PlayerWon = new UnityEvent(), PlayerSpotted = new UnityEvent();


    public List<Transform> Swarmers = new List<Transform>();
    public GameObject WinUIParent;
    public TMPro.TextMeshProUGUI livesTextbox;
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
        livesTextbox.text = "Lives " + PlayerInfo.Instance.playerLives;
        currentScene = scene;
    }
    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
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
        PlayerInfo.Instance.decreaseLives();       
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
