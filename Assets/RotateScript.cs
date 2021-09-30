using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{

    public Transform blue;
    public Transform red;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        blue.Rotate(0, 0, -1 * Time.deltaTime * speed);
        red.Rotate(0, 0, 1 * Time.deltaTime * speed);
    }
}
