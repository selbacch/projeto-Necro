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
    public GameObject objDialogoCena;

    private float timeScale;
    private Player player;
    public bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {

        timeScale = Time.timeScale;
        FecharMenus();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.DeathEvent += AbrirMenuMorte;

    }

    private void OnDestroy()
    {
        player.DeathEvent -= AbrirMenuMorte;
    }

    public void AbrirMenuPause()
    {
        this.FecharMenus();
        menuPause.SetActive(true);
        panelEscureBackground.SetActive(true);
        Time.timeScale = 0;
        isOpen = true;
    }

    public void AbrirMenuMorte()
    {
        this.FecharMenus();
        Time.timeScale = 0;
        menuMorte.SetActive(true);
        panelEscureBackground.SetActive(true);
        isOpen = true;
    }

    public void FecharMenus()
    {
        menuMorte.SetActive(false);
        menuPause.SetActive(false);
        componenteInventario.SetActive(false);
        objDialogoCena.SetActive(false);

        panelEscureBackground.SetActive(false);
        Time.timeScale = this.timeScale;
        isOpen = false;

    }
    public void AbrirInventario()
    {
       
        if (!componenteInventario.activeSelf)
        {
            this.FecharMenus();
            isOpen = true;
            Time.timeScale = 0;
            componenteInventario.SetActive(true);
            InventarioUIController.Instance.RenderizaInventario();
        }
        else
        {
            this.FecharMenus();
        }

    }

    public void AbriDialogo()
    {
        
        if (!objDialogoCena.activeSelf)
        {
            this.FecharMenus();
            objDialogoCena.SetActive(true);
        }
        else
        {
            this.FecharMenus();
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
        InventarioUIController.Instance.RenderizaInventario();
    }

    public void RegarregarCena()
    {
        CenaController.Instance.RecarregarCenaEmCasoMorte();
    }

    public void IrParaMenuPrincipal()
    {
       // GameObject[] gos = GameObject.FindGameObjectsWithTag("Controladores");

//        foreach (GameObject g in gos)
  //      {
    //        Destroy(g);
      //  }

        SceneManager.LoadScene("IN_menu_inicial");
    }

}
