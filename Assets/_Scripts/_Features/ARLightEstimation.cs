using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARLightEstimation : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshPro avgBrightnessText;

    [SerializeField] private TextMeshPro colorTemp
        ;
    [SerializeField] private TextMeshPro colorCorrection;

    [Header("Mappings")]

    [SerializeField] private GameObject worldSpaceGameobject;

    private Light arLight;

    private ARCameraManager arCamManager;

    private float? brightness;
    private float? colorTemperature;
    private float? colorCorrectionTemperature;

    private void Awake()
    {
        arLight = FindObjectOfType<Light>();

        arCamManager=FindObjectOfType<ARCameraManager>();
    }

}
