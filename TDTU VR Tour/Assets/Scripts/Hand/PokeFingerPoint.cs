using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR.Interaction.Toolkit;

public class PokeFingerPoint : MonoBehaviour
{
    public Transform fingerPoint;
    private XRPokeInteractor pokeInteractor; 
    // Start is called before the first frame update
    void Start()
    {
        pokeInteractor = transform.parent.parent.GetComponentInChildren<XRPokeInteractor>();
        setFingerPoint();
    }

    void setFingerPoint()
    {
        if(fingerPoint == null)
        {
            Debug.Log("Finger point is null");
            return;
        }

        if(pokeInteractor == null)
        {
            Debug.Log("Poke interactor is null");
            return;
        }
        pokeInteractor.attachTransform = fingerPoint;
    }
}
