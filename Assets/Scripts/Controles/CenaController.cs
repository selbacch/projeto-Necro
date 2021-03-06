using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CenaController : MonoBehaviour
{
    public enum TrocaCena { PORTAL, MORTE, MUDANCA_FASE, INICIO_JOGO, CONTINUAR_JOGO }
    public TrocaCena motivo;
    public static CenaController Instance;
    public InfoSessao infoSessao;
    private bool EhTrocaCenaPortal = false;
    private string IdPortalDestino = null;
    private Player player;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        infoSessao = new InfoSessao();
        DontDestroyOnLoad(this.gameObject);
        motivo = TrocaCena.INICIO_JOGO;
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
        SalvarJogo();
        SceneManager.LoadScene(portal.nomeCenaDestino);
        EhTrocaCenaPortal = true;
        IdPortalDestino = portal.idPortalDestino;
        motivo = TrocaCena.PORTAL;
    }

    public void SalvarJogo()
    {
        infoSessao.SalvaStatusJogo();

    }

    public void CarregarJogoSalvo()
    {
        infoSessao.CarregarStatusJogo();
    }

    public void RecarregarCenaEmCasoMorte()
    {
        motivo = TrocaCena.MORTE;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        Debug.Log("OnSceneLoaded: " + scene.name + " motivo: " + motivo);
        Time.timeScale = 1;
        Regex rx_interacao = new Regex(@"\bIN_*");
        Regex rx_cutScene = new Regex(@"\bCS_*");
        if (rx_interacao.IsMatch(scene.name) || rx_cutScene.IsMatch(scene.name))
        {
            if (scene.name.Equals("CS_HistoryOfSword"))
            {
                motivo = TrocaCena.INICIO_JOGO;
            }
            return;
        }

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        switch (motivo)
        {
            case TrocaCena.PORTAL:
                EhTrocaCenaPortal = false;
                GameObject portal = GameObject.Find(IdPortalDestino);
                portal.GetComponent<PortalControle>().PosicionarPersonagemSpawnPoint();
                player.Vida.SetMaxHealth(infoSessao.vidaMax);
                player.Mana.SetMaxMana(infoSessao.manaMax);

                player.Vida.SetCurrentHealth(infoSessao.vidaAtual);
                player.Mana.SetCurrMana(infoSessao.vidaAtual);
                break;
            case TrocaCena.MUDANCA_FASE:
                player.Vida.SetMaxHealth(infoSessao.vidaMax);
                player.Mana.SetMaxMana(infoSessao.manaMax);

                player.Vida.SetCurrentHealth(infoSessao.vidaAtual);
                player.Mana.SetCurrMana(infoSessao.vidaAtual);
                break;
            case TrocaCena.CONTINUAR_JOGO:
                CarregarJogoSalvo();
                player.Vida.SetMaxHealth(infoSessao.vidaMax);
                player.Mana.SetMaxMana(infoSessao.manaMax);

                player.Vida.SetCurrentHealth(infoSessao.manaMax);
                player.Mana.SetCurrMana(infoSessao.manaMax);
                break;
            case TrocaCena.MORTE:
                player.Vida.SetMaxHealth(infoSessao.vidaMax);
                player.Mana.SetMaxMana(infoSessao.manaMax);

                player.Vida.SetCurrentHealth(infoSessao.manaMax);
                player.Mana.SetCurrMana(infoSessao.manaMax);
                CheckpointController ck = CheckpointController.EncontrarUltimoCheckpointAtivo();
                if (ck != null)
                {
                    ck.PosicionaPlayer();
                }

                break;
            case TrocaCena.INICIO_JOGO:
            default:
                player.Vida.SetMaxHealth(ConstantesPersonagens.BASE_VIDA_MAX_HIPATIA);
                player.Vida.SetCurrentHealth(ConstantesPersonagens.BASE_VIDA_MAX_HIPATIA);

                player.Mana.SetMaxMana(ConstantesPersonagens.BASE_MANA_MAX_HIPATIA);
                player.Mana.SetCurrMana(ConstantesPersonagens.BASE_MANA_MAX_HIPATIA);
                break;
        }

        // InventarioController.Instance.FromJson(infoSessao.inventario);
        InventarioController.Instance.ReequiparMascara();
        CenaController.Instance.SalvarJogo();

        motivo = TrocaCena.CONTINUAR_JOGO;
    }

    void OnSceneUnloaded(Scene scene)
    {

        SalvarJogo();
    }
}
