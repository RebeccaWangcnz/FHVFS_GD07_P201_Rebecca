using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionEvent
{
    public CollectableComponent collectable;
    public CollectionEvent(CollectableComponent col)
    {
        collectable = col;
    }
}
