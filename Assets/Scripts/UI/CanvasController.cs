using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : Singleton<CanvasController>
{
    [SerializeField] private Canvas canvasMenu, canvasInGame, canvasMiniGame, canvasEndGame;
    [SerializeField] private Text textMiniGameCoin;
    [SerializeField] private CoinIndicator coinIndicator;

    private void Start()
    {
        GameManager.Instance.ActionGameStart += SetInGameUI;
        GameManager.Instance.ActionGameOver += SetEndGameUI;
        PlayerController.ReachedEndOfLevel += SetMiniGameUI;
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

    private void SetMiniGameUI()
    {
        canvasInGame.enabled = false;
        StartCoroutine(ActivateMiniGameUI());
    }
    private IEnumerator ActivateMiniGameUI()
    {
        yield return new WaitForSeconds(0.25f);

        canvasMiniGame.enabled = true;
    }

    private void SetEndGameUI()
    {
        canvasMiniGame.enabled = false;
        StartCoroutine(ActivateEndGameUI());
    }
    private IEnumerator ActivateEndGameUI()
    {
        yield return new WaitForSeconds(1f);

        canvasEndGame.enabled = true;
    }

    public void UpdateMiniGamecoinText(int value)
    {
        textMiniGameCoin.text = value.ToString();
    }

    private void OnDestroy()
    {
        GameManager.Instance.ActionGameStart -= SetInGameUI;
        GameManager.Instance.ActionGameOver -= SetEndGameUI;
        PlayerController.ReachedEndOfLevel -= SetMiniGameUI;
    }
}
