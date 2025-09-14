using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
  public Camera playerCamera;
  public float interactDistance = 3f;
  public KeyCode interactKey = KeyCode.E;

  void Update()
  {
    if (Input.GetKeyDown(interactKey))
    {
      Debug.Log("Interact key pressed");
      Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
      if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
      {
        Interactable interactable = hit.collider.GetComponent<Interactable>();
        if (interactable != null)
        {
          Debug.Log("Interacting with " + interactable.name);
          interactable.OnInteract();
        }
      }
    }
  }
}