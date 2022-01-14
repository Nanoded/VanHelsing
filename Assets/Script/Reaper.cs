using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float health;
    public float currentHealth;
    bool idleUnarmed = true;
    Red_Hood red_Hood;

    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            GetComponent<Animator>().SetBool("Dead", true);
        }
    }

    public void Telekinesis()
    {
        GetComponent<PointEffector2D>().enabled = true;
        GetComponent<Animator>().SetBool("Idle", true);
    }

    void OffTelekinesis()
    {
        GetComponent<PointEffector2D>().enabled = false;
        idleUnarmed = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            GetComponent<Animator>().SetBool("WieldWeapon", true);

            if (idleUnarmed == true)
                Telekinesis();
            else
            {
                GetComponent<Animator>().SetBool("Attack", true);

                red_Hood = collision.gameObject.GetComponent<Red_Hood>();
            }
        }

        if (collision.name == "DeathTrigger")
        {
            currentHealth = 0;
        }
    }

    void Attack()
    {
        if(red_Hood != null)
            red_Hood.TakeDamage(damage);
    }
    
    void OffAttack()
    {
        GetComponent<Animator>().SetBool("Attack", false);
    }

    void Dead()
    {
        Destroy(gameObject);
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
