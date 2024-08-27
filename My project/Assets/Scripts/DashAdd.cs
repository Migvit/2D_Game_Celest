using UnityEngine;

public class DashAdd : MonoBehaviour
{
    private PlayerController playerAddDash;
    public GameObject dashAdd;

    void Start()
    {
        playerAddDash = FindObjectOfType<PlayerController>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta colis�o com o objeto espec�fico para "Mais Dashes"
        if (collision.gameObject.CompareTag("Player"))
        {
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