using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBoom : MonoBehaviour
{
    [SerializeField] GameObject energy;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Animator>().SetBool("Boom", true);
        energy.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost") && PlayerPrefs.GetInt("SaintBomb") == 1)
        {
            Destroy(collision.gameObject);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Animator>().SetBool("Boom", true);
            energy.SetActive(true);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
