using UnityEngine;

public class JumpAdd : MonoBehaviour
{ 
    private PlayerController playerAddJump;
    private ParticleSystem dust;
    public GameObject jumpAdd;

    void Start()
    {
        dust = GetComponent<ParticleSystem>();
        playerAddJump = FindObjectOfType<PlayerController>();
        dust.Stop();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta colis�o com o objeto espec�fico para "Mais pulos"
        if (collision.gameObject.CompareTag("Player"))
        {
            dust.Play();
            MoreJump();

        }
    }

    void MoreJump()
    {
        
        playerAddJump.jumpCount++;
        Destroy(jumpAdd);
    }
}
