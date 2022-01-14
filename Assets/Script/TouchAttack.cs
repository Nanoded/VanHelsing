using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAttack : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] bool itsBullet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        { 
            Red_Hood redHood = other.gameObject.GetComponent<Red_Hood>();
            if (redHood != null)
                redHood.TakeDamage(damage);
        }
                    

        if (itsBullet == true)
            Destroy(gameObject);
    }
}
