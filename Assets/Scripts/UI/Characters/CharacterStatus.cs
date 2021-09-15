//Este scrip se pone en cada GameObject en el UI que corresponda a un personaje
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    //Variable bool que determina si el personaje esta bloqueado o desbloqueado
    public bool isLocked;
    //Boton para comprar el personaje
    public GameObject botonComprar;

    private void Start()
    {
        //Si esta bloqueado se muestra el boton para comprar personaje
        if (isLocked)
        {
            botonComprar.SetActive(true);
        }
        //Si no el boton se oculta
        else
        {
            botonComprar.SetActive(false);
        }
    }
}
