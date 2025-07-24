using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;
    public ScoreManager scoreManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageEnemy(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            scoreManager.IncreaseScore(10);
            PlayerUI.instance.KilledEnemies++;
            PlayerUI.instance.killedEnemiesText.text = "Kills: " + PlayerUI.instance.KilledEnemies;
        }
    }
}
