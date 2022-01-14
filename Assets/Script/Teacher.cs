using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    [SerializeField] Transform secondPosition;
    [SerializeField] Transform thirdPosition;
    [SerializeField] GameObject tutorialJump;
    [SerializeField] GameObject tutorialFight;
    [SerializeField] GameObject endTitle;
    public bool secondPos;
    public bool thirdPos;
    [SerializeField] Reaper reaper;
    

    // Update is called once per frame
    void Update()
    {
        if (thirdPos == false && secondPos == true)
        {
            gameObject.transform.position = secondPosition.position;
            tutorialJump.SetActive(true);
        }


        if (thirdPos == true && secondPos == false)
        {
            gameObject.transform.position = thirdPosition.position;
            tutorialFight.SetActive(true);
        }

        if (reaper != null)
        {
            if (reaper.currentHealth <= 0)
            {
                endTitle.SetActive(true);
            }
        }
    }
}
