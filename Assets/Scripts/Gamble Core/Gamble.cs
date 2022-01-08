using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamble : MonoBehaviour
{
    [SerializeField] private int _gainRatio = 2;
    public int GainRatio => _gainRatio;

    //KULLANILMIYOR
    private string _playerChoice = "";
    public string PlayerChoice// player ın geçtiği gate in ismi
    {
        get
        {
            if(_playerChoice == null)
            {
                _playerChoice = transform.GetChild(0).name;//ilk seçenek
            }
            return _playerChoice;
        }
        set
        {
            _playerChoice = value;
        }
    }
    
    // player gate lere tam ortadan girerse karşısına çıkan oyundan 2 adet spawn lamasını önlemek için
    //yeni bet sisteminde gerek yok?
    private bool _activated = false;
    public bool Activated { get => _activated; set => _activated = value; }


    //bet işlemleri
    private int betFirst = 0, betSecond = 0;
    public int BetFirst => betFirst;
    public int BetSecond => betSecond;

    public void Bet(string choice)
    {
        CoinManager.Instance.AddCoin(-10);//her bet işleminde domuzdan bir altın eksilecek

        if(choice == "First")
        {
            betFirst+=10;
        }
        else if(choice == "Second")
        {
            betSecond+=10;
        }
        print(betFirst + "  " + betSecond);

        
    }
}
