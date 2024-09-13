using UnityEngine;
using UnityEngine.UI;

public class ShowMessage : MonoBehaviour
{
    private MeshRenderer text;

   

    void Start()
    {
        text = GetComponent<MeshRenderer>();
        text.enabled = false;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Exibe a mensagem quando o jogador entra na área
            text.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Exibe a mensagem quando o jogador entra na área
            text.enabled = false;
        }
    }
}

