using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform pig;
    //specs
    [SerializeField] [Range(0f, 10f)] private float speed = 5f, horizontalSpeed = 1f;
    //inputs
    private Vector2 mouseDrag, mousePrePos;
    //states (yenileri eklenebilir delegate şeklinde kodladım (değiştirilebilir))
    private State currentState;
    private State runState;

    void Start()
    {
        runState = new State(Move, () => { }, () => { });
        SetState(runState);
    }

    void Update()
    {
        runState.onUpdate();
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
    }
}
