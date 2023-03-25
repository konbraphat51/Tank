using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CollidableObject
{
    public bool CheckCollidable(int opponentID);

    public int id { get; }
}
