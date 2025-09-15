using UnityEngine;

public class LightColorInteractable : Interactable
{
    public HueController hueController;
    public Color color = Color.white;
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
            int r = Mathf.RoundToInt(color.r * 255);
            int g = Mathf.RoundToInt(color.g * 255);
            int b = Mathf.RoundToInt(color.b * 255);
            hueController.SetLightColor(r, g, b, lightId);
        }
        if (localLightSource != null)
        {
            localLightSource.gameObject.SetActive(true);
            localLightSource.color = color;
        }
    }
}