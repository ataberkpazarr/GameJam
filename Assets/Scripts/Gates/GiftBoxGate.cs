using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftBoxGate : Gamble
{
    [SerializeField] private Gamble gamble;

    [SerializeField] private GameObject boxRoot, boxWithCover, boxEmpty;
    [SerializeField] private GameObject otherBoxRoot;//işlemden sonra sadece kutuları yok etmek için
    [SerializeField] private int giftCoinAmount = 10;

    public static Action<int, GameObject, GameObject> timeToOpenGiftBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gamble.Activated)
        {
            gamble.Activated = true;

            boxWithCover.SetActive(false);
            boxEmpty.SetActive(true);

            if (boxRoot.name == "Coin")
                timeToOpenGiftBox.Invoke(giftCoinAmount, boxRoot, otherBoxRoot);
            else if (boxRoot.name == "Candy")
                timeToOpenGiftBox.Invoke(0, boxRoot, otherBoxRoot);// no gifts
        }
    }
}
