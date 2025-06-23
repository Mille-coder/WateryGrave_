using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RackPopup : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] Button inventory;
    [SerializeField] Button rackButton;

    public bool wasIShown = false;
    void Start()
    {
        wasIShown = true;
        inventory.interactable = true;
        rackButton.interactable = true;
        closeButton.onClick.AddListener(ClosePopup);

    }

    void ClosePopup()
    {
        Destroy(gameObject);
    }
}
