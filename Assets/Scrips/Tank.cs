using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [Tooltip("start from 0")]
    [SerializeField] public int number = 0;
    
    [SerializeField] private GameObject explosionPrefab;

    [SerializeField] private string eventDestroyed = "PlayerDestroyed";

    public void Explode()
    {
        //explosion effect
        GameObject explosionObject =  Instantiate(explosionPrefab,
                                        transform.parent);
        explosionObject.transform.position = transform.position;

        //event
        EventManager.TriggerEvent(eventDestroyed, number.ToString());

        //disappear
        Destroy(this.gameObject);
    }
}
