using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject settingsUI;

    [SerializeField] private int screenWidth = 1920;
    [SerializeField] private int screenHeight = 1080;

    private void Awake()
    {
        menuUI.SetActive(true);
        settingsUI.SetActive(false);

        screenWidth = Screen.currentResolution.width;
        screenHeight = Screen.currentResolution.height;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void SettingsButton()
    {
        menuUI.SetActive(false);
        settingsUI.SetActive(true);
    }

    public void BackToMenu()
    {
        menuUI.SetActive(true);
        settingsUI.SetActive(false);
    }
}
