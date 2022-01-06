using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] [Range(100f, 1000f)] private float turnSpeed = 10f;

    void FixedUpdate()
    {
        //transform.DOLocalRotate(rotation, turnSpeed, RotateMode.LocalAxisAdd);
        transform.Rotate(Vector3.forward, turnSpeed * Time.fixedDeltaTime);
    }
}
