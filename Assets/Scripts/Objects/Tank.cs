using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour, CollidableObject
{
    [SerializeField] private new string name;
    
    public int id { get; private set; }

    [SerializeField] private GameObject explosionPrefab;

    [SerializeField] private Cannon cannon;

    [Header("Movement")]

    [SerializeField] private float forwardSpeed = 1f;
    [SerializeField] private float backSpeed = 0.7f;
    [SerializeField] private float turnSpeed = 1f;

    private void Start()
    {
        id = GameManager.instance.RegisterTank(name);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //collided with bullet
        if (collision.gameObject.tag == "Bullet")
        {
            CollidableObject opponent = collision.gameObject.GetComponent<CollidableObject>();

            //check collidable
            if (!CheckCollidable(opponent.id) || !opponent.CheckCollidable(id))
            {
                return;
            }

            //Explode
            Explode();
        }
    }

    /// <summary>
    /// Been destroyed
    /// </summary>
    public void Explode()
    {
        //explosion effect
        GameObject explosionObject =  Instantiate(explosionPrefab,
                                        transform.parent);
        explosionObject.transform.position = transform.position;

        //tell to GameManager
        GameManager.instance.OnTankDestroyed(id);

        //disappear
        Destroy(this.gameObject);
    }

    public void MoveForward()
    {
        Move(transform.right * forwardSpeed);
    }

    public void MoveBack()
    {
        Move(-transform.right * backSpeed);
    }

    private void Move(Vector2 velocity)
    {
        Vector2 movement = velocity * Time.deltaTime;

        transform.position += (Vector3)movement;
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

        transform.Rotate(movement);
    }

    public void TurnCannonRight()
    {
        cannon.TurnRight();
    }

    public void TurnCannonLeft()
    {
        cannon.TurnLeft();
    }

    public void Shoot()
    {
        cannon.Shoot(id);
    }

    public bool CheckCollidable(int opponentID)
    {
        return true;
    }
}
