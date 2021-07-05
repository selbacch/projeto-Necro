using UnityEngine;

public class entradaefect : MonoBehaviour
{
    public Material invisivel;
    public Material runa;
    public GameObject quadrado;
    public ParticleSystem particule;


    // Start is called before the first frame update


    void entra()
    {
        quadrado.GetComponent<Renderer>().material = runa;

    }

    void sai()
    {
        quadrado.GetComponent<Renderer>().material = invisivel;
        gameObject.GetComponent<Zombi>().IA = true;
        particule.Stop();
    }

}
