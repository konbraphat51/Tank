using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int tankID { get; private set; }

    public void Initialize(int id)
    {
        tankID = id;
    }

    public void OnExplosionEnd()
    {
        Destroy(this.gameObject);
    }
}
