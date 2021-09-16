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

    // public ShowLevelSelectedName selectedName;
    //Nuevo:
    //Se declara quién es "selectedName" para después invocar la nueva función
    public void DeclareSelectedName(ShowLevelSelectedName newSelectedName){
        // selectedName = newSelectedName;
    }

    //Igual se declara quién es "previousAndNextLevelButtons" para invocar su nueva función
    public PreviousAndNextLevelButtons previousAndNextLevelButtons;
    public void DeclarePreviousAndNextLevelButtons(PreviousAndNextLevelButtons newPreviousAndNextLevelButtons){
        previousAndNextLevelButtons = newPreviousAndNextLevelButtons;
    }
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
        
        //Nuevo:
        SetPreviousLevel();
        SetNextLevel();
        SetPreviousLevel();
        UpdateTexts();
        //Se ejecuta la nueva función para actualizar los textos 
    }

    //Antes:
    // private void Update()
    // {
    //     //Se llama a las siguiente funciones
    //     SetPreviousLevel();
    //     SetNextLevel();
    // }

    //Se borra esto ya que se usan las referencias existentes del script "PreviousAndNextLevelButtons"

    //Nuevo:
    public void UpdateTexts(){
        // selectedName.UpdateText();
        previousAndNextLevelButtons.UpdateText();
        //Esto evita que tanto previous blablabla utilicen el update para actualizar los textos
        //que solo debe actualizarse al cambiarse los nombres
    }

    //Funcion que define la variable "previousLevel"
    //Nuevo: se volvieron públicas para poder ser ejecutadas por evento
    public void SetPreviousLevel()
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

        /*
            Nota: esto se puede convertir en un ternario de la siguiente manera:

            bool previousLevelExists = currentlyLevel.transform.GetSiblingIndex() - 1 > -1;
            previousLevel = previousLevelExists ? levelsList.transform.GetChild(currentlyLevel.transform.GetSiblingIndex() - 1).gameObject : null;

            Los ternarios funcionan así:
            (condición) ? (retorno de valor en caso de true) : (retorno de valor en caso de false)

            Esto te evita esos if/else para asignar valores de A o B dependiendo de una condición
        */

        //Nuevo:
        UpdateTexts();
        //Se ejecuta la nueva función para actualizar los textos 
    }

    //Funcion que define la variable "nextLevel"
    //Nuevo: se volvieron públicas para poder ser ejecutadas por evento
    public void SetNextLevel()
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
        
        //Nuevo:
        UpdateTexts();
        //Se ejecuta la nueva función para actualizar los textos 
    }
}
