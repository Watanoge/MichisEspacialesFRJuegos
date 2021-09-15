//Este script se debe poner en el GameObject del boton que se usara para cambiar la escena

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneButton : MonoBehaviour
{
    //Variable donde se escribe el nombre de la escena que se quiere cargar con el botón
    public string sceneToLoad;
    //Imagen que servira de transición entre escenas
    public Image sceneTransition;
    //Valor alfa del color del material la imagen de transición
    private float alphaValue;
    //El GameObject del Sound Manager de cada escena
    public AudioSource soundManager;
    //Variable que se utiliza para guardar el volumen actual de la musica
    private float musicVolume;

    //Función a la que se llama al presionar el botón para cambiar de escena
    public void ChangeScene()
    {
        //Si no existe un sound manager en la escena ignora esta parte
        if (soundManager != null)
        {
            //Se guarda el valor del volumen actual de la musica en la variable "musicVolume"
            musicVolume = soundManager.volume;
            //Comienza la corutina de la transicion de la musica para cambiar de escena
            StartCoroutine(QuitMusicCoroutine());
        }

        //Comienza la corutina de la transicion de la imagen para cambiar de escena
        StartCoroutine(ChangeSceneCoroutine());
    }

    //Corutina de transicion para quitar la musica
    private IEnumerator QuitMusicCoroutine()
    {
        //Mientras el volumen de la musica sea mayor o igual a 0 se ejecuta esta parte
        while (soundManager.volume >= 0)
        {
            //Se disminuye el valor de "musicVolume" poco a poco con una velocidad de 0.3
            musicVolume -= Time.deltaTime * 0.3f;
            //Se iguala el valor de "musicVolume" con el volumen real de la musica
            soundManager.volume = musicVolume;

            yield return null;
        }
    }

    //Corutina de transicion para aumentar el alfa de la imagen
    private IEnumerator ChangeSceneCoroutine()
    {
        //Se activa el raycastTarget de la imagen para que, una vez presionado el boton
        //no se pueda presionar ningun otro boton sobre la pantalla
        sceneTransition.raycastTarget = true;

        //Mientras el alfa del color del material de la imagen sea menor o igual a 1 se ejecuta esta parte
        while(sceneTransition.material.color.a <= 1)
        {
            //Se aumenta el valor de "alphaValue" poco a poco con una velocidad de 2
            alphaValue += Time.deltaTime * 2;
            //Se crea una variable temporal para almacenar el color del material de la imagen
            var tempColor = sceneTransition.material.color;
            //Se iguala el valor alfa de la variable temporal al valor de "alphaValue"
            tempColor.a = alphaValue;
            //Se iguala el color del material de la imagen al de la variable temporal
            sceneTransition.material.color = tempColor;

            yield return null;
        }

        //Espera 1 segundo
        yield return new WaitForSeconds(1f);
        
        //Carga la escena indicada en el editor
        SceneManager.LoadScene(sceneToLoad);
    }
}
