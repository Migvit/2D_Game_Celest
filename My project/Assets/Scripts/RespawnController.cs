using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public Transform spawnPoint;  // Refer�ncia ao ponto de spawn
    private GameObject player;  // Refer�ncia ao jogador

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        RespawnPlayer();
    }

    void RespawnPlayer()
    {
        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.position;
            Debug.Log("Player respawned at: " + spawnPoint.position);
        }
        else
        {
            Debug.LogWarning("Player or SpawnPoint not assigned.");
        }
    }

    // Exemplo de uso: chame esta fun��o para respawnar o jogador quando necess�rio
    public void TriggerRespawn()
    {
        RespawnPlayer();
    }
}
