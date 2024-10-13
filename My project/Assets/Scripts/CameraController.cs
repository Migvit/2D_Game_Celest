using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;           // Refer�ncia ao jogador
    public Vector3 offset;             // Deslocamento entre a c�mera e o jogador
    private bool isCameraFixed = false; // Verifica se a c�mera est� fixa
    public Transform fixedPosition;     // Posi��o onde a c�mera ser� fixada
   // public Projector camera;
    public float sizeCamera = 5f;
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (!isCameraFixed)
        {
            // Se a c�mera n�o est� fixa, ela segue o jogador
            transform.position = player.position + offset;
        }
        else
        {
            // Quando fixa, mant�m a posi��o fixada
            transform.position = fixedPosition.transform.position;
        }
        // Interpola��o suave da posi��o atual para a posi��o alvo
        
    }

    // M�todo para fixar a c�mera em uma posi��o espec�fica
    public void FixCamera(Transform newFixedPosition)
    {
        isCameraFixed = true;
        fixedPosition = newFixedPosition;
        transform.position = Vector3.Lerp(transform.position, fixedPosition.position, smoothSpeed);
    }

    // M�todo para voltar a seguir o jogador
    public void ResetCamera()
    {
        isCameraFixed = false;
       // camera.orthographicSize = sizeCamera;
    }
}
