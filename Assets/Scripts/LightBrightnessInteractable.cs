using UnityEngine;

public class LightBrightnessInteractable : Interactable
{
    public HueController hueController;
    [Range(1, 254)] public int brightness = 128;

    private void Awake()
    {
        if (hueController == null)
        {
            hueController = FindFirstObjectByType<HueController>();
        }
    }

    public override void OnInteract()
    {
        if (hueController != null)
        {
            hueController.SetLightBrightness(brightness);
        }
    }
}