using UnityEngine;
using UnityEngine.SceneManagement;

public class CenaController : MonoBehaviour
{
    public static CenaController Instance;
    public InfoSessao infoSessao;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance)
        {
            Debug.Log("INSTANCE ALREADY IN SCENE! LET'S DESTROY OURSELVES!");
            Destroy(this.gameObject);
        }

        Instance = this;
        infoSessao = new InfoSessao();
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerEntrouPortal(GameObject player, string Cena)
    {
        SalvarJogo();
        SceneManager.LoadScene(Cena);
    }

    public void SalvarJogo()
    {
        infoSessao.SalvaStatusJogo();

    }

}
