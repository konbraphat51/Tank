using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    /// <summary>
    /// IDs of tanks surviving
    /// </summary>
    protected HashSet<int> playersLeft = new HashSet<int>();

    /// <summary>
    /// Names of tanks
    /// </summary>
    protected Dictionary<int, string> names = new Dictionary<int, string>();

    private int lastDestroyed;

    private int winner;

    [SerializeField] private Transform _bulletsParent;

    [Tooltip("Time between game set and last tank destroyed")]
    [SerializeField] private float delayGameSet = 1f;

    public Transform bulletsParent { get { return _bulletsParent; } }

    /// <summary>
    /// Register tank, return the tank's ID
    /// </summary>
    public int RegisterTank(string name)
    {
        int id = FindID();

        //register
        playersLeft.Add(id);

        //remember name
        names[id] = name;

        return id;
    }

    private int FindID()
    {
        for (int id = 0; true; id++)
        {
            if (!playersLeft.Contains(id))
            {
                //not in the HashSet
                return id;
            }
        }
    }

    private void GetDestroyed(string destroyed)
    {
        playersLeft.Remove(int.Parse(destroyed));
    }
    
    public void OnTankDestroyed(int tankID)
    {
        //delete destroyed tank
        playersLeft.Remove(tankID);

        lastDestroyed = tankID;

        //check if game set
        if (CheckGameSet())
        {
            GetWinner();

            Invoke(nameof(SetGame), delayGameSet);
        }
    }

    private void SetGame()
    {
        UIManager.instance.OnGameSet(names[winner]);
    }

    protected virtual bool CheckGameSet()
    {
        if (playersLeft.Count == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void GetWinner()
    {
        Debug.Assert(playersLeft.Count == 1);

        //get the left winner
        foreach(int left in playersLeft)
        {
            winner = left;
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
