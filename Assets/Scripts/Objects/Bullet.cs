using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, CollidableObject
{
    public int id { get; protected set; }

    //control velocity because of reflection behavior
    private Vector2 velocity;

    [SerializeField] private int reflectionMax = 1;

    [SerializeField] private float bulletSpeed = 6f;

    public int reflectionCurrent { get; private set; } = 0;

    private void Update()
    {
        Move();
    }

    public void Lunch(Vector2 direction, int shooterN)
    {
        this.velocity = direction.normalized * bulletSpeed;
        this.id = shooterN;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //collided with wall
        if(collision.gameObject.tag == "Wall")
        {
            //disappear when reflected too much
            reflectionCurrent++;
            if(reflectionCurrent > reflectionMax)
            {
                Disappear();
            }


            Reflect(collision.contacts[0].normal);
        }

        //collided with player
        if(collision.gameObject.tag == "Player")
        {
            CollidableObject opponent = collision.gameObject.GetComponent<CollidableObject>();

            //check collidable
            if (!CheckCollidable(opponent.id) || !opponent.CheckCollidable(id))
            {
                return;
            }

            Disappear();
        }
    }

    /// <summary>
    /// Move by velocity
    /// </summary>
    private void Move()
    {
        transform.position += (Vector3)velocity * Time.deltaTime;
    }

    /// <summary>
    /// Reflect vertically when hit on wall
    /// </summary>
    /// <param name="normal"></param>
    private void Reflect(Vector2 normal)
    {
        Vector2 velocityNext = Vector2.Reflect(velocity, normal);
        velocity = velocityNext;
    }

    /// <summary>
    /// Been destroyed
    /// </summary>
    private void Disappear()
    {
        Destroy(this.gameObject);
    }

    public bool CheckCollidable(int opponentID)
    {
        //avoid self-destruct
        if ((id == opponentID) && (reflectionCurrent == 0))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
