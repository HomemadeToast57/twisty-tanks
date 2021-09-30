using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public int maxBounces;
    private int currentBounce;
    public GameObject gameManager;
    public GameObject explosionPrefab;

    //Cam Shake
    public CameraShakeController cameraShakeController;

    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentBounce = 0;

        //find CameraShakeController script
        cameraShakeController = GameObject.Find("Main Camera").GetComponent<CameraShakeController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInPlay();  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Arena"))
        {
            if(currentBounce < maxBounces)
            {
                currentBounce++;
            } else if(currentBounce == maxBounces)
            {
                //Call in particle
                //Destroy particle
                Destroy(gameObject);
            }
        }
        if(collision.collider.CompareTag("P1") || collision.collider.CompareTag("P2"))
        {
            collision.collider.gameObject.SetActive(false);
            gameManager.GetComponent<GameManager>().RoundOver(collision.collider.tag);
            GameObject explosion = Instantiate(explosionPrefab);

            //Match pos and rot of tank to the explosion
            explosion.transform.position = collision.collider.gameObject.transform.position;
            explosion.transform.rotation = collision.collider.gameObject.transform.rotation;

            //shake camera
            cameraShakeController.ShakeCam(true);

            Destroy(explosion, 1);
            Destroy(gameObject);
        }
    }

    public void CheckInPlay()
    {
        if (gameManager.GetComponent<GameManager>().GetInPlayBool() == false)
        {
            Destroy(gameObject);
        }
    }
}

