using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    [SerializeField] private string eventRetry = "Retry";

    public void OnClick()
    {
        EventManager.TriggerEvent(eventRetry, "");
    }
}
