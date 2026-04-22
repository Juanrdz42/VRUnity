using UnityEngine;
using TMPro;

public class Intro : MonoBehaviour
{
    public TextMeshProUGUI textoUI;
    public GameObject canvas;

    [TextArea(3,10)]
    public string[] secciones;

    public float tiempoPorSeccion = 6f;

    private int indice = 0;

    void Start()
    {
        StartCoroutine(MostrarNarrativa());
    }

    System.Collections.IEnumerator MostrarNarrativa()
    {
        while (indice < secciones.Length)
        {
            textoUI.text = secciones[indice];
            yield return new WaitForSeconds(tiempoPorSeccion);
            indice++;
        }


        canvas.SetActive(false);
    }
}
