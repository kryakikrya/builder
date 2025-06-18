using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Health : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float regen = 1f;
    public bool isDamaged;
    public float maxHealth;

    private void Start()
    {
        maxHealth = health;
        if (gameObject.CompareTag("Player"))
        {
            print("player");
            StartCoroutine(Regeneration());
        }
    }
    public void GetDamage(float damage)
    {
        isDamaged = true;
        if (health - damage <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(1);
            }
            Destroy(gameObject);
        }
        else
        {
            health -= damage;
            print(GetHealth() + " - hp");
        }
    }

    public float GetHealth()
    {
        return health;
    }
    IEnumerator Regeneration()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (health <= maxHealth - regen)
            {
                print(GetHealth());
                health += regen;
            }
            else if (health > maxHealth - regen && health < maxHealth)
            {
                print(GetHealth());
                health = maxHealth;
            }
        }
    }
}
