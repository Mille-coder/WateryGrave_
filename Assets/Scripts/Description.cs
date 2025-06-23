using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Description : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _desField;
    public string text;
    public UnityEvent Describe;
    public UnityEvent ChangeDescryption;

    public void RecivedDescription(string des)
{
    text = des;
    Debug.Log(des);
    _desField.text = $"{des}";
    
}

}

