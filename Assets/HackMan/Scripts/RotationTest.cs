using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(90, 60, 30);

        transform.Rotate(0, 0, 30);       
        transform.Rotate(90, 0, 0);
        transform.Rotate(0, 60, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
