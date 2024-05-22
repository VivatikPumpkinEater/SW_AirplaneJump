using SAJ.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public GameObject fireparticle;
    public GameObject deepred;
    private gamemanager gamemanagerscript;

    private bool ifgrounded = true;
    private bool finish = false;
    public GameObject waveeffect;

    public AudioSource ColliderSound;
    public AudioClip groundedsound;
    public AudioClip jumpingsound;
    public AudioClip goalsound;
    public AudioClip gotonextsound;
    public GameObject ballparticles;
    private float timepadding;
    private float timelimit = 0;
    public Text score;
    private int finalz = 0;
    private int tempz = 0;

    private int gamescore;
    private int bestscore;
    private bool isgameovershowed = false;
    public GameObject deadeffect;
    public GameObject reachGoaleffect;

    void Start()
    {
        bestscore = PlayerPrefs.GetInt("best", 0);
        gamemanagerscript = GameObject.Find("GameManager").GetComponent<gamemanager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ifgrounded == true && finish == false)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            transform.SetParent(null);
            if (gamemanagerscript.gametype == 1)
                this.gameObject.GetComponent<Rigidbody>().AddForce(0, 220, 880);
            else
                this.gameObject.GetComponent<Rigidbody>().AddForce(0, 220, 1780);
            fireparticle.SetActive(true);
            ifgrounded = false;
            ColliderSound.clip = jumpingsound;
            if (SAJStatic.SAJSound)
                ColliderSound.Play();
        }

        if (finish == true)
        {
            transform.SetParent(null);
        }

        if (this.transform.position.y < -10)
        {
            Gameover();
        }

        if (ifgrounded == false && timelimit < 0.53f)
        {
            timelimit += Time.deltaTime;
            timepadding += Time.deltaTime;
            if (timepadding > 0.005)
            {
                timepadding = 0;
                ballparticlecreat();
            }
        }

        tempz = (int)(this.transform.position.z);
        if (tempz > finalz)
            finalz = tempz;

        gamescore = 10 * finalz;

        score.text = gamescore.ToString() + "m";
    }


    private void Gameover()
    {
        if (!isgameovershowed)
        {
            isgameovershowed = true;


            if (gamescore > bestscore)
            {
                bestscore = gamescore;
                PlayerPrefs.SetInt("best", bestscore);
            }

            Instantiate(deadeffect, gameObject.transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
            gamemanagerscript.isgameover = true;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().useGravity = false;
            collision.gameObject.tag = "passball";
            transform.SetParent(collision.transform);
            transform.position = collision.transform.position + new Vector3(0, 0.31f, 0);
            collision.gameObject.GetComponent<Renderer>().material =
                deepred.gameObject.GetComponent<Renderer>().material;
            Invoke("particledelay", 0.1f);
            ColliderSound.clip = groundedsound;
            ColliderSound.Play();
            ColliderSound.volume = 100;

            var shipwooglescript = collision.gameObject.GetComponent<ShipWoogle>();

            if (shipwooglescript != null)
            {
                shipwooglescript.stopmoving();
            }
        }

        if (collision.gameObject.tag == "terminalball" && !finish)
        {
            finish = true;

            Instantiate(reachGoaleffect, this.transform.position, Quaternion.identity);

            ColliderSound.clip = goalsound;
            ColliderSound.Play();

            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().useGravity = false;
            collision.gameObject.tag = "passball";
            transform.SetParent(collision.transform);
            transform.position = collision.transform.position + new Vector3(0, 0.31f, 0);
            collision.gameObject.GetComponent<Renderer>().material =
                deepred.gameObject.GetComponent<Renderer>().material;
            Invoke("particledelay", 0.1f);

            gamemanagerscript.createnextlevel();

            Invoke("playergotonextpoint", 1);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "stone")
        {
            Gameover();
        }
    }


    void particledelay()
    {
        fireparticle.SetActive(false);
        Invoke("groundeddelay", 0.05f);
    }

    void groundeddelay()
    {
        ifgrounded = true;
        timelimit = 0;
    }

    void playergotonextpoint()
    {
        iTween.MoveBy(this.gameObject, iTween.Hash("z", 50, "easeType", "easeInCirc", "time", 2));
        Invoke("skipsound", 0.55f);

        Camera.main.GetComponent<cameracontrol>().lerpTime = 2;
        Invoke("newlevelstart", 2);
    }

    void newlevelstart()
    {
        finish = false;
        Camera.main.GetComponent<cameracontrol>().lerpTime = 8;
    }

    void ballparticlecreat()
    {
        Vector3 ballpart = new Vector3(Random.Range(-0.01f, 0.01f), 0, 0);
        Instantiate(ballparticles, this.transform.position + ballpart, Quaternion.identity);
    }

    void skipsound()
    {
        ColliderSound.clip = gotonextsound;
        if (SAJStatic.SAJSound)
            ColliderSound.Play();
    }
}