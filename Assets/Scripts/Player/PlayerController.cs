using UnityEngine;
using DG.Tweening;
using System;
using System.Collections;

[SelectionBase]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform pig;
    [SerializeField] private GameObject diceThrowArea;
    [SerializeField] private GameObject goldLoseParticleSystem;
    [SerializeField] private GameObject goldCollectParticleSystem;



    //specs
    [SerializeField] [Range(0f, 10f)] private float speed = 5f, horizontalSpeed = 1f;
    //inputs
    private Vector2 mouseDrag, mousePrePos;
    //states (yenileri eklenebilir delegate şeklinde kodladım (değiştirilebilir))
    private State currentState;
    private State runState;
    private State idleState;

    private bool animationPlaying = false; // state e donusturebiliriz

    //scaling
    [Header("Scaling")]
    private float scalingEndValue = 1.05f;
    [SerializeField] private float scalingDelta = 0.05f;
    [SerializeField] private float scalingDuration = 0.5f;

    void Start()
    {
        GameManager.Instance.ActionGameStart += ActivateThePlayer;

        runState = new State(Move, () => { }, () => { });
        idleState = new State(Idle, () => { }, () => { });
        SetState(idleState);//başta idle
    }

    void Update()
    {
        //runState.onUpdate(); // asagıdaki gibi yaptım burayı
        currentState.onUpdate();
    }

    private void ActivateThePlayer()
    {
        SetState(runState);
    }

    private void SetState(State newState)
    {
        if (currentState != null)
            currentState.onStateExit();

        currentState = newState;
        currentState.onStateEnter();
    }

    private void Move()
    {
        //eski hali aşağıdaki gibiydi
        /*
         
          transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

        if (Input.GetMouseButtonDown(0))
            mousePrePos = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            mouseDrag = (Vector2)Input.mousePosition - mousePrePos;
            mousePrePos = Input.mousePosition;

            var newPigPos = pig.localPosition;
            newPigPos.x = Mathf.Clamp(newPigPos.x + mouseDrag.x * horizontalSpeed * Time.deltaTime, -2f, 2f);
            pig.localPosition = newPigPos;
        }
        else
            mouseDrag = Vector2.zero;
         
         */

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMoveZ(transform.position.z + 2, 1.2f));

        if (Input.GetMouseButtonDown(0))
            mousePrePos = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            mouseDrag = (Vector2)Input.mousePosition - mousePrePos;
            mousePrePos = Input.mousePosition;

            var newPigPos = pig.localPosition;
            float newX = Mathf.Clamp(newPigPos.x + mouseDrag.x, -2.25f, 2.25f);

            mySequence.Join(pig.transform.DOMoveX(newX, 0.35f));

        }
        else
            mouseDrag = Vector2.zero;

        mySequence.Play();
    }

    private void Idle()
    {

    }

    private void OnEnable()
    {
        GambleManager.gambleAnimationHappening += handleAnimation;
    }
    private void OnDisable()
    {
        GambleManager.gambleAnimationHappening -= handleAnimation;
    }

    private void handleAnimation(float f)
    {
        StartCoroutine(GoIdleState(f));
    }
    private IEnumerator GoIdleState(float f)
    {
        yield return new WaitForSeconds(1f); // domuzun zar atılan alana yaklasması icin bekle
        State previousState = currentState; // onceki statei al 
        SetState(idleState); // idle state e gec ve animasyonu izle

        yield return new WaitForSeconds(f); //animasyonu bekle
        SetState(previousState); //onceki state e geri dön
    }

    #region Scaling
    public void ScaleByAmount(int amount)
    {
        float losedScale = amount * scalingDelta;//kaybedilen coin miktarı kadar küçülecek
        scalingEndValue += losedScale;//geriye kalan scale
        pig.DOScale(scalingEndValue, scalingDuration);
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            CoinManager.Instance.AddCoin(10);
            GameObject particleObject = transform.GetChild(0).transform.GetChild(3).gameObject;
            ParticleSystem p = particleObject.GetComponent<ParticleSystem>();
            float timeOfOneParticleRound = p.main.duration;
            particleObject.SetActive(true);
            p.Play();
            //StartCoroutine(EndParticleAnimation(particleObject,timeOfOneParticleRound));
            

            //Instantiate(goldCollectParticleSystem, transform.GetChild(0).transform.position + new Vector3(0, 1, 4), Quaternion.identity);

        }
        else if (other.CompareTag("obstacle") && CoinManager.Instance.CurrentCoin > 0)
        {
            Instantiate(goldLoseParticleSystem,transform.position,Quaternion.identity);
            //parada da azalma lazım su an o yok
            CoinManager.Instance.AddCoin(-10);
        }
    }

    private IEnumerator EndParticleAnimation(GameObject g,float duration)
    {
        yield return new WaitForSeconds(duration-2.7f);
        g.SetActive(false);

    }

    private void OnDestroy()
    {
        GameManager.Instance.ActionGameStart -= ActivateThePlayer;
    }
}