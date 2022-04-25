using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CollectableComponent>()!=null)
        {
            Evently.Instance.Publish(new CollectionEvent(other.GetComponent<CollectableComponent>()));
        }
        else if(other.GetComponent<DamageComponent>()!=null)
        {
            Evently.Instance.Publish(new LosingEvent());
        }
        if (FindObjectsOfType<CollectableComponent>().Length == 0)
        {
            Evently.Instance.Publish(new WinningEvent());
        }
    }
}
