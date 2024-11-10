using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject fixedCam;
    private bool isInside = false;

    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Player") && !isInside)
        {
            isInside = true;
            SwitchToFixedCam();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isInside)
        {
            isInside = false;
            SwitchToMainCam();
        }
    }

    private void SwitchToFixedCam()
    {
        mainCam.SetActive(false);
        fixedCam.SetActive(true);
    }

    private void SwitchToMainCam()
    {
        mainCam.SetActive(true);
        fixedCam.SetActive(false);
    }
}
