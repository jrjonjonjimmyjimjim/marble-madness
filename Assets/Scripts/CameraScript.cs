using UnityEngine;

/// <summary>
///     Define behaviour for the camera such that it follows the player, or more
///     specifically the center of the marble (no crazy camera rotation that
///     way)
/// </summary>
public class CameraScript : MonoBehaviour
{
    public Transform camTarget;
    public float pLerp;
    public float rLerp;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);
    }
}