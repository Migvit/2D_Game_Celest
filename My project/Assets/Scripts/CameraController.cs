using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;           // Referência ao jogador
    public Vector3 offset;             // Deslocamento entre a câmera e o jogador
    private bool isCameraFixed = false; // Verifica se a câmera está fixa
    private Vector3 fixedPosition;     // Posição onde a câmera será fixada
   // public Projector camera;
    public float sizeCamera = 5f;

    void LateUpdate()
    {
        if (!isCameraFixed)
        {
            // Se a câmera não está fixa, ela segue o jogador
            transform.position = player.position + offset;
        }
        else
        {
            // Quando fixa, mantém a posição fixada
            transform.position = fixedPosition;
        }
    }

    // Método para fixar a câmera em uma posição específica
    public void FixCamera(Vector3 newFixedPosition)
    {
        isCameraFixed = true;
        fixedPosition = newFixedPosition;
    }

    // Método para voltar a seguir o jogador
    public void ResetCamera()
    {
        isCameraFixed = false;
       // camera.orthographicSize = sizeCamera;
    }
}
