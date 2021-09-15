//Este script va en el GameObject UIManager
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacterButtons : MonoBehaviour
{
    //Menu de seleccion de personaje
    public GameObject menuSeleccionPersonaje;
    //Menu de seleccion de skin
    public GameObject menuSeleccionSkin;
    //GameObject donde estan los personajes a seleccionar
    public GameObject contenedorDePersonajes;
    //GameObject a donde se mandara el personaje seleccionado
    public GameObject nuevoContenedorDePersonaje;
    //Variable donde se guarda el personaje seleccionado
    [HideInInspector] public GameObject characterSelected;
    //Posicion del personaje en el contenedor
    private int characterPositionInContainer;

    //Esta funcion se coloca en el boton para seleccionar el personaje
    public void SelectCharacterAndOpenSkinMenu()
    {
        //Se detecta que personaje es el que se esta seleccionando, tomandolo del Scroll de los personajes
        //mediante la variable currentlyCharacter
        characterSelected = menuSeleccionPersonaje.GetComponentInChildren<SwipeMenu>().currentlySelection;
        //Se guarda la posicion del personaje seleccionado en el contenedor de personajes
        characterPositionInContainer = characterSelected.transform.GetSiblingIndex();
        //Se le asigna un nuevo padre al personaje seleccionado, este padre se encuentra en otro menu
        //de esta manera los otros personajes ya no estara visibles
        characterSelected.transform.SetParent(nuevoContenedorDePersonaje.transform);
        //Se manda el personaje seleccionado al centro de la pantalla
        characterSelected.GetComponent<RectTransform>().localPosition = Vector3.zero;
        //Se desactiva el menu de seleccion de personaje
        menuSeleccionPersonaje.SetActive(false);
        //Se activa el menu de seleccion de skin
        menuSeleccionSkin.SetActive(true);
    }

    //Esta funcion va en el boton atras del menu para seleccionar skin
    public void CloseSkinMenu()
    {
        //Se le asigna el padre en el menu de seleccion de personaje para que regrese al Scroll de personajes
        characterSelected.transform.SetParent(contenedorDePersonajes.transform);
        //Se le asigna la posicion que ya tenia en la lista 
        characterSelected.transform.SetSiblingIndex(characterPositionInContainer);
        //Se activa el menu de seleccionar personaje
        menuSeleccionPersonaje.SetActive(true);
        //Se desactiva el menu de seleccionar skin
        menuSeleccionSkin.SetActive(false);
    }
}
