using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowTExtTuTo : MonoBehaviour
{
    public float time;
    public TMP_Text texto;
    public GameObject Ashihara;
    public MenuFaseController menu;
    public string[] txt;
    private int Dialogo = 0;
    private float timeScale;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Ativa(time));
    }

    IEnumerator Mtxt()
    {
        
        for (Dialogo = 0; Dialogo < txt.Length; Dialogo++)
        {
            Ashihara.GetComponent<FraseDoAshihara>().frase = txt[Dialogo];
            yield return new WaitForSecondsRealtime(4f);
        }
        Destroy(this, 20f);
    }

    IEnumerator Ativa(float Time)
    {
        yield return new WaitForSeconds(Time);
        GetComponent<EdgeCollider2D>().enabled = true;
        yield return new WaitForSeconds(2);
        StartCoroutine(Mtxt());
    }



    private void OnTriggerEnter2D(Collider2D other)
    {



        if (other.tag == "Player")
        {
            Ashihara.SetActive(true);
            

            
        }

    }


}
