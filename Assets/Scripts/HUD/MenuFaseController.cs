using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MenuFaseController : MonoBehaviour
{
    public GameObject menuPause;
    public GameObject menuMorte;
    public GameObject panelEscureBackground;
    public GameObject componenteInventario;
    public GameObject componenteStatus;

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
        menuMorte.SetActive(false);
        menuPause.SetActive(true);
        panelEscureBackground.SetActive(true);
        Time.timeScale = 0;
        isOpen = true;
    }

    public void AbrirMenuMorte()
    {
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
        panelEscureBackground.SetActive(false);
        Time.timeScale = this.timeScale;
        isOpen = false;
    }
    public void AbrirInventario()
    {
        this.FecharMenus();
        if (componenteInventario.activeSelf)
        {
            Time.timeScale = this.timeScale;
            componenteInventario.SetActive(false);
        }
        else
        {
            isOpen = true;
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
            Time.timeScale = this.timeScale;
            componenteStatus.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            componenteStatus.SetActive(true);
            
        }


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
    }


    public void OnStatus(InputValue value)
    {
        AbrirStatus();
    }


    public void OnPause(InputValue value)
    {
        if (isOpen)
        {
            this.FecharMenus();
        }
        else
        {
            this.AbrirMenuPause();
        }


    }


}
