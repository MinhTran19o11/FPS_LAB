using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    
    private float health;
    private float lerpTimer;
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float chipSpeed = 0.5f;
    public Image frontHealthBar;
    public Image backHealthBar;
    public TextMeshProUGUI healthText;

    [Header("Damage Overlay")]
    public Image overlay;
    public float duration;
    public float fadeSpeed;

    private float durationTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if (overlay.color.a > 0)
        {
            if (health < 30)
                return;
            durationTimer += Time.deltaTime;
            if(durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= fadeSpeed * Time.deltaTime;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
        
    }

    public  void UpdateHealthUI()
    {
        
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float perentComplete = lerpTimer / chipSpeed;
            perentComplete = perentComplete * perentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, perentComplete);
        }
        if (fillF < hFraction)
        {
            backHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.green;
            lerpTimer += Time.deltaTime;
            float perentComplete = lerpTimer / chipSpeed;
            perentComplete = perentComplete * perentComplete; // Exponential easing for a smoother transition
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, perentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
        
        
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
        
    }
}
