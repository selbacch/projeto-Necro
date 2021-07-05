using UnityEngine;

public class PocaoMana : MonoBehaviour
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
        // player.GetComponent<Mana>().curMana = +2; // adiciona mais 2 de mana
    }


}
