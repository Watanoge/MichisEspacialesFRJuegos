//Este script se debe poner en el GameObject de UIManager

using UnityEngine;
using UnityEngine.UI;

public class CreditsButton : MonoBehaviour
{
    [Header("Settings menu components")]
    //Variable que contiene el GameObject del menu de configuracion
    [SerializeField] private GameObject settingsMenu;
    //Se guarda el componente para animarlo
    [SerializeField] private GameObject cuadroDeConfiguracion;
    //Variable que guardara la posicion inicial
    private Vector2 cuadroDeConfiguracionPosition;

    [Header("Credits menu components")]
    //Variable que contiene el GameObject del menu de creditos
    [SerializeField] private GameObject creditsMenu;
    //Se guarda el componente para animarlo
    [SerializeField] private GameObject creditosScrollView;
    //Variable que guardara la posicion inicial
    private Vector2 creditosScrollViewPosition;
    [Header("Canvas")]
    //Variable que contiene el canvas
    [SerializeField] private Canvas canvasMenus;

    //Se guardan las posiciones iniciales respectivamente
    private void Start()
    {
        cuadroDeConfiguracionPosition = cuadroDeConfiguracion.GetComponent<RectTransform>().localPosition;
        creditosScrollViewPosition = creditosScrollView.GetComponent<RectTransform>().localPosition;
    }

    //Funcion que inicia la animacion para abrir el menu de creditos
    public void OpenCreditsMenu()
    {
        //Se desactiva el raycaster para que no se puedan presionar mas botones
        canvasMenus.GetComponent<GraphicRaycaster>().enabled = false;
        //Se manda hasta abajo de la pantalla el cuadro de configuracion
        cuadroDeConfiguracion.LeanMoveLocalY(-Screen.currentResolution.height, 1f).setEaseInOutExpo().setOnComplete(AnimationOpenCreditsMenuComplete);
    }
    private void AnimationOpenCreditsMenuComplete()
    {
        //Se desactiva el menu inicial
        settingsMenu.SetActive(false);
        //Se activa el menu de configuracion
        creditsMenu.SetActive(true);
        //El menu de creditos aparece hasta abajo de la pantalla
        creditosScrollView.GetComponent<RectTransform>().localPosition = new Vector2(0, -Screen.currentResolution.height);
        //Se sube el menu de creditos con una animacion
        creditosScrollView.GetComponent<RectTransform>().LeanMoveLocalY(creditosScrollViewPosition.y, 0.7f).setEaseInOutExpo().setOnComplete(ActivateGraphicRayCasterCanvas); ;
    }


    //Funcion que inicia la animacion para cerrar el menu de creditos
    public void CloseCreditsMenu()
    {
        //Se desactiva el raycaster para que no se puedan presionar mas botones
        canvasMenus.GetComponent<GraphicRaycaster>().enabled = false;
        //Se manda el menu de creditos hasta abajo de la pantalla
        creditosScrollView.GetComponent<RectTransform>().LeanMoveLocalY(-Screen.currentResolution.height, 1f).setEaseInOutExpo().setOnComplete(AnimationCloseSettingsMenuComplete);
    }

    private void AnimationCloseSettingsMenuComplete()
    {
        //Se activa el menu incial
        settingsMenu.SetActive(true);
        //Se aparece el cuadro de configuracion hasta abajo de la pantalla
        cuadroDeConfiguracion.GetComponent<RectTransform>().localPosition = new Vector2(0, -Screen.currentResolution.height);
        //Se manda hacia arriba mediante una animacion
        cuadroDeConfiguracion.LeanMoveLocalY(cuadroDeConfiguracionPosition.y, 0.7f).setEaseInOutExpo().setOnComplete(ActivateGraphicRayCasterCanvas);
        //Se desactiva el menu de creditos
        creditsMenu.SetActive(false);
    }

    private void ActivateGraphicRayCasterCanvas()
    {
        //Se reactiva el raycaster
        canvasMenus.GetComponent<GraphicRaycaster>().enabled = true;
    }
}
