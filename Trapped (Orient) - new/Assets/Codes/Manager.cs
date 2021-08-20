using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    /*
     * Script requirements:
     *  -Must be attached to an empty object
     */

    public static Manager instance;

    private GameObject player;
    public Vector2 playerPosition;
    public Vector2 playerSpawn;

    public GameObject transitionCanvas;
    private Animator anim;

    private GameObject cam;

    //Check if instance is the same instance throughout as soon as the scene is loaded (runs before Start())
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = transitionCanvas.GetComponent<Animator>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        //Continuously reference the player's current position
        playerPosition = player.transform.position;
    }

    public void RespawnProc()
    {
        StartCoroutine(RespawnCor());
    }

    private IEnumerator RespawnCor()
    {
        anim.Play("Fade in");
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        //Repositions player to previous spawn; default is starting position
        player.transform.position = playerSpawn;

        //Possible error source: Object with "Enemy" tag has no "EnemyAI" script or child classes of thereof
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            e.GetComponent<EnemyAI>().Despawn();
        }

        //Arbitrary set time, to smooth out the transition
        yield return new WaitForSeconds(0.5f);

        anim.Play("Fade out");
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
    }

    //Camera must have an animator component with the "Shake" animation controller as the controller
    public void SpawnProc()
    {
        cam.GetComponent<Animator>().Play("Shake");
    }

    public void DespawnProc()
    {
        cam.GetComponent<Animator>().Play("Shake");

        //Possible error source: Object with "Enemy" tag has no "EnemyAI" script or child classes of thereof
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            e.GetComponent<EnemyAI>().Despawn();
        }
    }
}
