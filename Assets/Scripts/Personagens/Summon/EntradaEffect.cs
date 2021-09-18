using UnityEngine;

public class EntradaEffect : MonoBehaviour
{
    public Material invisivel;
    public Material runa;
    public ParticleSystem particule;
    public GameObject square;

    // Start is called before the first frame update


    void entra()
    {
      square.GetComponent<Renderer>().material = runa;
        ;

    }

    void sai()
    {
       square.GetComponent<Renderer>().material = invisivel;
        gameObject.GetComponent<Zombie>().IA = true;
        particule.GetComponent<ParticleSystem>().Stop();
    }

}
