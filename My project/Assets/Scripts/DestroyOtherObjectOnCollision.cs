using UnityEngine;

public class DestroyOtherObjectOnCollision : MonoBehaviour
{
    public GameObject objectToDestroy;  // O objeto que será destruído ao colidir

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que colidiu é o player
        if (other.CompareTag("Player"))
        {
            // Verifica se o objeto a ser destruído foi atribuído
            if (objectToDestroy != null)
            {
                // Destroi o objeto especificado
                Destroy(objectToDestroy);
            }
            else
            {
                Debug.LogWarning("Nenhum objeto foi atribuído para ser destruído!");
            }
        }
    }
}
