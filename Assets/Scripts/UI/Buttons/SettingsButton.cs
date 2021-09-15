//Este script se coloca en el GameObject de UIManager

using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [Header("Initial menu components")]
    //Variable que contiene el GameObject del menu inicial
    [SerializeField] private GameObject initialMenu;
    //Se guardan los componentes del menu por separado para poder animarlos individualmente
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject botonConfiguracion;
    [SerializeField] private GameObject botonJugar;
    [SerializeField] private GameObject botonTienda;
    [SerializeField] private GameObject botonCalificanos;
    //Estas variables guardaran las posiciones iniciales de los componentes en el canvas
    private Vector2 logoPosition;
    private Vector2 botonConfiguracionPosition;
    private Vector2 botonJugarPosition;
    private Vector2 botonTiendaPosition;
    private Vector2 botonCalificanosPosition;

    [Header("Settings menu components")]
    //Variable que contiene el GameObject del menu de configuracion
    [SerializeField] private GameObject settingsMenu;
    //Se guardan los componentes del menu por separado para poder animarlos individualmente
    [SerializeField] private GameObject cuadroDeCofiguracion;
    [SerializeField] private GameObject botonAtras;
    [SerializeField] private CanvasGroup panel;
    //Estas variables guardaran las posiciones iniciales de los componentes en el canvas
    private Vector2 cuadroDeConfiguracionPosition;
    private Vector2 botonAtrasPosition;

    [Header("Canvas principal")]
    //Variable que contiene el canvas
    [SerializeField] private Canvas canvasMenus;

    //Iniciando la escena se guardan las posiciones de los componentes
    private void Start()
    {
        logoPosition = logo.GetComponent<RectTransform>().localPosition;
        botonConfiguracionPosition = botonConfiguracion.GetComponent<RectTransform>().localPosition;
        botonJugarPosition = botonJugar.GetComponent<RectTransform>().localPosition;
        botonTiendaPosition = botonTienda.GetComponent<RectTransform>().localPosition;
        botonCalificanosPosition = botonCalificanos.GetComponent<RectTransform>().localPosition;
        cuadroDeConfiguracionPosition= cuadroDeCofiguracion.GetComponent<RectTransform>().localPosition;
        botonAtrasPosition = botonAtras.GetComponent<RectTransform>().localPosition;
    }
    //Funcion que empieza la animacion para abrir el menu de configuracion
    public void OpenSettingsMenu()
    {
        //Se desactiva el raycaster para que no se puedan presionar mas botones
        canvasMenus.GetComponent<GraphicRaycaster>().enabled = false;
        //El logo se manda al fondo de la pantalla
        logo.LeanMoveLocalY(-Screen.currentResolution.height, 1f).setEaseInOutExpo();
        //Los botones se mandan a los lados, con un delay diferente cada uno para darle un mejor aspecto
        //a la animacion
        botonConfiguracion.LeanMoveLocalX(Screen.currentResolution.width, 1f).setEaseInOutExpo().setDelay(0.3f);
        botonJugar.LeanMoveLocalX(-Screen.currentResolution.width, 1f).setEaseInOutExpo().setDelay(0.3f);
        botonTienda.LeanMoveLocalX(-Screen.currentResolution.width, 1f).setEaseInOutExpo().setDelay(0.5f);
        botonCalificanos.LeanMoveLocalX(-Screen.currentResolution.width, 1f).setEaseInOutExpo().setDelay(0.7f).setOnComplete(AnimationOpenSettingsMenuComplete);
        //Al terminar la ultima animacion se llama a la funcion para aparecer el menu de configuracion
    }

    private void AnimationOpenSettingsMenuComplete()
    {
        //Se desactiva el menu inicial
        initialMenu.SetActive(false);
        //Se activa el menu de configuracion
        settingsMenu.SetActive(true);
        //Se manda el cuadro de configuracion al fondo de la pantalla
        cuadroDeCofiguracion.GetComponent<RectTransform>().localPosition = new Vector2(0, -Screen.currentResolution.height);
        //El cuadro de configuracion realiza una animacion de subir
        cuadroDeCofiguracion.GetComponent<RectTransform>().LeanMoveLocalY(cuadroDeConfiguracionPosition.y, 0.7f).setEaseInOutExpo();
        //El boton de atras se manda a la derecha de la pantalla
        botonAtras.GetComponent<RectTransform>().localPosition = new Vector2(-Screen.currentResolution.width, botonAtrasPosition.y);
        //El boton de atras realiza la animacion de aparecer desde la derecha
        botonAtras.GetComponent<RectTransform>().LeanMoveLocalX(botonAtrasPosition.x, 1f).setEaseInOutExpo().setDelay(0.3f).setOnComplete(ActivateGraphicRayCasterCanvas);
        //El alpha del panel se hace 0 para que empiece invisible
        panel.alpha = 0;
        //El panel se aparece con una animacion
        panel.LeanAlpha(1f, 0.5f);
    }

    //Funcion que empieza la animacion para cerrar el menu de configuracion
    public void CloseSettingsMenu()
    {
        //Se desactiva el raycaster para que no se puedan presionar mas botones
        canvasMenus.GetComponent<GraphicRaycaster>().enabled = false;
        //El cuadro de configuracion se manda al fondo de la pantalla
        cuadroDeCofiguracion.GetComponent<RectTransform>().LeanMoveLocalY(-Screen.currentResolution.height, 1f).setEaseInOutExpo();
        //El panel se vuelve invisible
        panel.LeanAlpha(0, 0.5f);
        //El boton atras se manda a la derecha de la pantalla
        botonAtras.GetComponent<RectTransform>().LeanMoveLocalX(-Screen.currentResolution.width, 1f).setEaseInOutExpo().setDelay(0.3f).setOnComplete(AnimationCloseSettingsMenuComplete);
    }

    private void AnimationCloseSettingsMenuComplete()
    {
        //Se activa el menu incial
        initialMenu.SetActive(true);
        //Se realiza la animacion de subir el logo
        logo.LeanMoveLocalY(logoPosition.y, 1f).setEaseInOutExpo();
        //Los botones aparecen poco a poco en la pantalla
        botonConfiguracion.LeanMoveLocalX(botonConfiguracionPosition.x, 1f).setEaseInOutExpo().setDelay(0.3f);
        botonJugar.LeanMoveLocalX(botonJugarPosition.x, 1f).setEaseInOutExpo().setDelay(0.3f);
        botonTienda.LeanMoveLocalX(botonTiendaPosition.x, 1f).setEaseInOutExpo().setDelay(0.5f);
        botonCalificanos.LeanMoveLocalX(botonCalificanosPosition.x, 1f).setEaseInOutExpo().setDelay(0.7f).setOnComplete(ActivateGraphicRayCasterCanvas); ;
        //Se desactiva el menu de configuracion
        settingsMenu.SetActive(false);
    }

    private void ActivateGraphicRayCasterCanvas()
    {
        //Se reactiva el raycaster
        canvasMenus.GetComponent<GraphicRaycaster>().enabled = true;
    }
}
