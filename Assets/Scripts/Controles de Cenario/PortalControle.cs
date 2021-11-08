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
    private float timeScale;
    public string NomeCena { get; private set; }
    // Start is called before the first frame update

    private void Awake()
    {
        NomeCena = SceneManager.GetActiveScene().name;
        this.gameObject.name = idPortal;
        timeScale = Time.timeScale;
    }

    // Update is called once per frame
    public string ObterNomeObjeto()
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
      
        Time.timeScale = 0;
        anim.GetComponent<Animator>().SetTrigger("out");
        yield return new WaitForSecondsRealtime(0.52f);
        TrocaScena();
        Time.timeScale = this.timeScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(fade());


        }

    }

}
