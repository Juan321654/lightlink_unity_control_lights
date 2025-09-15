using UnityEngine;

public class TriggerLightOnCollision : MonoBehaviour
{
    private HueController hueController;
    public int lightId = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hueController = FindFirstObjectByType<HueController>();
        if (hueController == null)
        {
            Debug.LogWarning("HueController not found in scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ...existing code...
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Button pressed");
        if (hueController != null)
        {
            hueController.SetLightOn(true, lightId);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Button released");
        if (hueController != null)
        {
            hueController.SetLightOn(false, lightId);
        }
    }
}
