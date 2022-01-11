using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinIndicator : MonoBehaviour
{
    [SerializeField] private Text textCoin;
    [SerializeField] private RawImage imageBackground;
    [SerializeField] private Camera mainCamera;
    private Vector3 newPos;

    private void OnEnable()
    {
        PlayerController.ReachedEndOfLevel += DisableThis;

        textCoin.transform.position = mainCamera.WorldToScreenPoint(this.transform.position);
        imageBackground.transform.position = textCoin.transform.position;
    }

    private void LateUpdate()
    {
        FollowPlayer();
        SetCoinText();
    }

    private void SetCoinText()
    {
        textCoin.text = CoinManager.Instance.CurrentCoin.ToString();
    }

    private void FollowPlayer()
    {
        newPos = mainCamera.WorldToScreenPoint(this.transform.position);
        textCoin.transform.position = new Vector3(
            Mathf.Lerp(textCoin.transform.position.x, newPos.x, 2f),
            textCoin.transform.position.y,
            textCoin.transform.position.z);
        imageBackground.transform.position = textCoin.transform.position;
    }

    private void DisableThis()
    {
        Destroy(textCoin.gameObject);
        Destroy(imageBackground.gameObject);
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        PlayerController.ReachedEndOfLevel -= DisableThis;
    }
}
