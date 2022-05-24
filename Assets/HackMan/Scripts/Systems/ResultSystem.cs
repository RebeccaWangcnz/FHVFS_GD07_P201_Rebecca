using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultSystem : Singleton<ResultSystem>
{
    private Text resultText;
    private Text HPtext;
    private GameObject resultUI;
    public int player_maxhp;
    private int player_currenthp;
    private GameObject player;
    private void OnEnable()
    {
        Instantiate();
        Evently.Instance.Subscribe<ResultEvent>(Result);
        Evently.Instance.Subscribe<DamageEvent>(CauseDamage);
    }
    private void OnDisable()
    {
        Evently.Instance.Unsubscribe<ResultEvent>(Result);
        Evently.Instance.Unsubscribe<DamageEvent>(CauseDamage);
    }
    private void Update()
    {
        if (player_currenthp <= 0)
        {
            Evently.Instance.Publish(new LosingEvent());
        }
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
    private void CauseDamage(DamageEvent evt)
    {
        player_currenthp -= evt.Damage;

        //var player = FindObjectOfType<PlayerInputComponent>();
        //player.currentInputDirecion = IntVector2.zero;
        //player.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        //Invoke("Recover", 0.3f);
        HPtext.text = "HP: " + player_currenthp.ToString();
    }
    public void Instantiate()
    {
        resultText = FindObjectOfType<ResultTextComponent>().GetComponent<Text>();
        resultUI = resultText.transform.parent.gameObject;
        resultUI.SetActive(false);

        player_currenthp = player_maxhp;
        HPtext = FindObjectOfType<HPTextComponent>().GetComponent<Text>();
        HPtext.text = "HP: " + player_currenthp.ToString();

    }
    private void Recover()
    {
        var player = FindObjectOfType<PlayerInputComponent>();
        player.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

}
