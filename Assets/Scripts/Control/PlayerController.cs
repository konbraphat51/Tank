using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int keyConfig = 1;

    [SerializeField] private Tank tank;

    void Update()
    {
        GetKey();
    }

    private void GetKey()
    {
        switch (keyConfig)
        {
            case 1:
                if (Input.GetKey(KeyCode.W))
                {
                    tank.MoveForward();
                }
                if (Input.GetKey(KeyCode.S))
                {
                    tank.MoveBack();
                }
                if (Input.GetKey(KeyCode.A))
                {
                    tank.TurnLeft();
                }
                if (Input.GetKey(KeyCode.D))
                {
                    tank.TurnRight();
                }
                if (Input.GetKey(KeyCode.C))
                {
                    tank.TurnCannonLeft();
                }
                if (Input.GetKey(KeyCode.V))
                {
                    tank.TurnCannonRight();
                }
                if (Input.GetKey(KeyCode.Space))
                {
                    tank.Shoot();
                }
                break;
            case 2:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    tank.MoveForward();
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    tank.MoveBack();
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    tank.TurnLeft();
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    tank.TurnRight();
                }
                if (Input.GetKey(KeyCode.Comma))
                {
                    tank.TurnCannonLeft();
                }
                if (Input.GetKey(KeyCode.Period))
                {
                    tank.TurnCannonRight();
                }
                if (Input.GetKey(KeyCode.RightControl))
                {
                    tank.Shoot();
                }
                break;
        }
    }
}