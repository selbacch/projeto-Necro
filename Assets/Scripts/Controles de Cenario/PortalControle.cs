using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class PortalControle : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject anim;
    public string idPortal;
    public string nomeCenaDestino;
    public string idPortalDestino;
    public string NomeCena { get; private set; }
    // Start is called before the first frame update

    private void Awake()
    {
       NomeCena = SceneManager.GetActiveScene().name;
        this.gameObject.name = idPortal; 
    }

    // Update is called once per frame
    public  string ObterNomeObjeto()
    {
        return this.gameObject.name;
    }

    public void PosicionarPersonagemSpawnPoint()
    {
        GameObject pl = GameObject.FindGameObjectWithTag("Player");
        pl.transform.position = spawnPoint.position;
    }
    void TrocaScena()
    {
    CenaController.Instance.PlayerEntrouPortal(this);
    }

    IEnumerator fade()
    {
        yield return new WaitForSeconds(0.51f);
        TrocaScena();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            anim.GetComponent<Animator>().SetTrigger("out");
            StartCoroutine(fade());
            
        }
        
    }

}
