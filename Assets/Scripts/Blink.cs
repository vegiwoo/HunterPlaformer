using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public List<Renderer> renderers;

    public void StartBlink()
    {
        StartCoroutine(ShowBlinkEffectCoroutine());
    }

    private IEnumerator ShowBlinkEffectCoroutine() {

        for (float t = 0; t < 1; t += Time.deltaTime) {

            foreach (var renderer in renderers)
            {
                renderer.material.SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 1));
            }

            if (t >= 0.98f)
            {
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }

}
