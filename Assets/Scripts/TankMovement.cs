using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float playerRotateSpeed;
    [SerializeField] private float turretRotateSpeed;
    private float horizontalMoveDirection;
    private float verticalMoveDirection;
    private float turretMoveDirection;
    public string playerCode;
    public GameObject turret;
    public GameObject tracks;
    public float durationOfTracks = 8f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        if(playerCode == "P1")
        {
            //Debug.Log(Input.GetAxisRaw(playerCode + "Horizontal"));
        }
    }

    private void FixedUpdate()
    {
        Movement();
        RotatePlayer();
        RotateTurret();
    }

    void GetPlayerInput()
    {
        horizontalMoveDirection = Input.GetAxisRaw(playerCode + "Horizontal");
        verticalMoveDirection = Input.GetAxisRaw(playerCode + "Vertical");
        turretMoveDirection = Input.GetAxisRaw(playerCode + "Turret");
    }


    void Movement()
    {
        Vector3 directionVector = new Vector3(horizontalMoveDirection, verticalMoveDirection);
        rb.velocity = transform.up * verticalMoveDirection * moveSpeed;
        if(rb.velocity.magnitude > 0)
        {
            GameObject tempTracks = Instantiate(tracks, transform.position, transform.rotation);
            Destroy(tempTracks, durationOfTracks);
        }

    }

    void RotatePlayer()
    {
        float rotation = horizontalMoveDirection * playerRotateSpeed;
        transform.Rotate(-Vector3.forward * rotation);
    }

    void RotateTurret()
    {
        float rotation = turretMoveDirection * turretRotateSpeed;
        turret.transform.Rotate(-Vector3.forward * rotation);
    }
}
