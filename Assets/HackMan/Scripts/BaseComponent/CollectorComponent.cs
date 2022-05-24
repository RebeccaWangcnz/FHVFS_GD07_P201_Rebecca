using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorComponent : MonoBehaviour
{
    public int upgradeNum;
    private int pillNum;
    private Pill[] blankPos;
    private void Awake()
    {
        Time.timeScale = 1;
        pillNum = 0;
        blankPos = FindObjectsOfType<Pill>();
    }
    private void Update()
    {
         if(pillNum>upgradeNum)
        {
            pillNum = 0;
            //publish upgrade event
            Evently.Instance.Publish(new UpgradeEvent(GetComponent<PlayerInputComponent>().targetGridPosition, blankPos));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CollectableComponent>()!=null)
        {
            pillNum++;
            Evently.Instance.Publish(new CollectionEvent(other.GetComponent<CollectableComponent>()));
        }
        else if(other.GetComponent<DamageComponent>()!=null)
        {
            Evently.Instance.Publish(new DamageEvent(other.GetComponent<DamageComponent>().damage));
        }
        if (FindObjectsOfType<CollectableComponent>().Length == 0)
        {
            Evently.Instance.Publish(new WinningEvent());
        }
    }
}
