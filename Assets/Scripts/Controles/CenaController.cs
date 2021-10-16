using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CenaController : MonoBehaviour
{
    public static CenaController Instance;
    public InfoSessao infoSessao;
    private bool EhTrocaCenaPortal = false;
    private string IdPortalDestino = null;
    private Player player;

    private void Awake()
    {
        if (Instance)
        {
            Debug.Log("INSTANCE ALREADY IN SCENE! LET'S DESTROY OURSELVES!");
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        infoSessao = new InfoSessao();
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerEntrouPortal(GameObject player, string Cena, Vector3 positionE)
    {
        SceneManager.LoadScene(Cena);
    }

    public void PlayerEntrouPortal(PortalControle portal)
    {
        SceneManager.LoadScene(portal.nomeCenaDestino);
        EhTrocaCenaPortal = true;
        IdPortalDestino = portal.idPortalDestino;
    }

    public void SalvarJogo()
    {
        infoSessao.SalvaStatusJogo();

    }

    public void CarregarJogoSalvo()
    {
        infoSessao.CarregarStatusJogo();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);

        Regex rx = new Regex(@"\bIN_*");
        if (rx.IsMatch(scene.name))
        {
            return;
        }

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();



        if (EhTrocaCenaPortal)
        {
            EhTrocaCenaPortal = false;
            GameObject portal = GameObject.Find(IdPortalDestino);
            portal.GetComponent<PortalControle>().PosicionarPersonagemSpawnPoint();
            player.Vida.SetCurrentHealth(infoSessao.vidaAtual);
            player.Mana.SetCurrMana(infoSessao.vidaAtual);
            player.Vida.SetMaxHealth(infoSessao.vidaMax);
            player.Mana.SetMaxMana(infoSessao.manaMax);

        }
        else
        {
            if (infoSessao.dataHoraGravacao == null)
            {
                player.Vida.SetMaxHealth(1000);
                player.Mana.SetMaxMana(1000);
                player.Vida.SetCurrentHealth(1000);
                player.Mana.SetCurrMana(1000);
            }
            else
            {
                //player.Vida.SetMaxHealth(infoSessao.vidaMax);
                //player.Mana.SetMaxMana(infoSessao.manaMax);
                //player.Vida.SetCurrentHealth(infoSessao.manaMax);
                //player.Mana.SetCurrMana(infoSessao.manaMax);

                player.Vida.SetMaxHealth(1000);
                player.Mana.SetMaxMana(1000);
                player.Vida.SetCurrentHealth(1000);
                player.Mana.SetCurrMana(1000);

            }

        }

    }

    void OnSceneUnloaded(Scene scene)
    {

        SalvarJogo();
    }
}
