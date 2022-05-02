using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    private Image damageImage;

    private void Awake()
    {
        damageImage = GetComponent<Image>();
    }

    public void StartEffect()
    {
        StartCoroutine(ShowDamageEffectCoroutine());
    }

    private IEnumerator ShowDamageEffectCoroutine() {

        damageImage.enabled = true;

        for (float t = 1; t > 0f; t -= Time.deltaTime)
        {
            damageImage.color = new Color(1, 0, 0, t);

            if (t <= 0.01f)
            {
                damageImage.enabled = false;
                yield break;
            }
            else {
                yield return null;
            } 
        }
    }
}
