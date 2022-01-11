using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance ?? (_instance = FindObjectOfType<GameManager>());

    public UnityAction ActionGameStart, ActionGameOver;//core actions

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    //UI Button's method
    public void StartTheGame()
    {
        ActionGameStart?.Invoke();
    }

    //UI Button's method
    public void RestartLevel()
    {
        //gerekirse?
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {

    }
}
