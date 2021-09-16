using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaxFPS : MonoBehaviour
{
    void Awake()
    {
        // Original:
        //Application.targetFrameRate = 60;
        
        //Nuevo:
        Application.targetFrameRate = Screen.currentResolution.refreshRate;

        /*
        Excelente práctica limtiar los FPS, así evitas procesamiento de más. Sin embargo, 
        no todos los dispositivos llegan a los 60 (algunos incluso lo superan)
        
        Con el coso que puse arriba, en cualquier dispositivo te regresa la cantidad de frames
        que soporta la pantalla (ya sea monitor de PC, teléfono o incluso TV; de igual
        manera suelta la resolución exacta)

        Documentación: https://docs.unity3d.com/ScriptReference/Screen-currentResolution.html
        */
    }
}
