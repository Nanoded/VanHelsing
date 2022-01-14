using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReader : MonoBehaviour
{
    [SerializeField] Teacher teacher;
    [SerializeField] GameObject secondLesson;
    [SerializeField] GameObject thirdLesson;
    [SerializeField] GameObject fourLesson;
    [SerializeField] GameObject ghost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (teacher != null)
        {
            if (collision.name == secondLesson.name)
                teacher.secondPos = true;

            if (collision.name == thirdLesson.name)
                teacher.thirdPos = true;
        }

        if (collision.name == "GhostTrigger")
            ghost.GetComponent<Rigidbody2D>().simulated = true;
    }
}
