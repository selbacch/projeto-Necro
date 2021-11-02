using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HouseAnimacaoFloresta : MonoBehaviour
{

    public GameObject AnimacaoFloresta;
    public GameObject  Esclamacao;
    public GameObject Ashihara;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual IEnumerator StopPlayer(GameObject Player)
    {
        yield return new WaitForSeconds(7f);
        Player.GetComponent<PlayerInput>().actions.Enable();
        AnimacaoFloresta.SetActive(false);
        Ashihara.SetActive(true);
        Ashihara.GetComponent< FraseDoAshihara>().frase = " seria bom ir dar uma olhada... um fantasma fugindo de seres das sombras mascarados pode ser alguma coisa";
        Destroy(this, 8);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            other.GetComponent<PlayerInput>().actions.Disable();
            AnimacaoFloresta.SetActive(true);
            Esclamacao.SetActive(true);
            StartCoroutine(StopPlayer(other.gameObject));
        }
    }




}