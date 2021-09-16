//Este script se coloca en el boton de seleccionar personaje
using UnityEngine.UI;
using UnityEngine;

public class BlockSelectCharacterButton : MonoBehaviour
{
    //Componente SwipeMenu del contenedor de personajes
    public SwipeMenu contenedorDePersonajes;

    //Nuevo:
    private void Start() {
        contenedorDePersonajes.blockSelectCharacterButton = this; //se declara esto como la variable, para después ejecutar la función
    }

    //Antes:
    // private void Update()
    // {
    //     //Se llama a la funcion
    //     BlockButton();
    // }

    //Ahora la función se llama únicamente cuando cambia el valor en el SwipeMenu, en lugar de hacerse cada frame
    public void BlockButton()
    {
        //Si no se ha asignado nada a currentlySelection sale de la funcion
        if (contenedorDePersonajes.currentlySelection == null) return;
        //Esto no sé si quitarlo o no, puesto que ya nunca se ejecutaría si no lo invoca swipe menu con un valor
        //pero igual lo dejo por si las moscas

        //Si el personaje que se quiere seleccionar esta bloqueado se deshabilita el boton

        //Antes:
        // if (contenedorDePersonajes.currentlySelection.GetComponent<CharacterStatus>().isLocked)
        // {
        //     gameObject.GetComponent<Button>().interactable = false;
        // }
        // Si no se habilita
        // else
        // {
        //     gameObject.GetComponent<Button>().interactable = true;
        // }

        // Nuevo:
        GetComponent<Button>().interactable = !contenedorDePersonajes.currentlySelection.GetComponent<CharacterStatus>().isLocked;
        //Al igual que en CharacterStatus, se aplica la inversa de tu if para saltarse el if/else
        //de igual manera, el gameObject.GetComponent es redundante, ya que GetComponent automáticamente accede al objeto actual
        //si no se especifica antes
    }
}
