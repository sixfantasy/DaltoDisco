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
        StartCoroutine(CheckDeath());
    }
    public void HealCharacter(float heal)
    {
        health += heal;
    }

    IEnumerator CheckDeath()
    {
        if (health <= 0 )
        {
            health = 1;
            Destroy(player.GetComponent<Collider2D>());
            playerAnimator.SetBool("IsDead",true);
            yield return new WaitForSeconds(2);
            Destroy(player);
            StartCoroutine(GoToEndScene());
        }
    }

    IEnumerator GoToEndScene()
    {
        yield return StartCoroutine(_sceneTransition.DoFading(false));
        SceneManager.LoadScene(2);
    }
}
