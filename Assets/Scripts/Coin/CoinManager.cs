using UnityEngine;

public class CoinManager : Singleton<CoinManager>
{
    //private static CoinManager _instance;
    //public static CoinManager Instance => _instance ?? (_instance = FindObjectOfType<CoinManager>());

    private int _currentCoin = 0;
    public int CurrentCoin => _currentCoin;

    [SerializeField] private PlayerController playerController;//action la olabilir?, + bence de olur

    /*// singleton ı burda yapmıssın, diger managerlarda da kullanırız diye parent class ı yaptım bunun
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }*/

    

    //şans oyunlarından sonra kazanılan coin
    public void AddCoin(int amount)
    {
        if (amount == 0)// kazanılan para yoksa
            return;

        if (amount < 0 && Mathf.Abs(amount) > _currentCoin)// eğer kaybedilen para var olandan yüksek ise
        {
            _currentCoin = 0;
            return;
        }
            
        _currentCoin += amount;
        playerController.ScaleByAmount(amount);
    }

  

    

}
