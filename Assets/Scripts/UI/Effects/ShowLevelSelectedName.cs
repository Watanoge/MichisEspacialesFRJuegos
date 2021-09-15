using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowLevelSelectedName : MonoBehaviour
{
    public LevelSelector levelSelector;

    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = levelSelector.currentlyLevel.name;
    }
}
