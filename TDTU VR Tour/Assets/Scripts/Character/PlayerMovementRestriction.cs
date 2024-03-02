using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementRestriction : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private Transform plane;
    [SerializeField] private string mainScene;

    private Vector3 planeSize;

    private void Awake()
    {
        if (character == null || plane == null)
        {
            Debug.LogError("Null character and plane");
            enabled = false;
            return;
        }

        planeSize = plane.GetComponent<Renderer>().bounds.size;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        if (!enabled) return;

        Vector3 relativePosition = plane.InverseTransformPoint(character.position);

        if (Mathf.Abs(relativePosition.x) > planeSize.x / 2 || Mathf.Abs(relativePosition.z) > planeSize.z / 2)
        {
            relativePosition.x = Mathf.Clamp(relativePosition.x, -planeSize.x / 2, planeSize.x / 2);
            relativePosition.z = Mathf.Clamp(relativePosition.z, -planeSize.z / 2, planeSize.z / 2);

            character.position = plane.TransformPoint(relativePosition);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        enabled = scene.name == mainScene;
    }
}