using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class PortalControle : MonoBehaviour
{
    public Transform spawnPoint;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CenaController.Instance.PlayerEntrouPortal(this);
    }

}