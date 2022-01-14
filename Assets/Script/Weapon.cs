using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] DataStorage dataStorage;
    bool isAttack = false;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) && isAttack == false)
        {
            GetComponentInParent<Animator>().SetBool("Attack", true);
            StartCoroutine(AttackTime(1));
        }
    }

    IEnumerator AttackTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GetComponentInParent<Animator>().SetBool("Attack", false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
            collision.gameObject.GetComponent<Reaper>().TakeDamage(damage * dataStorage.attackBuff);

        if (collision.gameObject.layer == 10)
            collision.gameObject.GetComponent<Lich>().TakeDamage(damage * dataStorage.attackBuff);

    }
}
