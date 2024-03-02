using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Animator))]
public class HandController : MonoBehaviour
{
    public InputActionReference gripInputActionReference;
    public InputActionReference triggerInputActionReference;
    private Animator handAnimation;
    private float gripValue;
    private float triggerValue;

    // Start is called before the first frame update
    void Start()
    {
        handAnimation = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animateGrip();
        animateTrigger();   
    }

    private void animateGrip()
    {
        gripValue = gripInputActionReference.action.ReadValue<float>();
        handAnimation.SetFloat("Grip", gripValue);
    }

    private void animateTrigger()
    {
        triggerValue = triggerInputActionReference.action.ReadValue<float>();
        handAnimation.SetFloat("Trigger", triggerValue);
    }
}
