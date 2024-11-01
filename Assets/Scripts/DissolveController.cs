using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public Material dissolveMaterial; // Asigna tu material con efecto dissolve
    public float dissolveSpeed = 1.0f; // Velocidad del efecto

    private float cutoffHeight = 0f; // Valor inicial del Cutoff Height
    private bool increasing = true; // Controla si el valor está aumentando o disminuyendo

    void Start()
    {
        // Inicializa el valor del Cutoff Height
        dissolveMaterial.SetFloat("_CutoffHeight", cutoffHeight);
    }

    void Update()
    {
        // Cambia el valor de Cutoff Height en función de la dirección actual
        if (increasing)
        {
            cutoffHeight += Time.deltaTime * dissolveSpeed;
            if (cutoffHeight >= 1f)
            {
                cutoffHeight = 1f;
                increasing = false; // Cambia de dirección cuando llega al límite superior
            }
        }
        else
        {
            cutoffHeight -= Time.deltaTime * dissolveSpeed;
            if (cutoffHeight <= 0f)
            {
                cutoffHeight = 0f;
                increasing = true; // Cambia de dirección cuando llega al límite inferior
            }
        }

        // Actualiza el parámetro en el material
        dissolveMaterial.SetFloat("_CutoffHeight", cutoffHeight);
    }
}
