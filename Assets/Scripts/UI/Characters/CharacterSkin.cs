//Este scrip se pone en cada GameObject en el UI que corresponda a un personaje
using UnityEngine;
using UnityEngine.UI;

public class CharacterSkin : MonoBehaviour
{
    //Array que contiene los diferentes skins del personaje
    //(Puede ser color, sprite, etc)
    public Color[] skins;
    //Numero de skin que tiene seleccionado el personaje
    [HideInInspector] public int skinNumber = 0;

    void Update()
    {
        //Se actualiza la skin dependiendo del numero seleccionado
        gameObject.GetComponentInChildren<Image>().color = skins[skinNumber];
    }
}
