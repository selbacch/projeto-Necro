using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ShowTExtTuTo : MonoBehaviour
{
    public float time;
    public TMP_Text texto;
    public GameObject Ashihara;
    public MenuFaseController menu;
    public string[] txt;
    private int Dialogo =0;
    private float timeScale;
    private GameObject Player;
    // Start is called before the first frame update
    private void Awake()
    {
        TextAsset txtAsset = Resources.Load<TextAsset>("Dialogos/Tutorial");
        txt = txtAsset.text.Split(';');
    }




    void Start()
    {
        timeScale = Time.timeScale;
    
    }

    // Update is called once per frame
    void Update()
    {
        
        Time.timeScale = this.timeScale;
    }

    IEnumerator Mtxt()
    {
        if (txt.Length >= 0)
        {

            for (Dialogo = 0; Dialogo < txt.Length; Dialogo++)
            {
                texto.text = txt[Dialogo];
               // Ashihara.GetComponent<FraseDoAshihara>().frase = txt[Dialogo];
                yield return new WaitForSecondsRealtime(8f);
            }

        }

        Player.GetComponent<PlayerInput>().actions.Enable();
        menu.AbrirStatus();
        Destroy(this);
    }

    IEnumerator Ativa(float Times)
    {
        
        yield return new WaitForSeconds(Times);
        
       
        StartCoroutine(Mtxt());
    }



    private void OnTriggerEnter2D(Collider2D other)
    {



        if (other.tag == "Player")
        {
            
            Ashihara.SetActive(true);
            
            StartCoroutine(Ativa(time));
            Player = other.gameObject;
            Player.GetComponent<PlayerInput>().actions.Disable();



        }

    }


}
