using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public GameObject bullet;
    private void OnEnable()
    {
        Evently.Instance.Subscribe<ShootingEvent>(Shooting);
    }
    private void OnDisable()
    {
        Evently.Instance.Unsubscribe<ShootingEvent>(Shooting);
    }
    private void Shooting(ShootingEvent evt)
    {
        var newBullet=Instantiate(bullet);
        newBullet.transform.position = evt.instantiatePos.ToVector3();
        newBullet.GetComponent<BulletComponent>().GridPos = evt.instantiatePos;
        newBullet.GetComponent<BulletComponent>().direction = evt.direction;
    }
}
