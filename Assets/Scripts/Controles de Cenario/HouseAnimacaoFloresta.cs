using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class HouseAnimacaoFloresta : MonoBehaviour
{
    public TMP_Text texto;
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
    { Ashihara.SetActive(true);
        yield return new WaitForSeconds(7f);
        Player.GetComponent<PlayerInput>().actions.Enable();
        AnimacaoFloresta.SetActive(false);

        texto.text = "seria bom ir dar uma olhada... um fantasma fugindo de seres das sombras mascarados pode ser alguma coisa";
        Destroy(gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" )
        {
            if (!StageController.Instance.AddEvt("Anim_House_01"))
            {
                return;
            }
            other.GetComponent<PlayerInput>().actions.Disable();
            AnimacaoFloresta.SetActive(true);
            Esclamacao.SetActive(true);
            StartCoroutine(StopPlayer(other.gameObject));
        }
    }




}
