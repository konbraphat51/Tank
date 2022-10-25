using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerPvP : MonoBehaviour
{
    [SerializeField] private string eventDestroyed = "PlayerDestroyed";
    [SerializeField] private string eventDestroyedEffectEnd = "DestroyedEffectEnd";

    [SerializeField] private string eventSequenceGameSet = "SequenceGameSet";

    [SerializeField] private string eventRetry = "Retry";

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
        EventManager.StartListening(eventRetry, Reset);
    }

    private void GetDestroyed(string destroyed)
    {
        playersLeft.Remove(int.Parse(destroyed));
    }

    private void CheckGameSet(string str)
    {
        if (playersLeft.Count == 1)
        {
            string winner;
            if(playersLeft[0] == 0)
            {
                winner = "Blue";
            }
            else
            {
                winner = "Red";
            }

            EventManager.TriggerEvent(eventSequenceGameSet, winner);
        }
    }

    private void Reset(string str)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
