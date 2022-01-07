using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private static CoinManager _instance;
    public static CoinManager Instance => _instance ?? (_instance = FindObjectOfType<CoinManager>());

    private int _currentCoin = 0;
    public int CurrentCoin => _currentCoin;

    [SerializeField] private PlayerController playerController;//action la olabilir?

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    //şans oyunlarından sonra kazanılan coin
    public void AddCoin(int amount)
    {
        if (amount == 0)// kazanılan para yoksa
            return;

        _currentCoin += amount;
        playerController.ScaleByAmount(amount);
    }
}
