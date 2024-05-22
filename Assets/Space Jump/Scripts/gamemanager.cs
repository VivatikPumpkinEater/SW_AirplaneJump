using UnityEngine;
using System.Collections;
using SAJ.Scripts;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public GameObject menuPanel;

    public AudioClip gameoverSound;
    public GameObject player1;
    public GameObject player2;

    public int gametype;

    public GameObject[] level;
    public static int levelnumber = 0;

    private static int deadcount = 0;

    public bool isgameover = false;
    private bool isgameovershowed = false;

    private Vector3 lastlevelpos;

    void Start()
    {
        Application.targetFrameRate = 60;

        gametype = PlayerPrefs.GetInt("game", 1);

        var temp = Instantiate(level[levelnumber], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

        lastlevelpos = temp.transform.position;


        if (gametype == 1)
        {
            player1.SetActive(true);
            player2.SetActive(false);
        }
        else
        {
            player1.SetActive(false);
            player2.SetActive(true);
        }
    }


    void Update()
    {
        if (isgameover && !isgameovershowed)
        {
            isgameovershowed = true;

            deadcount++;

            if (deadcount >= 1)
                ShowGameover();

            else
                Invoke("renewlevel", 2);
        }
    }

    IEnumerator PrepareMenu()
    {
        if (SAJStatic.SAJSound)
            AudioSource.PlayClipAtPoint(gameoverSound, gameObject.transform.position);
        yield return new WaitForSeconds(0.5f);

        menuPanel.SetActive(true);
    }

    public void ShowGameover()
    {
        deadcount = 0;

        StartCoroutine(PrepareMenu());
    }


    public void renewlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void backtohome()
    {
        SceneManager.LoadScene("start");
    }

    public void createnextlevel()
    {
        levelnumber++;

        if (levelnumber >= level.Length)
            levelnumber = Random.Range(0, level.Length);
        var nextlevelpos = new Vector3(lastlevelpos.x, lastlevelpos.y, lastlevelpos.z + 130);
        var temp = Instantiate(level[levelnumber], nextlevelpos, Quaternion.identity) as GameObject;
        lastlevelpos = temp.transform.position;
    }
}