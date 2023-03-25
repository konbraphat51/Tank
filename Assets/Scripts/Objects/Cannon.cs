using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Turning")]

    [SerializeField] private float turnSpeed = 1f;
   
    [Tooltip("Cannon Turns around from here")]
    [SerializeField] private Transform cannonCenterObject;

    [Header("Shooting")]

    [Tooltip("Bullet shooted from here")]
    [SerializeField] private Transform tipObject;
    
    [SerializeField] private GameObject bulletPrefab;
    
    [Tooltip("Unit: Second")]
    [SerializeField] private float shootInterval = 1f;

    private float shootTimer;

    private void Start()
    {
        //make it able to shoot from the game start
        shootTimer = shootInterval;
    }

    private void Update()
    {
        AdvanceTimer();
    }

    private void AdvanceTimer()
    {
        shootTimer += Time.deltaTime;
    }

    public bool Shoot(int shooterN)
    {
        if (!CheckShootable())
        {
            //can't shoot
            return false;
        }

        //generate
        GameObject bulletObject = Instantiate(bulletPrefab, GameManager.instance.bulletsParent);
        
        //set position
        bulletObject.transform.position = tipObject.transform.position;

        //initialize bullet
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        Vector3 direction = this.gameObject.transform.rotation * Vector3.right;
        bullet.Lunch(direction, shooterN);

        //reset timer
        shootTimer = 0f;

        //succeeded
        return true;
    }

    public void TurnRight()
    {
        Turn(-Vector3.forward * turnSpeed);
    }

    public void TurnLeft()
    {
        Turn(Vector3.forward * turnSpeed);
    }

    private void Turn(Vector3 angularSpeed)
    {
        Vector3 movement = angularSpeed * Time.deltaTime;

        cannonCenterObject.transform.Rotate(movement);
    }

    /// <summary>
    /// true when shootable
    /// </summary>
    private bool CheckShootable()
    {
        if (shootTimer >= shootInterval)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
