using UnityEngine;
using System.Collections;

public class CameraFixedPosition : MonoBehaviour
{
    public CameraController cameraController;  // Referência ao script CameraController
    public Vector3 fixedCameraPosition;        // Posição fixa onde a câmera deve ir quando o player entrar
   // public Projector camera;
    public float sizeCamera = 5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Quando o player entra na área, fixa a câmera na posição desejada
            cameraController.FixCamera(fixedCameraPosition);
           // camera.orthographicSize = sizeCamera;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Quando o player sai da área, a câmera volta a seguir o player
            cameraController.ResetCamera();
        }
    }
}