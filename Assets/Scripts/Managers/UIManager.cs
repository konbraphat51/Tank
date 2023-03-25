using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField] private GameObject gameSetPanelObject;
    [SerializeField] private GameObject winnerTextObject;

    public void OnGameSet(string winnerName)
    {
        gameSetPanelObject.SetActive(true);
        winnerTextObject.GetComponent<Text>().text = winnerName + " win";
    }
}
