using UnityEngine.UI;
using UnityEngine;

public class MoverFondo : MonoBehaviour
{
    private RawImage fondoEstrellas;
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;

    private void Start()
    {
        fondoEstrellas = GetComponent<RawImage>();
    }
    void Update()
    {
        Rect newUIRect = fondoEstrellas.uvRect;
        newUIRect.x += Time.deltaTime * xSpeed;
        newUIRect.y += Time.deltaTime * ySpeed;
        fondoEstrellas.uvRect = newUIRect;
    }
}
