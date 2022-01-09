using System.Collections;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject canvasMenu, canvasInGame, canvasEndGame;


    private void Start()
    {
        GameManager.Instance.ActionGameStart += SetInGameUI;
        GameManager.Instance.ActionGameOver += SetEndGameUI;
    }

    private void SetInGameUI()
    {
        canvasMenu.SetActive(false);
        StartCoroutine(ActivateInGameUI());
    }

    private IEnumerator ActivateInGameUI()//kamera geçişindeki blend işlemini bekliyoruz
    {
        yield return new WaitForSeconds(0.75f);

        canvasInGame.SetActive(true);
    }

    private void SetEndGameUI()
    {
        canvasInGame.SetActive(false);
        canvasEndGame.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.Instance.ActionGameStart -= SetInGameUI;
        GameManager.Instance.ActionGameOver -= SetEndGameUI;
    }
}
