using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 5;

    int currentHealth;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            PlayerGameOver();
        }

    }

    void PlayerGameOver()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("Lose");
    }
}
