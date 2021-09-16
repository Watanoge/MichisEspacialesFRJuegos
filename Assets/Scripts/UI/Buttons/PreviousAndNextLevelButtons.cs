//Este script se coloca en el UIManager

using TMPro;
using UnityEngine;
// using UnityEngine.UI; lo comento porque no es necesario invocar cosas que no se van a usar

public class PreviousAndNextLevelButtons : MonoBehaviour
{
    public TextMeshProUGUI stateName;
    //Variable que contiene el GameObject del selector (Objeto que no pertenece al Canvas)

    //Antes:
    // public GameObject selector;
    // //Script que contiene el GameObject selector donde se guarda la lista de los estados(niveles)
    // private LevelSelector levelSelector;

    // private void Start()
    // {
    //     levelSelector = selector.GetComponent<LevelSelector>();
    // }

    // Nuevo:
    [SerializeField] private LevelSelector levelSelector;
    // El tag de "SerializeField" antes de una variable privada te permite poder verla en el editor
    //Esto te evita tu función se start donde solo se usa la variable "selector" para asignar el script

    //Funcion que se asigna al boton para moverse al estado siguiente
    public void MoveToNextLevel()
    {
        //Antes:
        //Si no existe un nivel siguiente (Estas posicionado en el ultimo estado) se ejecuta esta parte
        // if (levelSelector.nextLevel == null)
        // {
        //     //Se cancela la animacion del currently level para que se termine el loop ping pong
        //     LeanTween.cancel(levelSelector.currentlyLevel);
        //     //Se anima el currently level haciendo que regrese a su escala original (1, 1, 1)
        //     levelSelector.currentlyLevel.transform.LeanScale(Vector3.one, 0.3f);
        //     //El currently level se iguala al primer nivel que existe en la lista de niveles
        //     levelSelector.currentlyLevel = levelSelector.firstLevel;
        //     //Se anima el nivel seleccionado aumentando su escala a 1.5 con un loop ping pong
        //     levelSelector.currentlyLevel.transform.LeanScale(Vector3.one * 1.5f, 0.5f).setLoopPingPong();
        //     //Sale de la funcion
        //     return;
        // }
        // //Se cancela la animacion del currently level para que se termine el loop ping pong
        // LeanTween.cancel(levelSelector.currentlyLevel);
        // //Se anima el currently level haciendo que regrese a su escala original (1, 1, 1)
        // levelSelector.currentlyLevel.transform.LeanScale(Vector3.one, 0.3f);
        // //El currently level se iguala al siguiente nivel
        // levelSelector.currentlyLevel = levelSelector.nextLevel;
        // //Se anima el nivel seleccionado aumentando su escala a 1.5 con un loop ping pong
        // levelSelector.currentlyLevel.transform.LeanScale(Vector3.one * 1.5f, 0.5f).setLoopPingPong();

        //Nuevo:
        //Se cancela la animacion del currently level para que se termine el loop ping pong
        LeanTween.cancel(levelSelector.currentlyLevel);
        //Se anima el currently level haciendo que regrese a su escala original (1, 1, 1)
        levelSelector.currentlyLevel.transform.LeanScale(Vector3.one, 0.3f);
        //El currently level se iguala al siguiente nivel

        levelSelector.currentlyLevel = levelSelector.nextLevel == null ? levelSelector.firstLevel : levelSelector.nextLevel;
        //Ésta es la única cosa que cambia entre las dos versiones, no es necesario repetirlo, nomás meter un ternario

        //Se anima el nivel seleccionado aumentando su escala a 1.5 con un loop ping pong
        levelSelector.currentlyLevel.transform.LeanScale(Vector3.one * 1.5f, 0.5f).setLoopPingPong();

        levelSelector.SetNextLevel();
        levelSelector.SetPreviousLevel();
        //Ya tenemos referencia al levelSelector, podemos invocar la función de SetNextLevel desde
        //aquí en lugar de tenerlo en el update el LevelSelector.cs
    }
    
    //Funcion que se asigna al boton para moverse al estado anterior
    public void MoveToPreviousLevel()
    {
        //Antes:
        //Si no existe un nivel anterior (Estas posicionado en el primer estado) se ejecuta esta parte
        // if (levelSelector.previousLevel == null)
        // {
        //     //Se cancela la animacion del currently level para que se termine el loop ping pong
        //     LeanTween.cancel(levelSelector.currentlyLevel);
        //     //Se anima el currently level haciendo que regrese a su escala original (1, 1, 1)
        //     levelSelector.currentlyLevel.transform.LeanScale(Vector3.one, 0.3f);
        //     //El currently level se iguala al ultimo nivel que existe en la lista de niveles
        //     levelSelector.currentlyLevel = levelSelector.lastLevel;
        //     //Se anima el nivel seleccionado aumentando su escala a 1.5 con un loop ping pong
        //     levelSelector.currentlyLevel.transform.LeanScale(Vector3.one * 1.5f, 0.5f).setLoopPingPong();
        //     //Sale de la funcion
        //     return;
        // }
        // //Se cancela la animacion del currently level para que se termine el loop ping pong
        // LeanTween.cancel(levelSelector.currentlyLevel);
        // //Se anima el currently level haciendo que regrese a su escala original (1, 1, 1)
        // levelSelector.currentlyLevel.transform.LeanScale(Vector3.one, 0.3f);
        // //El currently level se iguala al nivel anterior 
        // levelSelector.currentlyLevel = levelSelector.previousLevel;
        // //Se anima el nivel seleccionado aumentando su escala a 1.5 con un loop ping pong
        // levelSelector.currentlyLevel.transform.LeanScale(Vector3.one * 1.5f, 0.5f).setLoopPingPong();

        //Nuevo:

        //Se cancela la animacion del currently level para que se termine el loop ping pong
        LeanTween.cancel(levelSelector.currentlyLevel);
        //Se anima el currently level haciendo que regrese a su escala original (1, 1, 1)
        levelSelector.currentlyLevel.transform.LeanScale(Vector3.one, 0.3f);
        //El currently level se iguala al nivel anterior 
        
        levelSelector.currentlyLevel =levelSelector.previousLevel == null ? levelSelector.lastLevel : levelSelector.previousLevel;
        //Ésta es la única cosa que cambia entre las dos versiones, no es necesario repetirlo, nomás meter un ternario

        //Se anima el nivel seleccionado aumentando su escala a 1.5 con un loop ping pong
        levelSelector.currentlyLevel.transform.LeanScale(Vector3.one * 1.5f, 0.5f).setLoopPingPong();

        levelSelector.SetNextLevel();
        levelSelector.SetPreviousLevel();
        //Ya tenemos referencia al levelSelector, podemos invocar la función de SetPreviousLevel desde
        //aquí en lugar de tenerlo en el update el LevelSelector.cs
    }

    public void UpdateText()
    {
        //Muestra el nombre del estado seleccionado
        stateName.GetComponent<TextMeshProUGUI>().text = levelSelector.currentlyLevel.name;
    }
}
