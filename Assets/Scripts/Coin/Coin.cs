using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] private float turnSpeed = 7f;
    private Vector3 rotation = new Vector3(0, 0, 360);

    void Start()
    {
        transform.DOLocalRotate(rotation, turnSpeed, RotateMode.LocalAxisAdd);
    }
}
