using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    [SerializeField] public int scene;


    void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta colisão com o objeto específico para "Mais Dashes"
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
        }
    }
}