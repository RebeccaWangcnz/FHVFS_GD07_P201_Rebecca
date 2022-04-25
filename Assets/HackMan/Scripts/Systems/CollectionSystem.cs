using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionSystem : Singleton<CollectionSystem>
{
    private void OnEnable()
    {
        Evently.Instance.Subscribe<CollectionEvent>(OnCollected);
    }
    private void OnDisable()
    {
        Evently.Instance.Unsubscribe<CollectionEvent>(OnCollected);
    }

    private void OnCollected(CollectionEvent evt)
    {
        Destroy(evt.collectable.gameObject);
    }
}
