using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject tipObject;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 6f;

    public void Shoot(GameObject bulletParent, int shooterN)
    {
        GameObject bullet = Instantiate(bulletPrefab,
                                bulletParent.transform.parent);
        bullet.transform.position = tipObject.transform.position;
        bullet.GetComponent<Bullet>().shooterN = shooterN;

        Vector3 velocity = this.gameObject.transform.rotation * new Vector3(bulletSpeed, 0, 0);
        bullet.GetComponent<Bullet>().velocity = velocity;
    }
}
