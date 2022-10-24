using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int keyConfig = 1;

    [SerializeField] private float forwardSpeed = 1f;
    [SerializeField] private float backSpeed = 0.7f;
    [SerializeField] private float turnSpeed = 1f;
    [SerializeField] private float turnCannonSpeed = 1f;
    [SerializeField] private float shootIntervalS = 1f;
    private float shootedDelta = 0f;

    [SerializeField] private GameObject cannonObject;
    private Cannon cannon;
    [SerializeField] private GameObject cannonCenterObject;
    [SerializeField] private GameObject bulletParent;

    void Start()
    {
        cannon = cannonObject.GetComponent<Cannon>();

        //make it able to shoot from the game start
        shootedDelta = shootIntervalS;

        if(bulletParent == null)
        {
            bulletParent = this.gameObject.transform.parent.gameObject;
        }
    }

    void Update()
    {
        GetKey();

        shootedDelta += Time.deltaTime;
    }

    private void GetKey()
    {
        switch (keyConfig)
        {
            case 1:
                if (Input.GetKey(KeyCode.W))
                {
                    MoveForward();
                }
                if (Input.GetKey(KeyCode.S))
                {
                    MoveBack();
                }
                if (Input.GetKey(KeyCode.A))
                {
                    Turn(false);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    Turn(true);
                }
                if (Input.GetKey(KeyCode.C))
                {
                    TurnCannon(false);
                }
                if (Input.GetKey(KeyCode.V))
                {
                    TurnCannon(true);
                }
                if (Input.GetKey(KeyCode.Space))
                {
                    Shoot();
                }
                break;
            case 2:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    MoveForward();
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    MoveBack();
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Turn(false);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    Turn(true);
                }
                if (Input.GetKey(KeyCode.Comma))
                {
                    TurnCannon(false);
                }
                if (Input.GetKey(KeyCode.Period))
                {
                    TurnCannon(true);
                }
                if (Input.GetKey(KeyCode.RightControl))
                {
                    Shoot();
                }
                break;
        }
    }

    private void MoveForward()
    {
        transform.Translate(forwardSpeed, 0, 0);
    }

    private void MoveBack()
    {
        transform.Translate(-backSpeed, 0, 0);
    }

    private void Turn(bool shouldGoRight)
    {
        float turnAmount;
        if (shouldGoRight)
        {
            turnAmount = -turnSpeed;
        }
        else
        {
            turnAmount = turnSpeed;
        }

        transform.Rotate(0, 0, turnAmount);
    }

    private void TurnCannon(bool shouldGoRight)
    {
        float turnAmount;
        if (shouldGoRight)
        {
            turnAmount = -turnCannonSpeed;
        }
        else
        {
            turnAmount = turnCannonSpeed;
        }

        cannonCenterObject.transform.Rotate(0, 0, turnAmount);
    }

    private void Shoot()
    {
        if (shootedDelta >= shootIntervalS)
        {
            cannon.Shoot(bulletParent, GetComponent<Tank>().number);
            shootedDelta = 0f;
        }
    }
}
