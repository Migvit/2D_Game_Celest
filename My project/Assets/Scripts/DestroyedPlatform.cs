using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DestroyedPlatform : MonoBehaviour
{
    public float destroyTime = 1f;  // Dura��o que o personagem pode passar pela plataforma
    private GameObject platform;


    void Start()
    {
        platform = GetComponent<GameObject>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
   
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DestroyPlatform());
        }
    }

    IEnumerator DestroyPlatform()
    {
       yield return new WaitForSeconds(destroyTime);
       Destroy(platform);
        
    }
}
