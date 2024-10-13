using UnityEngine;
using System.Collections;

public class CameraFixedPosition : MonoBehaviour
{
    public CameraController cameraController;  // Refer�ncia ao script CameraController
    public Transform fixedCameraPosition;        // Posi��o fixa onde a c�mera deve ir quando o player entrar
    public Camera camera;
    public float sizeCamera = 5f;
    public float sizeCameraMin = 5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Quando o player entra na �rea, fixa a c�mera na posi��o desejada
            cameraController.FixCamera(fixedCameraPosition);
            camera.orthographicSize = camera.orthographicSize + 1 * Time.deltaTime;
            if (camera.orthographicSize > sizeCamera)
            {
                camera.orthographicSize = sizeCamera; // Max size
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Quando o player sai da �rea, a c�mera volta a seguir o player
            cameraController.ResetCamera();
            camera.orthographicSize = camera.orthographicSize - 1 * Time.deltaTime;
            if (camera.orthographicSize < sizeCamera)
            {
                camera.orthographicSize = sizeCamera; // Max size
            }
        }
    }
}