using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorComponent : MonoBehaviour
{
    public int player_maxhp;
    private int player_currenthp;
    private Text HPtext;
    private void Awake()
    {
        Time.timeScale = 1;
        player_currenthp = player_maxhp;
        HPtext = FindObjectOfType<HPTextComponent>().GetComponent<Text>();
        HPtext.text = "HP: " + player_currenthp.ToString();
    }
    private void Update()
    {
        if(player_currenthp<=0)
        { 
            Evently.Instance.Publish(new LosingEvent()); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CollectableComponent>()!=null)
        {
            Evently.Instance.Publish(new CollectionEvent(other.GetComponent<CollectableComponent>()));
        }
        else if(other.GetComponent<DamageComponent>()!=null)
        {
            player_currenthp -= other.GetComponent<DamageComponent>().damage;
            HPtext.text = "HP: " + player_currenthp.ToString();
        }
        if (FindObjectsOfType<CollectableComponent>().Length == 0)
        {
            Evently.Instance.Publish(new WinningEvent());
        }
    }
}
