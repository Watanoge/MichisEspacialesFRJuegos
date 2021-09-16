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
        //Antes:
        // //Si esta bloqueado se muestra el boton para comprar personaje
        // if (isLocked)
        // {
        //     botonComprar.SetActive(true);
        // }
        // //Si no el boton se oculta
        // else
        // {
        //     botonComprar.SetActive(false);
        // }

        //Nuevo:
        botonComprar.SetActive(isLocked);

        /*
        Si te fijas, el valor de activado de botonComprar es el valor de isLocked
        Poner directamente isLocked, regresa true o false, dependiendo su valor. Poner !bool regresa el inverso
        (si bool es falso, regresa verdadero, y si es verdadero regresará falso)

        En este caso, el código se puede simplificar de esta manera saltandose el if/else y directamente
        asignando el valor de isLocked
        */
    }
}
