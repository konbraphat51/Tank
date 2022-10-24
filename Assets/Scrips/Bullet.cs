using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int shooterN;

    //control velocity because of reflection behavior
    public Vector2 velocity;

    [SerializeField] private int reflectionMax = 1;
    private int reflectionCurrent = 0;

    private void Update()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            reflectionCurrent++;
            if(reflectionCurrent > reflectionMax)
            {
                Destroy(this.gameObject);
            }

            Vector2 velocityNext
                = Vector2.Reflect(velocity, collision.contacts[0].normal);
            velocity = velocityNext;
        }

        if(collision.gameObject.tag == "Player")
        {
            Tank colliderTank = collision.gameObject.GetComponent<Tank>();
            
            //avoid self-destruct
            if ((colliderTank.number == shooterN) && (reflectionCurrent == 0))
            {
                return;
            }
            
            colliderTank.Explode();

            Destroy(this.gameObject);
        }
    }
}
