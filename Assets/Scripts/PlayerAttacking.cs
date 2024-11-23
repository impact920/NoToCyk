using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerAttacking : MonoBehaviour
{
    public Animator animator;
    public float healthAmount = 100f;
    public Image healthBar;
    [SerializeField] TextMeshProUGUI CurrentHealthText;
    public int maxHealth = 200;
    int currentHealth;

    public LayerMask enemyLayers;
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    public int PlayerAttackDamage = 40;

    void Start()
    {
       currentHealth = maxHealth;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
        Attack();
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamageEnemy(PlayerAttackDamage);
        }
    }



    public void TakeDamagePlayer(int Damage)
    {
        currentHealth -= Damage;

        animator.SetTrigger("Hurt");

        healthBar.fillAmount = currentHealth / 200f;
        CurrentHealthText.text = "" + currentHealth;

        if(currentHealth <=0 )
        {
        Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died");

        animator.SetBool("Death", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        SceneManager.LoadSceneAsync(2);

    }




    void OnDrawGizmosSelected()
    {
        if(AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }


}
