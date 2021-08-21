using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsOnField : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;

    public void PauseOn()
    {
        Time.timeScale = 0f;
        _pauseScreen.SetActive(true);
    }

    public void PauseOff()
    {
        _pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
