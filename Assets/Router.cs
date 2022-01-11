using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Router : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(OpenGameScene());
    }

    private IEnumerator OpenGameScene()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Game");
    }
}
