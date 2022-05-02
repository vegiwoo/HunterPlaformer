using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject healthIconPrefab;
    public List<GameObject> healthIcons = new List<GameObject>();

    public void Setup(int maxHealth) {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newIcon =  Instantiate(healthIconPrefab, transform);
            healthIcons.Add(newIcon);
        }
    }

    public void DispalayHealth(int health) {
        List<GameObject> valideIcons = healthIcons
            .Where(icon => healthIcons.IndexOf(icon) < 5)
            .Select(icon => icon)
            .ToList();

        for (int i = 0; i < healthIcons.Count(); i++)
        {
            healthIcons[i].SetActive(i < health ? true : false);
        }
    }
}
