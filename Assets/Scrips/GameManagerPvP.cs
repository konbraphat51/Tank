using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPvP : MonoBehaviour
{
    [SerializeField] private string eventDestroyed = "PlayerDestroyed";
    [SerializeField] private string eventDestroyedEffectEnd = "DestroyedEffectEnd";

    [SerializeField] private int playerN = 2;
    private List<int> playersLeft;

    void Start()
    {
        playersLeft = new List<int>();
        for (int cnt = 0; cnt < playerN; cnt++)
        {
            playersLeft.Add(cnt);
        }

        EventManager.StartListening(eventDestroyed, GetDestroyed);
        EventManager.StartListening(eventDestroyedEffectEnd, CheckGameSet);
    }

    private void GetDestroyed(string destroyed)
    {
        playersLeft.Remove(int.Parse(destroyed));
    }

    private void CheckGameSet(string str)
    {
        if (playersLeft.Count == 1)
        {
            //playersLeft[0] won
        }
    }
}
