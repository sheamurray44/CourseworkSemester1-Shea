using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject fixedCam;
    private bool isInside = false;
    public Animator animator;

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
        AudioEventManager.PlaySFX(null, "CameraShutter1", 0.6f, 1.0f, true, 0.1f, 0f, "Cam sound");
        animator.SetBool("Fade", true);
    }

    private void SwitchToMainCam()
    {
        mainCam.SetActive(true);
        fixedCam.SetActive(false);
        AudioEventManager.PlaySFX(null, "CameraShutter2", 0.6f, 1.0f, true, 0.1f, 0f, "Cam sound");
        animator.SetBool("Fade", false);
    }
}
