using UnityEngine;
using System.Collections;

public class cameraShaking : MonoBehaviour
{

public bool start = false;
public AnimationCurve curve;
public float duration = 1f;

    // Update is called once per frame
    void Update()
    {
        if (start) {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking() {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            float strenght = curve.Evaluate(elapsedTime/duration);
            transform.position = startPosition + Random.insideUnitSphere * strenght;
            yield return null;
        }

        transform.position = startPosition;
    }
}
