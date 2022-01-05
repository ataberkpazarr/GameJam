using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private static CoinManager _instance;
    public static CoinManager Instance => _instance ?? (_instance = FindObjectOfType<CoinManager>());

    private int currentCoin;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        currentCoin = 0;
    }

    //platformdan toplanan
    public void CollectCoin()
    {
        currentCoin++;
    }

    //şans oyunlarından sonra kazanılan coin
    public void AddCoin(int amount)
    {
        currentCoin += amount;
    }

    //kaybedilen coin
    public void RemoveCoin(int amount)
    {
        currentCoin -= amount;
    }
}
