//Este script se debe poner en el GameObject de UIManager

using UnityEngine;
using TMPro;

public class SelectLanguageButtons : MonoBehaviour
{
    //La variable que contiene el texto del lenguaje seleccionado
    public TextMeshProUGUI languageText;
    //Contador para ver en que lenguaje se encuentra el usuario
    private int i;

    private void Awake()
    {
        //Cambia el texto de la caja dependiendo del idioma que se haya guardado
        switch (PlayerPrefs.GetInt("LanguageSelected"))
        {
            //Si i=0 esta en idioma español
            case 0:
                //Se cambia el texto de la caja de lenguaje a "ESPAÑOL"
                languageText.text = "ESPAÑOL";
                break;
            //Si i=1 esta en idioma ingles
            case 1:
                //Se cambia el texto de la caja de lenguaje a "INGLES"
                languageText.text = "ENGLISH";
                break;
        }
    }

    //Funcion que se utiliza en el boton de flecha derecha del seleccionador de lenguaje
    public void RightArrow()
    {
        //Se suma 1 al contador
        i++;

        //Si sobre pasa 1 se regresa a 0 (Para que cuando llegue a la ultima opcion y vuelva a dar
        //flecha derecha, se regrese a la primera opcion)
        if(i > 1)
        {
            i = 0;
        }

        ChangeLanguague();
    }

    //Funcion que se utiliza en el boton de flecha izquierda del seleccionador de lenguaje
    public void LeftArrow()
    {
        //Se resta 1 al contador
        i--;

        //Si es menor que 0 se regresa a 1 (Para que cuando llegue a la primera opcion y vuelva a dar
        //flecha izquierda, se regrese a la ultima opcion)
        if (i < 0)
        {
            i = 1;
        }

        ChangeLanguague();
    }

    private void ChangeLanguague()
    {
        //Mediante un switch se define en que idioma esta el juego
        switch (i)
        {
            //Si i=0 esta en idioma español
            case 0:
                //Se cambia el texto de la caja de lenguaje a "ESPAÑOL" y el idioma
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Spanish");
                languageText.text = "ESPAÑOL";
                PlayerPrefs.SetInt("LanguageSelected", 0);
                break;
            //Si i=1 esta en idioma ingles
            case 1:
                //Se cambia el texto de la caja de lenguaje a "INGLES" y el idioma
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("English");
                languageText.text = "ENGLISH";
                PlayerPrefs.SetInt("LanguageSelected", 1);
                break;
        }
    }
}
