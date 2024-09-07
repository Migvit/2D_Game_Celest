using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;


public class PassThroughtPlatform : MonoBehaviour
{
    public float fallThroughDuration = 0.5f;  // Duração que o personagem pode passar pela plataforma

    private Collider2D playerCollider;

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))  // Quando o jogador pressiona "S" (ou seta para baixo)
        {
            StartCoroutine(FallThrough());
        }
    }

    IEnumerator FallThrough()
    {
        // Desativa o colisor do personagem temporariamente
        playerCollider.enabled = false;
        yield return new WaitForSeconds(fallThroughDuration);
        // Reativa o colisor após o tempo definido
        playerCollider.enabled = true;
    }
}
