using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DeathText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI deathMessenger;
    [SerializeField] GameObject HelmetDeathImage;
    [SerializeField] GameObject BootsDeathImage;
    [SerializeField] GameObject SuitDeathImage;
    
    string messege;
    void Start()
    {
        if (StaticData.valueToKeep == 2)
        {
            messege = "That helmet wont save you from anything the moment you walk out your lungs fill out with water";
        }
        if (StaticData.valueToKeep == 3)
        {
            messege = "Your helmet might be secure but your suit is full of holes that let the deadly water in";
            SuitDeathImage.gameObject.SetActive(true);
        }
        if (StaticData.valueToKeep == 4)
        {
            messege = "Your suit holds well no water can get trough but with only air supply being your lungs you die quickly";
            BootsDeathImage.gameObject.SetActive(true);
        }
        if (StaticData.valueToKeep == 5)
        {
            messege = "Your suit holds your air supply works but with how light you are you cannot walk on the bottom you drift helplessly until your air ends";
            BootsDeathImage.gameObject.SetActive(true);
        }
        if (StaticData.valueToKeep == 0)
        {
            messege = "Leaving this place without full suit was a stupid idea you die immediately";
        }
        if (StaticData.valueToKeep == 6)
        {
            messege = "You left with oxygen bottles but when they are empty their purpose is reduced to paperweight, you die quickly";
            BootsDeathImage.gameObject.SetActive(true);
        }
        if (StaticData.valueToKeep == 7)
        {
            messege = "Not sure how you got here";
        }
        
        
        deathMessenger.text = messege;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
