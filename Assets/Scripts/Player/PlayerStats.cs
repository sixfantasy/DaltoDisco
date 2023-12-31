using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    public GameObject player;
    public Animator playerAnimator;
    public float health;
    public float maxHealth;

    [SerializeField] private SceneTransition _sceneTransition;

    public void Awake()
    {
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else playerStats = this;
       // DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        playerAnimator.SetTrigger("Hit");
        CheckDeath();
    }
    public void HealCharacter(float heal)
    {
        health += heal;
        if (health > maxHealth) health = maxHealth;
    }

    void CheckDeath()
    {
        if (health <= 0 )
        {
            Destroy(player.GetComponent<Collider2D>());
            playerAnimator.SetBool("IsDead",true);
            StartCoroutine(GoToEndScene());
        }
    }

    IEnumerator GoToEndScene()
    {
        yield return StartCoroutine(_sceneTransition.DoFading(false));
        SceneManager.LoadScene(2);
    }
}
