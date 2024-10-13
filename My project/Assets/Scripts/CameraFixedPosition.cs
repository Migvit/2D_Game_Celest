using UnityEngine;
using System.Collections;

public class CameraFixedPosition : MonoBehaviour
{
    public CameraController cameraController;  // Referência ao script CameraController
    public Transform fixedCameraPosition;        // Posição fixa onde a câmera deve ir quando o player entrar
    public Camera camera;
    public float sizeCamera = 5f;
    public float sizeCameraMin = 5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Quando o player entra na área, fixa a câmera na posição desejada
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
            // Quando o player sai da área, a câmera volta a seguir o player
            cameraController.ResetCamera();
            camera.orthographicSize = camera.orthographicSize - 1 * Time.deltaTime;
            if (camera.orthographicSize < sizeCamera)
            {
                camera.orthographicSize = sizeCamera; // Max size
            }
        }
    }
}