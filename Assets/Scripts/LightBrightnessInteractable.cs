using UnityEngine;

public class LightBrightnessInteractable : Interactable
{
    public HueController hueController;
    [Range(1, 254)] public int brightness = 128;
    public int lightId = 3;
    public Light localLightSource;

    private void Awake()
    {
        if (hueController == null)
        {
            hueController = FindFirstObjectByType<HueController>();
        }
        if (localLightSource == null)
        {
            localLightSource = GetComponentInChildren<Light>(true);
        }
    }

    public override void OnInteract()
    {
        if (hueController != null)
        {
            hueController.SetLightBrightness(brightness, lightId);
        }
        if (localLightSource != null)
        {
            localLightSource.gameObject.SetActive(brightness > 0);
            localLightSource.intensity = brightness / 254f * 2f;
        }
    }
}