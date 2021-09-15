//Este script se pone en el GameObject Content del scrollview que se va configurar
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    //Variable que contiene el scrollbar del scroll view
    public Scrollbar scrollbar;
    //Variable que configurara el la posicion del scroll
    private float scroll_pos = 0;
    //Array que guardara las posiciones de los objetos que contiene el scroll
    //En estas posiciones se snapeara el scroll
    private float[] pos;
    //Variable bool que determina si se quiere obtener el objeto que esta seleccionado en el SwipeMenu
    public bool checkSelection;
    //Variable que guarda el GameObject que esta seleccionado en el scroll
    [HideInInspector] public GameObject currentlySelection;

    void Update()
    {
        //Se guardan todos los hijos que contiene el GameObject content en el array de pos
        pos = new float[transform.childCount];
        //Se crea una variable llamada distance que sera la distancia que hay entre cada
        //hijo de content
        float distance = 1f / (pos.Length - 1f);

        //En este ciclo for se guardan las posiciones en el array pos
        //en cada lugar que le corresponde
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        //Mientras se este tocando la pantalla
        if (Input.GetMouseButton(0))
        {
            //La variable scroll_pos se iguala al valor de la scrollbar
            scroll_pos = scrollbar.value;
        }
        //Cuando se suelte la pantalla
        else
        {
            //Se recorren todos los GameObjects de los hijos para snapearse en el hijo mas cercano
            for (int i = 0; i < pos.Length; i++)
            {
                //Se comprueba que la variable scroll_pos se encuentre entre la distancia media
                //minima y maxima con referencia al hijo que se esta analizando
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.value = Mathf.Lerp(scrollbar.value, pos[i], 0.1f);

                    //Si esta activado se observa que objeto esta seleccionado en el SwipeMenu
                    if (checkSelection)
                    {
                        //Se guarda la variable dependiendo en que hijo del Content se esta viendo
                        currentlySelection = transform.GetChild(i).gameObject;
                    }
                }
            }
        }
    }
}
