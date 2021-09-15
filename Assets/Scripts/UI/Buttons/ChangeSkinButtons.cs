//Este script se pone el UIManager
using UnityEngine;

public class ChangeSkinButtons : MonoBehaviour
{
    //Se ccede a la funcion SelectCharacterButtons del UIManager
    private SelectCharacterButtons selectCharacterButtons;
    //Se accede a la funcion CharacterSkin del personaje seleccionado
    private CharacterSkin characterSkin;

    private void Start()
    {
        //Se asgina el componente a la variable 
        selectCharacterButtons = gameObject.GetComponent<SelectCharacterButtons>();
    }

    //Esta funcion se coloca en el boton para cambiar a la siguiente skin
    public void NextSkin()
    {
        //Se asigna el componente de la variable
        characterSkin = selectCharacterButtons.characterSelected.GetComponent<CharacterSkin>();

        //Se mueve la skin del personaje a la siguiente
        characterSkin.skinNumber++;

        //Si se llega al limite de la ultima skin se regresa a la primera
        if(characterSkin.skinNumber > characterSkin.skins.Length - 1)
        {
            characterSkin.skinNumber = 0;
        }
    }

    //Esta funcion se coloca en el boton para cambiar a la skin anterior
    public void PreviousSkin()
    {
        //Se asigna el componente de la variable
        characterSkin = selectCharacterButtons.characterSelected.GetComponent<CharacterSkin>();

        //Se mueve la skin del personaje a la anterior
        characterSkin.skinNumber--; 
        
        //Si se llega al limite de la primera skin se mueve a la ultima
        if (characterSkin.skinNumber < 0)
        {
            characterSkin.skinNumber = characterSkin.skins.Length - 1;
        }
    }
}
