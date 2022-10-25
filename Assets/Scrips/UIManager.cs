using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private string eventGameSetSequence = "SequenceGameSet";

    [SerializeField] private GameObject gameSetPanelObject;
    [SerializeField] private GameObject winnerTextObject;

    void Start()
    {
        EventManager.StartListening(eventGameSetSequence, OnGameSet);
    }

    private void OnGameSet(string str)
    {
        gameSetPanelObject.SetActive(true);
        winnerTextObject.GetComponent<Text>().text = str + " win";
    }
}
