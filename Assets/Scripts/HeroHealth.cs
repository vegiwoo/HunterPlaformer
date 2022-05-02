using UnityEngine;

public class HeroHealth : MonoBehaviour
{
    public int hp = 5;
    public int maxHealth = 8;

    private bool isInvulnerable = false;

    public AudioSource takeDamageSound;
    public AudioSource addHealthSound;

    public HealthUI healthUI;

    public DamageScreen damageScreen;
    private Blink blink;

    private void Start() {

        blink = GetComponent<Blink>();

        healthUI.Setup(maxHealth);
        healthUI.DispalayHealth(hp);
    }

    public void TakeDamage(int damageValue) {
        if (!isInvulnerable) {

            takeDamageSound.Play();
            damageScreen.StartEffect();
            blink.StartBlink();

            hp -= damageValue;
            healthUI.DispalayHealth(hp);

            if (hp <= 0)
            {
                hp = 0;
                Die();
            }
            ToggleInvulnerability();
            Invoke("ToggleInvulnerability", 1);
        }
    }

    private void ToggleInvulnerability() {
        isInvulnerable = !isInvulnerable;
    }

    public void AddHealth(int healthValue) {
        addHealthSound.Play();
        hp += healthValue;
        if (hp > maxHealth) {
            hp = maxHealth;
        }
        healthUI.DispalayHealth(hp);
    }

    private void Die() {
        print("You lose!");
    }

}
