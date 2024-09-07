using UnityEngine;

public class DashAdd : MonoBehaviour
{
    private PlayerController playerAddDash;
    private ParticleSystem dust;
    public GameObject dashAdd;

    void Start()
    {
        dust = GetComponent<ParticleSystem>();
        playerAddDash = FindObjectOfType<PlayerController>();
        dust.Stop();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta colisão com o objeto específico para "Mais Dashes"
        if (collision.gameObject.CompareTag("Player"))
        {
            dust.Play();
            MoreDash();

        }
    }

    void MoreDash()
    {
        playerAddDash.dashCount++;
        playerAddDash.canDash = true;
        
        Destroy(dashAdd); 
    }
}