using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class ARObjectSpawner : MonoBehaviour
{

    [SerializeField] private GameObject objectToSpawn;

    [SerializeField] TrackableType trackableType;

    private ARRaycastManager raycastManager;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private InputAction pressAction;

    private GameObject objectSpawned;

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        pressAction=new InputAction("touch", binding: "<Pointer>/press");
    }

    private void OnEnable()
    {
        pressAction.Enable();
    }

    private void OnDisable()
    {
        pressAction.Disable();
    }

    private void Update()
    {
        var isPressed=pressAction.IsPressed();

        if (!isPressed) return;

        var touchPosition=Pointer.current.position.ReadValue();

        if(raycastManager.Raycast(touchPosition, hits, trackableType))
        {
            var hitPose=hits[0].pose;
            if (objectSpawned==null)
            {
                objectSpawned=Instantiate(objectToSpawn, hitPose.position, hitPose.rotation);
            }
            else
            {
                objectSpawned.transform.position=hitPose.position;
                objectSpawned.transform.rotation=hitPose.rotation;
            }
        }

    }
}
