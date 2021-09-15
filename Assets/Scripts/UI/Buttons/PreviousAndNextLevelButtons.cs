//Este script se coloca en el UIManager

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreviousAndNextLevelButtons : MonoBehaviour
{
    public TextMeshProUGUI stateName;
    //Variable que contiene el GameObject del selector (Objeto que no pertenece al Canvas)
    public GameObject selector;
    //Script que contiene el GameObject selector donde se guarda la lista de los estados(niveles)
    private LevelSelector levelSelector;

    private void Start()
    {
        levelSelector = selector.GetComponent<LevelSelector>();
    }

    //Funcion que se asigna al boton para moverse al estado siguiente
    public void MoveToNextLevel()
    {
        //Si no existe un nivel siguiente (Estas posicionado en el ultimo estado) se ejecuta esta parte
        if (levelSelector.nextLevel == null)
        {
            //Se cancela la animacion del currently level para que se termine el loop ping pong
            LeanTween.cancel(levelSelector.currentlyLevel);
            //Se anima el currently level haciendo que regrese a su escala original (1, 1, 1)
            levelSelector.currentlyLevel.transform.LeanScale(Vector3.one, 0.3f);
            //El currently level se iguala al primer nivel que existe en la lista de niveles
            levelSelector.currentlyLevel = levelSelector.firstLevel;
            //Se anima el nivel seleccionado aumentando su escala a 1.5 con un loop ping pong
            levelSelector.currentlyLevel.transform.LeanScale(Vector3.one * 1.5f, 0.5f).setLoopPingPong();
            //Sale de la funcion
            return;
        }
        //Se cancela la animacion del currently level para que se termine el loop ping pong
        LeanTween.cancel(levelSelector.currentlyLevel);
        //Se anima el currently level haciendo que regrese a su escala original (1, 1, 1)
        levelSelector.currentlyLevel.transform.LeanScale(Vector3.one, 0.3f);
        //El currently level se iguala al siguiente nivel
        levelSelector.currentlyLevel = levelSelector.nextLevel;
        //Se anima el nivel seleccionado aumentando su escala a 1.5 con un loop ping pong
        levelSelector.currentlyLevel.transform.LeanScale(Vector3.one * 1.5f, 0.5f).setLoopPingPong();
    }
    
    //Funcion que se asigna al boton para moverse al estado anterior
    public void MoveToPreviousLevel()
    {
        //Si no existe un nivel anterior (Estas posicionado en el primer estado) se ejecuta esta parte
        if (levelSelector.previousLevel == null)
        {
            //Se cancela la animacion del currently level para que se termine el loop ping pong
            LeanTween.cancel(levelSelector.currentlyLevel);
            //Se anima el currently level haciendo que regrese a su escala original (1, 1, 1)
            levelSelector.currentlyLevel.transform.LeanScale(Vector3.one, 0.3f);
            //El currently level se iguala al ultimo nivel que existe en la lista de niveles
            levelSelector.currentlyLevel = levelSelector.lastLevel;
            //Se anima el nivel seleccionado aumentando su escala a 1.5 con un loop ping pong
            levelSelector.currentlyLevel.transform.LeanScale(Vector3.one * 1.5f, 0.5f).setLoopPingPong();
            //Sale de la funcion
            return;
        }
        //Se cancela la animacion del currently level para que se termine el loop ping pong
        LeanTween.cancel(levelSelector.currentlyLevel);
        //Se anima el currently level haciendo que regrese a su escala original (1, 1, 1)
        levelSelector.currentlyLevel.transform.LeanScale(Vector3.one, 0.3f);
        //El currently level se iguala al nivel anterior 
        levelSelector.currentlyLevel = levelSelector.previousLevel;
        //Se anima el nivel seleccionado aumentando su escala a 1.5 con un loop ping pong
        levelSelector.currentlyLevel.transform.LeanScale(Vector3.one * 1.5f, 0.5f).setLoopPingPong();
    }

    void Update()
    {
        //Muestra el nombre del estado seleccionado
        stateName.GetComponent<TextMeshProUGUI>().text = levelSelector.currentlyLevel.name;
    }
}
