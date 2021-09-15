//Este script se coloca en el GameObject de Scene transition image
//Este script se ejecutara siempre que se inicie una escena donde se contenga el script

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    //Variable que contiene la imagen que se utilizara para la transicion de escena
    private Image sceneTransition;
    //Valor alfa de la imagen
    private float alphaValue;
    //Variable que contiene el GameObject del "soundManager" para la transicion de musica
    public AudioSource soundManager;
    //Variable que define el volumen maximo al que llegara la musica
    [Range(0, 1)]
    public float maxVolume;
    //Variable que guardara el volumen de la musica
    private float musicVolume;

    void Awake()
    {
        //Se obtiene el componente imagen del GameObject Scene transition image
        sceneTransition = GetComponent<Image>();

        //Se detecta si se activo la escena
        SceneManager.sceneLoaded += OnSceneLoaded;

        //Si existe el GameObject del "soundManager" se ejecuta esta parte
        if (soundManager != null)
        {
            //Se define el volumen de la musica en 0
            soundManager.volume = 0;
        }
    }

    //Se cargo la escena
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Si el alfa del material de la imagen es mayor que 0 se realiza la corutina de transicion
        if(sceneTransition.material.color.a > 0)
        {
            //La variable "alphaValue" se iguala al alfa del color del material de la imagen
            alphaValue = sceneTransition.material.color.a;
            StartCoroutine(OpenSceneTransitionCoroutine());
        }

        //Si existe un "soundManager" se ejecuta la corutina de transicion de sonido
        if (soundManager != null)
        {
            StartCoroutine(StartMusicCoroutine());
        }
    }

    //Esta corutina va aumentando el volumen de la musica poco a poco
    private IEnumerator StartMusicCoroutine()
    {
        //Mientras el volumen de la musica sea menor que el volumen maximo se ejecuta esta parte
        while(soundManager.volume < maxVolume)
        {
            //Se aumenta la variablr de "musicVolume" poco a poco con una velocidad de 0.3
            musicVolume += Time.deltaTime * 0.3f;
            //Se iguala el volumen de la musica con la variable "musicVolume"
            soundManager.volume = musicVolume;

            yield return null;
        }
    }

    //Esta corutina va disminuyendo poco a poco
    private IEnumerator OpenSceneTransitionCoroutine()
    {
        //Se activa el raycastTarget para que no se pueda presionar otro boton
        sceneTransition.raycastTarget = true;

        //Se espera 1 segundo
        yield return new WaitForSeconds(1f);

        //Mientras el alfa del color del material de la imagen sea mayor que 0 se ejecuta esta parte
        while (sceneTransition.material.color.a > 0)
        {
            //Se va disminuyendo la variable alphaValue poco a poco con una velocidad de 2
            alphaValue -= Time.deltaTime * 2;
            //Se crea una variable temporal y se iguala al color del material de la imagen
            var tempColor = sceneTransition.material.color;
            //Se iguala el alfa de la variable temporal a la variable "alphaValue"
            tempColor.a = alphaValue;
            //Se iguala el color del material de la imagen a la variable temporal
            sceneTransition.material.color = tempColor;

            //Cuando la imagen sea menor o igual a 0 se ejecuta esta parte
            if (sceneTransition.material.color.a <= 0)
            {
                //El alfa de la variable temporal se hace 0
                tempColor.a = 0;
                //Se iguala el color del material de la imagen a la variable temporal
                sceneTransition.material.color = tempColor;
            }

            yield return null;
        }

        //Se desactiva el raycastTarget para que se pueda volver a presionar botones
        sceneTransition.raycastTarget = false;
    }

    //Se avisa que se desactivo la escena
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
