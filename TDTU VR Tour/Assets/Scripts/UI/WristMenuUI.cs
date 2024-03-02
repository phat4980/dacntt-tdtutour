using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class WristMenuUI : MonoBehaviour
{
    //Wrist menu action
    [Header("Input action asset")]
    public InputActionAsset inputActions;
    private Canvas wristMenuCanvas;
    private InputAction menu;
    // Start is called before the first frame update
    void Start()
    {
        wristMenuCanvas = GetComponent<Canvas>();
         wristMenuCanvas.enabled = false;
        menu = inputActions.FindActionMap("XRI LeftHand").FindAction("Wrist Menu");
        Debug.Log("Find input actions: " + inputActions);
        menu.Enable();
        menu.performed += ToggleMenu;
    }

    public void ToggleMenu(InputAction.CallbackContext context) 
    {
        Debug.Log("Toggle menu called");
        wristMenuCanvas.enabled = !wristMenuCanvas.enabled;
    }
    
    private void OnDestroy() {
        menu.performed -= ToggleMenu;
    }
}
