using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public float destroyDelay = 2f;  // Tempo em segundos antes de destruir a plataforma

    private bool playerTouched = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto que colidiu tem a tag "Player"
        if (collision.gameObject.CompareTag("Player") && !playerTouched)
        {
            playerTouched = true;
            // Chama o método para destruir a plataforma após o delay especificado
            Invoke("DestroyPlatform", destroyDelay);
        }
    }

    void DestroyPlatform()
    {
        // Destrói o GameObject ao qual o script está anexado
        Destroy(gameObject);
    }
}
