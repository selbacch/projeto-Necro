using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuFaseController : MonoBehaviour
{
    public GameObject menuPause;
    public GameObject menuMorte;
    public GameObject panelEscureBackground;
    public GameObject componenteInventario;
    public GameObject componenteStatus;
    
    public GameObject EventPause1;
    public GameObject EventMorte2;
    public GameObject EventInventario3;
    public GameObject EventStatus4;
    



    private float timeScale;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        timeScale = Time.timeScale;
        FecharMenus();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().DeathEvent += AbrirMenuMorte;
       
    }

    public void AbrirMenuPause()
    {
        EventPause1.SetActive(true);
        EventMorte2.SetActive(false);
        menuMorte.SetActive(false);
        menuPause.SetActive(true);
       panelEscureBackground.SetActive(true);
        Time.timeScale = 0;
        isOpen = true;
        
    }

    public void AbrirMenuMorte()
    {
        EventMorte2.SetActive(true);
        EventPause1.SetActive(false);
        Time.timeScale = 0;
        menuMorte.SetActive(true);
        menuPause.SetActive(false);
        panelEscureBackground.SetActive(true);
        isOpen = true;
    }

    public void FecharMenus()
    {
        menuMorte.SetActive(false);
        menuPause.SetActive(false);
        EventPause1.SetActive(false);
        EventMorte2.SetActive(false);
        panelEscureBackground.SetActive(false);
        Time.timeScale = this.timeScale;
        isOpen = false;
     
    }
    public void AbrirInventario()
    {
        this.FecharMenus();
        if (componenteInventario.activeSelf)
        {
            componenteInventario.SetActive(false);
            Time.timeScale = this.timeScale;
            EventInventario3.SetActive(false);
        }
        else
        {
            isOpen = true;
            EventInventario3.SetActive(true);
            Time.timeScale = 0;
            componenteInventario.SetActive(true);
            InventarioController.Instance.RenderizaInventario();
        }

    }

    public void AbrirStatus()
    { 
        this.FecharMenus();
        if (componenteStatus.activeSelf)
        {
            EventStatus4.SetActive(false);
            Time.timeScale = this.timeScale;
            componenteStatus.SetActive(false);
        }
        else
        {
            EventStatus4.SetActive(true);
            Time.timeScale = 0;
            componenteStatus.SetActive(true);

        }


    }
    public void teste()
    {
        Debug.Log("teste");
    }

    public void DesequiparMascaraButton()
    {
        Player pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        ItemInterface.Item mascaraAnterior = pl.EquiparMascara(ItemInterface.Item.None);

        InventarioController.Instance.AdicionarAoInventario(mascaraAnterior);
        InventarioController.Instance.RenderizaInventario();
    }

    public void OnInventario(InputValue value)
    {
        AbrirInventario();
        Debug.Log("select");
    }

    public void OnPause(InputValue value)
    {
        Debug.Log("Start");
        if (isOpen)
        {
            this.FecharMenus();
        }
        else
        {
            this.AbrirMenuPause();
        }

    }

    public void RegarregarCena(){
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }


}
