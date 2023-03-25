using UnityEngine;
using System;

//https://qiita.com/Teach/items/c146c7939db7acbd7eee

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T _instance;
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                Type t = typeof(T);

                _instance = (T)FindObjectOfType(t);
                if (_instance == null)
                {
                    Debug.LogError(t + "There is no attachment of this component");
                }
            }

            return _instance;
        }
    }

    virtual protected void Awake()
    {
        // Check if there is another attachment
        // If there is, delete this
        CheckInstance();
    }

    protected bool CheckInstance()
    {
        if (_instance == null)
        {
            _instance = this as T;
            return true;
        }
        else if (instance == this)
        {
            return true;
        }
        Destroy(this);
        return false;
    }
}