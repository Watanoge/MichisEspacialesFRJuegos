//Este script se coloca en el boton de seleccionar personaje
using UnityEngine.UI;
using UnityEngine;

public class BlockSelectCharacterButton : MonoBehaviour
{
    //Componente SwipeMenu del contenedor de personajes
    public SwipeMenu contenedorDePersonajes;

    private void Update()
    {
        //Se llama a la funcion
        BlockButton();
    }

    private void BlockButton()
    {
        //Si no se ha asignado nada a currentlySelection sale de la funcion
        if (contenedorDePersonajes.currentlySelection == null) return;

        //Si el personaje que se quiere seleccionar esta bloqueado se deshabilita el boton
        if (contenedorDePersonajes.currentlySelection.GetComponent<CharacterStatus>().isLocked)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        //Si no se habilita
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
