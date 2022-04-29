using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultSystem : Singleton<ResultSystem>
{
    [SerializeField]
    private Text resultText;
    [SerializeField]
    private GameObject resultUI;
    private void OnEnable()
    {
        resultUI.SetActive(false);
        Evently.Instance.Subscribe<ResultEvent>(Result);
    }
    private void OnDisable()
    {
        Evently.Instance.Unsubscribe<ResultEvent>(Result);
    }
    private void Result(ResultEvent evt)
    {
        if (evt.winOrLose)
        {
            resultText.text = "You Win!!!";
        }
        else
        {
            resultText.text = "You Lose...";
        }
        Time.timeScale = 0;
        resultUI.SetActive(true);
    }

}
