using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Tooltip("When start CheckGameSet")]
    [SerializeField] private string eventExplosionHalf = "ExplosionHalf";

    public void OnExplosionHalf()
    {
        EventManager.TriggerEvent(eventExplosionHalf, "");
    }

    public void OnExplosionEnd()
    {
        Destroy(this.gameObject);
    }
}
