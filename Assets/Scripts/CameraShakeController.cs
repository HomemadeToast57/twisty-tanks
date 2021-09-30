using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeController : MonoBehaviour
{

    public CameraShaker shake;
    // Start is called before the first frame update
    void Start()
    {
        shake = gameObject.GetComponent<CameraShaker>();
    }

    public void ShakeCam(bool isOn)
    {

        shake.shakeDuration = 99999999999999999999999999999999999999f;
        if (isOn)
        {
            shake.enabled = true;
        }
        else if (!isOn)
        {
            shake.enabled = false;
        }

    }
}
