using UnityEngine;

public class LightColorInteractable : Interactable
{
    public HueController hueController;
    public Color color = Color.white;

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
            int r = Mathf.RoundToInt(color.r * 255);
            int g = Mathf.RoundToInt(color.g * 255);
            int b = Mathf.RoundToInt(color.b * 255);
            hueController.SetLightColor(r, g, b);
        }
    }
}