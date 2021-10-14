using UnityEngine;
using UnityEngine.SceneManagement;

public class CenaController : MonoBehaviour
{
    public static CenaController Instance;
    public InfoSessao infoSessao;
    private bool EhTrocaCenaPortal = false;
    private string IdPortalDestino = null;

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
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerEntrouPortal(GameObject player, string Cena,Vector3 positionE)
    {
        SalvarJogo();
        SceneManager.LoadScene(Cena);
    }

    public void PlayerEntrouPortal(PortalControle portal)
    {
        SalvarJogo();
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
        Debug.Log(mode);

        if (EhTrocaCenaPortal)
        {
            EhTrocaCenaPortal = false;
            GameObject portal = GameObject.Find(IdPortalDestino);
            portal.GetComponent<PortalControle>().PosicionarPersonagemSpawnPoint();
        }

    }

}
