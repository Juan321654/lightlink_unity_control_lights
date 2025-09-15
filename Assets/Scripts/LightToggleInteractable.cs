using UnityEngine;

public class LightToggleInteractable : Interactable
{
  public HueController hueController;
  public int lightId;
  public Light localLightSource;
  private bool isOn = false;

  private void Awake()
  {
    if (hueController == null)
    {
      Debug.LogWarning("HueController not assigned in LightToggleInteractable, attempting to find one in the scene.");
      hueController = FindFirstObjectByType<HueController>();
      if (hueController == null)
      {
        Debug.LogError("HueController not found in scene. LightToggleInteractable will not function.");
      }
    }
    if (localLightSource == null)
    {
      localLightSource = GetComponentInChildren<Light>(true);
      if (localLightSource == null)
      {
        Debug.LogWarning("No Light component found as child of this prefab.");
      }
    }
  }

  public override void OnInteract()
  {
    Debug.Log("LightToggleInteractable interacted with");
    isOn = !isOn;
    if (hueController != null)
    {
      hueController.SetLightOn(isOn, lightId);
    }
    if (localLightSource != null)
    {
      localLightSource.gameObject.SetActive(isOn);
    }
  }
}