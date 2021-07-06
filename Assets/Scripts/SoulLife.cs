using System;
using System.Collections;
using UnityEngine;


public class SoulLife : MonoBehaviour
{

    public SoulArea AreaIdentifica;
    public SoulLibera AreaLibera;
    public int Nvida;
    
    // Start is called before the first frame update
    void Start()
    {
        AreaIdentifica.PlayerEntrouSoul += PlayerEntrouSoulArea;
        AreaLibera.PlayerEntrouLibera += PlayerEntrouLiberaArea;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void hunt(Transform life)
    {

    }
    void Libera(Transform life)
    {

       life.GetComponent<Health>().Increase(Nvida);
    }


    void PlayerEntrouSoulArea(GameObject go)
    {
        hunt(go.transform);
    }

    void PlayerEntrouLiberaArea(GameObject go)
    {
        Libera(go.transform);
    }


}
