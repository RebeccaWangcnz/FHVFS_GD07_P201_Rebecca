using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSystem : Singleton<ResultSystem>
{

    private void OnEnable()
    {
        Evently.Instance.Subscribe<ResultEvent>(Result);
    }
    private void OnDisable()
    {
        Evently.Instance.Unsubscribe<ResultEvent>(Result);
    }
    private void Result(ResultEvent evt)
    {
        if (evt.winOrLose)
            Debug.Log("You win!");
        else
            Debug.Log("You lose!");
        SceneManager.LoadScene("Level");
    }
}
