using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script handles the transition between the forest and house areas of the game, fixed cam and UI elements are set to active while in the house, and main camera is deactivated, and vice versa as the pllayer moves between areas.
/// </summary>

public class CameraSwitch : MonoBehaviour
{
    public GameObject mainCam; // Main 3rd person cam that follows the player
    public GameObject fixedCam; // Cam that overlooks the house
    public GameObject fixedCamUI; // Additional UI element becomes active as the fixed cam becomes active - a render texture that follows an additional camera that has a first person perspective.
    private bool isInside = false; // bool tracking if the player is inside the house - uses a collider trigger
    public Animator animator;

    private void OnTriggerEnter(Collider other) // As the player enters the collider space, the fixed cam is activated and main cam deactivated
    { 
        if (other.CompareTag("Player") && !isInside)
        {
            SwitchToFixedCam();
        }
    }

    private void OnTriggerExit(Collider other) // If the player chooses to leave the house the camera will go back to how it was before
    {
        if (other.CompareTag("Player") && isInside)
        {
            SwitchToMainCam();
        }
    }

    private void SwitchToFixedCam() // Functions are stored in a seperate method rather than being called during the OnTriggerEnter method - optimised and good practise
    {
        isInside = true;
        mainCam.SetActive(false);
        fixedCam.SetActive(true);
        fixedCamUI.SetActive(true);
        AudioEventManager.PlaySFX(null, "CameraShutter1", 0.6f, 1.0f, true, 0.1f, 0f, "Cam sound");
        animator.SetBool("Fade", true);
    }

    private void SwitchToMainCam() 
    {
        isInside = false;
        mainCam.SetActive(true);
        fixedCam.SetActive(false);
        fixedCamUI.SetActive(false);
        AudioEventManager.PlaySFX(null, "CameraShutter2", 0.6f, 1.0f, true, 0.1f, 0f, "Cam sound");
        animator.SetBool("Fade", false);
    }
}
