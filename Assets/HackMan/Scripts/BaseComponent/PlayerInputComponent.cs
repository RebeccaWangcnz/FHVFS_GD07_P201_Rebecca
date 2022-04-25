using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputComponent : MovementComponent
{
   // public bool canCollect;//turning this on and off and it becomes a state nightmiare
    protected override void Update()
    {
        //Debug.Log("overriding method")
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentInputDirecion = IntVector2.down;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentInputDirecion =IntVector2.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentInputDirecion =IntVector2.right;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentInputDirecion =IntVector2.up;
        }

       // Debug.Log($"x:{currentInputDirecion.x}|y:{currentInputDirecion.y}");
        base.Update();
        //transform.position = progressToTarget * currentInputDirecion;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    //winning/losing
    //    //destroy pill
    //    if(other.GetComponent<Pill>())
    //    {
    //        Destroy(other.gameObject);
    //        if(FindObjectsOfType<Pill>().Length<=1)
    //        {
    //            Debug.Log("You win");
    //            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //        }
    //    }
    //    else if(other.GetComponent<EnemyInputComponent>())
    //    {
    //        Debug.Log("You lose");
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //    }
    //    //all pills are gone+ reload the level
    //    //kill hackman
    //}
}
