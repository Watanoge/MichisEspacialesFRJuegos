//Este script se coloca en el UIManager
using UnityEngine;

public class SelectLevelButtons : MonoBehaviour
{
    //Menu del mapa donde se encuentran los niveles
    public GameObject menuMapa;
    //Menu de seleccionar personaje
    public GameObject menuSeleccionPersonaje;
    //GameObject donde se encuentran los personajes
    public GameObject contenedorDePersonajes;
    //Variable que guarda el nivel seleccionado
    [HideInInspector] public GameObject levelSelected;

    //Funcion que se pone en el boton de seleccionar nivel
    public void SelectLevelAndOpenCharactersMenu()
    {
        //Se desactiva el menu mapa
        menuMapa.SetActive(false);
        //Se activa el menu de seleccion de personaje
        menuSeleccionPersonaje.SetActive(true);
        //Se guarda el nivel seleccionado
        levelSelected = menuMapa.GetComponentInChildren<LevelSelector>().currentlyLevel;
    }

    //Funcion que se pone en el boton atras del menu de seleccion de personaje
    public void CloseCharactersMenu()
    {
        //Se reinician todas las skins de los personajes
        for(int i = 0; i < contenedorDePersonajes.transform.childCount; i++)
        {
            contenedorDePersonajes.transform.GetChild(i).GetComponent<CharacterSkin>().skinNumber = 0;
        }

        //Se activa el menu mapa
        menuMapa.SetActive(true);
        //Se desactiva el menu de seleccion de personaje
        menuSeleccionPersonaje.SetActive(false);
        //Se borra el nivel seleccionado
        levelSelected = null;
    }
}

