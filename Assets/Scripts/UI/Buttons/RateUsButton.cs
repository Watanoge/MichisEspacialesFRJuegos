//Este script se debe poner en el GameObject de UIManager

using UnityEngine;

public class RateUsButton : MonoBehaviour
{
    //Funcion que activa la funcion de calificar
    public void RateUs()
    {
        //Se abre el URL de la aplicacion en la playstore
        Application.OpenURL("url de la aplicacion (market://deatils?id=com.test.test ejemplo)");
    }
}
