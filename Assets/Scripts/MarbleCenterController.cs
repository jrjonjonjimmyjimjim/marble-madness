using UnityEngine;

/// <summary>
///     Define behaviour for the marble center like camera rotation
/// </summary>
public class MarbleCenterController : MonoBehaviour
{
    public Transform marbleSphere;
    public float pLerp;
    public Vector2 turn;
    public float sensitivity;

    /// <summary>
    ///     Give the player the ability to rotate the camera using the right mouse button
    /// </summary>
    private void Update()
    {
        // If the game is paused, then don't allow the user to rotate the camera
        if (PauseMenu.IsPaused) return;

        transform.position = Vector3.Lerp(transform.position, marbleSphere.position, pLerp);
        if (Input.GetMouseButton(1))
        {
            turn.y += Input.GetAxis("Mouse Y") * sensitivity;
            turn.x += Input.GetAxis("Mouse X") * sensitivity;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
    }
}