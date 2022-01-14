using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] GameObject target;
    SpriteRenderer sr;
    bool lookRight = true;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (target.transform.position.x > transform.position.x && lookRight == false)
            {
                sr.flipX = !sr.flipX;
                lookRight = !lookRight;
            }

            if (target.transform.position.x < transform.position.x && lookRight == true)
            {
                sr.flipX = !sr.flipX;
                lookRight = !lookRight;
            }
        }
    }
}
