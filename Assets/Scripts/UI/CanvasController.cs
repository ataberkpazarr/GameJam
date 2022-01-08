using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Canvas canvasMenu, canvasInGame, canvasEndGame;


    private void Start()
    {
        GameManager.Instance.ActionGameStart += SetInGameUI;
        GameManager.Instance.ActionGameOver += SetEndGameUI;
    }

    private void SetInGameUI()
    {
        canvasMenu.enabled = false;
        canvasInGame.enabled = true;
    }

    private void SetEndGameUI()
    {
        canvasInGame.enabled = false;
        canvasEndGame.enabled = true;
    }

    private void OnDestroy()
    {
        GameManager.Instance.ActionGameStart -= SetInGameUI;
        GameManager.Instance.ActionGameOver -= SetEndGameUI;
    }
}
