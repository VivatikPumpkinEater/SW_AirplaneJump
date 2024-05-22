using SAJ.Scripts;
using Space_Jump;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    [SerializeField] private SAJTrig SAJEasyMode;
    [SerializeField] private SAJTrig SAJHardMode;
    public Text bestscore;

    public AudioClip clickSound;

    private int best;

    void Start()
    {
        best = PlayerPrefs.GetInt("best", 0);
        bestscore.text = "Best: " + best.ToString() + "m";

        SAJEasyMode.SAJONTrig += loadgame1;
        SAJHardMode.SAJONTrig += loadgame2;
    }

    public void loadgame1()
    {
        if (SAJStatic.SAJSound)
            AudioSource.PlayClipAtPoint(clickSound, gameObject.transform.position);

        PlayerPrefs.SetInt("game", 1);
        SceneManager.LoadScene("gamescene");
    }

    public void loadgame2()
    {
        if (SAJStatic.SAJSound)
            AudioSource.PlayClipAtPoint(clickSound, gameObject.transform.position);
        PlayerPrefs.SetInt("game", 2);
        SceneManager.LoadScene("gamescene");
    }
}