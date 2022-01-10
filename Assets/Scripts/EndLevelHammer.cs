using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndLevelHammer : MonoBehaviour
{
    private Animator anim;
    [SerializeField] AnimationClip hitAnim;
    private bool animationPlays = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject ParentObject = transform.parent.gameObject;
        anim = ParentObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!animationPlays)
            {
                anim.SetBool("TimeToHit", true);
                animationPlays = true;
                StartCoroutine(EndTheHitAnimation(hitAnim.length));
            }

        }
    }

    private void OnEnable()
    {
        EndLevelPig.timeForConfetti += DestroyHammer;
    }

    private void OnDisable()
    {
        EndLevelPig.timeForConfetti -= DestroyHammer;

    }

    private void DestroyHammer()
    {

        Destroy(this.gameObject);
    }

    private IEnumerator EndTheHitAnimation(float fl)
    {

        yield return new WaitForSeconds(fl);
        anim.SetBool("TimeToHit",false);
        animationPlays = false;
    }
}
