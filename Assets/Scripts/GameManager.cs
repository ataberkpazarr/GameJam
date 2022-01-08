using UnityEngine;
using UnityEngine.Events;

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
    //tek ekran oynanış için
    public void StartGame()
    {
        ActionGameStart?.Invoke();
    }

    public void RestartLevel()
    {
        //gerekirse?
    }

    public void LoadNextLevel()
    {

    }
}
