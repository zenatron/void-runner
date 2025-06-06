using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineCamera freeLookCamera;
    public CinemachineCamera followCamera;
    private bool isFollowing = false;
    private InputAction switchCameraAction;

    void Start()
    {
        // Ensure the correct priority at start
        freeLookCamera.Priority = 1;
        followCamera.Priority = 0;

        // Cache the input action reference
        switchCameraAction = InputSystem.actions.FindAction("SwitchCamera", throwIfNotFound: true);
    }

    void Update()
    {
        // get camera switch input
        bool switchCamera = switchCameraAction.triggered;

        if (switchCamera)
        {
            isFollowing = !isFollowing;

            if (isFollowing)
            {
                followCamera.Priority = 2; // Higher priority activates it
                freeLookCamera.Priority = 0;
            }
            else
            {
                freeLookCamera.Priority = 2;
                followCamera.Priority = 0;
            }
        }
    }
}