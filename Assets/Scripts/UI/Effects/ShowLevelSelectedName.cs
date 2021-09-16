using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowLevelSelectedName : MonoBehaviour
{
    public LevelSelector levelSelector;

    //Nuevo:
    //Al iniciar, le dice al LevelSelector quién somos
    void Start() {
        levelSelector.DeclareSelectedName(this); 
    }

    public void UpdateText()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = levelSelector.currentlyLevel.name;
    }
}
