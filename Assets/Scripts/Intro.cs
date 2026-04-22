using UnityEngine;
using TMPro;
using System.Collections;

public class Intro : MonoBehaviour
{
    public TextMeshProUGUI textoUI;
    public GameObject canvas;

    [TextArea(3,10)]
    public string[] secciones;

    public float tiempoEntreLetras = 0.03f; // 👈 velocidad del texto
    public float pausaEntreSecciones = 2f;

    private int indice = 0;

    void Start()
    {
        canvas.SetActive(true);
        StartCoroutine(MostrarNarrativa());
    }

    IEnumerator MostrarNarrativa()
    {
        while (indice < secciones.Length)
        {
            yield return StartCoroutine(EscribirTexto(secciones[indice]));
            yield return new WaitForSeconds(pausaEntreSecciones);
            indice++;
        }

        canvas.SetActive(false);
    }

    IEnumerator EscribirTexto(string texto)
    {
        textoUI.text = "";

        foreach (char letra in texto)
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(tiempoEntreLetras);
        }
    }
}