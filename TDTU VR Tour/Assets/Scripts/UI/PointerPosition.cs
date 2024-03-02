using UnityEngine;

public class PointerPosition : MonoBehaviour
{
    [SerializeField] private GameObject character; 
    [SerializeField] private GameObject pointer; 

    private Vector3 offset; 

    void Start()
    {
        offset = pointer.transform.position - character.transform.position;
    }

    void Update()
    {
        UpdatePointerPosition();
    }

    void UpdatePointerPosition()
    {
        Vector3 newPosition = character.transform.position + offset;

        pointer.transform.position = newPosition;
    }
}
