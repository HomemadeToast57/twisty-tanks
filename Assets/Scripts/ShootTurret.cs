using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootTurret : MonoBehaviour
{
    public string tankColor;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckForShooting();
    }

    private void FixedUpdate()
    {
        
    }

    void CheckForShooting()
    {
        if (tankColor == "red")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GetComponent<ShootingManagerTank>().Shoot();
            }

        }

        if(tankColor == "blue")
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                GetComponent<ShootingManagerTank>().Shoot();
            }
        }
        
    }

}
