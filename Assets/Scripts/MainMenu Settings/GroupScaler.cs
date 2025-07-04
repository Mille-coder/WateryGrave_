using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupScaler : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup grid;

    private void Update()
    {
        if (Screen.currentResolution.width == 2560)
        {
            grid.padding.top = 100;
        }
        else
        {
            grid.padding.top = 0;
        }
    }
}
