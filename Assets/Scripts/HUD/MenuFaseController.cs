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

    private float timeScale;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        timeScale = Time.timeScale;
        FecharMenus();
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

        if (componenteInventario.activeSelf)
        {
            Time.timeScale = this.timeScale;
            componenteInventario.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            componenteInventario.SetActive(true);
            InventarioController.Instance.RenderizaInventario();
        }

    }
    public void OnInventario(InputValue value)
    {
        AbrirInventario();
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
