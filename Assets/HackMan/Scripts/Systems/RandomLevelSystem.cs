using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelSystem : Singleton<RandomLevelSystem>
{
    public int previousLevelIndex;
    public bool needRandom = true;
}
