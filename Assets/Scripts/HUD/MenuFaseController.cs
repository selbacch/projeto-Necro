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
    public bool isOpen = false;
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
        componenteInventario.SetActive(false);
        objDialogoCena.SetActive(false);

        panelEscureBackground.SetActive(false);
        Time.timeScale = this.timeScale;
        isOpen = false;
        
    }
    public void AbrirInventario()
    {
       
        if (componenteInventario.activeSelf)
        {
            this.FecharMenus();
        }
        else
        {
            isOpen = true;
           
            Time.timeScale = 0;
            componenteInventario.SetActive(true);
            InventarioUIController.Instance.RenderizaInventario();
        }

    }

    public void AbriDialogo()
    { 
      
        if (objDialogoCena.activeSelf)
        {

            this.FecharMenus();
        }
        else
        {
          
          //  Time.timeScale = 0;
            objDialogoCena.SetActive(true);
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

  

    public void RegarregarCena(){
        CenaController.Instance.RecarregarCenaEmCasoMorte();
    }


}
