using UnityEngine;
using System.Collections;

public class CameraFixedPosition : MonoBehaviour
{
    public CameraController cameraController;  // Refer�ncia ao script CameraController
    public Vector3 fixedCameraPosition;        // Posi��o fixa onde a c�mera deve ir quando o player entrar
   // public Projector camera;
    public float sizeCamera = 5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Quando o player entra na �rea, fixa a c�mera na posi��o desejada
            cameraController.FixCamera(fixedCameraPosition);
           // camera.orthographicSize = sizeCamera;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Quando o player sai da �rea, a c�mera volta a seguir o player
            cameraController.ResetCamera();
        }
    }
}