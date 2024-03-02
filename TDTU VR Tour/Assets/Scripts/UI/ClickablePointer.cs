using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClickablePointer : MonoBehaviour
{
    private XRSimpleInteractable _interactable;

    private void Awake()
    {
        _interactable = GetComponent<XRSimpleInteractable>();
        if (_interactable != null)
        {
            _interactable.selectEntered.AddListener(HandleSelectEntered);
            _interactable.selectExited.AddListener(HandleSelectExited);
        }
        else
        {
            Debug.LogError("No XRSimpleInteractable component found on this GameObject.");
        }
    }

    private void HandleSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Object selected");
    }

    private void HandleSelectExited(SelectExitEventArgs args)
    {
        Debug.Log("Object deselected");
    }

    private void OnDestroy()
    {
        if (_interactable != null)
        {
            _interactable.selectEntered.RemoveListener(HandleSelectEntered);
            _interactable.selectExited.RemoveListener(HandleSelectExited);
        }
    }
}