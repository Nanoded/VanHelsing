using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lich : MonoBehaviour
{
    [SerializeField] GameObject[] move_targets;
    [SerializeField] GameObject dialogue;

    System.Random rdm;

    public float health;
    public float currentHealth;

    Animator anim;

    private void Update()
    {
        if (currentHealth <= 0)
        {
            dialogue.SetActive(true);
            GetComponent<Animator>().enabled = false;
            GetComponent<Lich>().enabled = false;
        }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rdm = new System.Random();
        currentHealth = health;
        StartCoroutine(WaitBeforeMove());
    }

    void Move()
    {
        Transform target = move_targets[rdm.Next(0, move_targets.Length)].transform;
        transform.position = target.position;
        if(currentHealth > 0)
            StartCoroutine(WaitBeforeMove());
    }

    IEnumerator WaitBeforeMove()
    {
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("Teleport", false);
        yield return new WaitForSeconds(10);
        anim.SetBool("Teleport", true);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
