using UnityEngine;

public class JumpAdd : MonoBehaviour
{ 
    private PlayerController playerAddJump;
    public GameObject jumpAdd;

    void Start()
    {
        playerAddJump = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta colisão com o objeto específico para "Mais pulos"
        if (collision.gameObject.CompareTag("Player"))
        {
            MoreJump();

        }
    }

    void MoreJump()
    {
        playerAddJump.jumpCount++;
        Destroy(jumpAdd);
    }
}
