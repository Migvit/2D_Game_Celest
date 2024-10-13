using UnityEngine;

public class DestroyOtherObjectOnCollision : MonoBehaviour
{
    public GameObject objectToDestroy;  // O objeto que ser� destru�do ao colidir

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que colidiu � o player
        if (other.CompareTag("Player"))
        {
            // Verifica se o objeto a ser destru�do foi atribu�do
            if (objectToDestroy != null)
            {
                // Destroi o objeto especificado
                Destroy(objectToDestroy);
            }
            else
            {
                Debug.LogWarning("Nenhum objeto foi atribu�do para ser destru�do!");
            }
        }
    }
}
