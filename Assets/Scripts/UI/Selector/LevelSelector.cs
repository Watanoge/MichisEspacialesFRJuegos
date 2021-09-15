//Este script se debe colocar en el GameObject que funcionara como selector

using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    //Variable que contiene el GameObject con todos los niveles
    public GameObject levelsList;

    //Primer nivel de la lista
    [HideInInspector] public GameObject firstLevel;
    //Ultimo nivel de la lista
    [HideInInspector] public GameObject lastLevel;
    //Nivel anterior al nivel seleccionado
    [HideInInspector] public GameObject previousLevel;
    //Nivel seleccionado
    [HideInInspector] public GameObject currentlyLevel;
    //Nivel siguiente al nivel seleccionado
    [HideInInspector] public GameObject nextLevel;

    void Start()
    {
        //La variable "firstLevel" se iguala al primer hijo de la lista "levelsList"
        firstLevel = levelsList.transform.GetChild(0).gameObject;
        //La variable "lastLevel" se iguala al ultimo hijo de la lista "levelsList"
        lastLevel = levelsList.transform.GetChild(levelsList.transform.childCount - 1).gameObject;
        //La variable "currentlyLevel" se iguala al hijo donde el selector se encuentra posicionado
        currentlyLevel = levelsList.transform.GetChild(0).gameObject;
        //Se anima el nivel seleccionado aumentando su escala a 1.5 con un loop ping pong
        currentlyLevel.transform.LeanScale(Vector3.one * 1.5f, 0.5f).setLoopPingPong();
    }
    private void Update()
    {
        //Se llama a las siguiente funciones
        SetPreviousLevel();
        SetNextLevel();
    }

    //Funcion que define la variable "previousLevel"
    private void SetPreviousLevel()
    {
        //Si antes del GameObject "currentlyLevel" existe otro GameObject se ejecuta esta parte
        if (currentlyLevel.transform.GetSiblingIndex() - 1 > -1)
        {
            //La variable "previousLevel" se iguala al GameObject anterior en la lista de niveles, tomando
            //como referencia el "currentlyLevel"
            previousLevel = levelsList.transform.GetChild(currentlyLevel.transform.GetSiblingIndex() - 1).gameObject;
        }
        //Si no "previousLevel" se define como null
        else
        {
            previousLevel = null;
        }
    }

    //Funcion que define la variable "nextLevel"
    private void SetNextLevel()
    {
        //Si desoues del GameObject "currentlyLevel" existe otro GameObject se ejecuta esta parte
        if (currentlyLevel.transform.GetSiblingIndex() + 1 < levelsList.transform.childCount)
        {
            //La variable "nextLevel" se iguala al GameObject siguiente en la lista de los niveles, tomando
            //como referencia el "currentlyLevel"
            nextLevel = levelsList.transform.GetChild(currentlyLevel.transform.GetSiblingIndex() + 1).gameObject;
        }
        //Si no "nextLevel" se define como null
        else
        {
            nextLevel = null;
        }
    }
}
