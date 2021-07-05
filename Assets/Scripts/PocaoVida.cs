using UnityEngine;

public class PocaoVida : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void usar()
    {
        Destroy(gameObject, 0f);
        // player.GetComponent<Health>().curHealth = +50; // adiciona mais 50 de vida
    }




}
