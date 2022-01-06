using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamble : MonoBehaviour
{
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
    private bool _activated = false;
    public bool Activated { get => _activated; set => _activated = value; }


    //bet miktarı vs. burada tanımlanabilir
}
