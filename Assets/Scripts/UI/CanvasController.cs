using System.Collections;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Canvas canvasMenu, canvasInGame, canvasEndGame;
    [SerializeField] private CoinIndicator coinIndicator;


    private void Start()
    {
        GameManager.Instance.ActionGameStart += SetInGameUI;
        GameManager.Instance.ActionGameOver += SetEndGameUI;
    }

    private void SetInGameUI()
    {
        canvasMenu.enabled = false;
        StartCoroutine(ActivateInGameUI());
    }

    private IEnumerator ActivateInGameUI()//kamera geçişindeki blend işlemini bekliyoruz
    {
        yield return new WaitForSeconds(0.8f);

        canvasInGame.enabled = true;
        coinIndicator.enabled = true;
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
