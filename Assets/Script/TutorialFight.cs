using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class TutorialFight : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] Text dialogue;
    [SerializeField] CinemachineVirtualCamera cam1;
    [SerializeField] CinemachineVirtualCamera cam4;
    [SerializeField] GameObject red_Hood;
    [SerializeField] GameObject thirdLesson;
    [SerializeField] Teacher teacher;

    void Start()
    {
        red_Hood.GetComponent<Animator>().SetBool("Idle", true);
        red_Hood.GetComponent<Red_Hood>().enabled = false;
        StartCoroutine(Dialogue());
    }


    IEnumerator Dialogue()
    {
        teacher.thirdPos = false;
        thirdLesson.SetActive(false);
        yield return new WaitForSeconds(7);
        dialogue.text = "Елена: -Просто это детские задачки! Я так весь день могу прыгать...";
        yield return new WaitForSeconds(7);
        cam4.Priority = 100; 
        cam1.Priority = 1;
        dialogue.text = "Учитель: -В таком случае держи задачу посложнее.";
        yield return new WaitForSeconds(7);
        dialogue.text = "Учитель: -На вашем пути стоит жнец. Он не так прост как кажется с первого взгляда.";
        yield return new WaitForSeconds(7);
        dialogue.text = "Учитель: -Сам по себе он безобиден. Но стоит приблизиться слишком близко... В общем будь осторожен. Дважды он не прощает. " +
            "Но ему ты уже можешь навалять. Жми Z для удара ножом. ";
        yield return new WaitForSeconds(15);
        dialogue.text = "Елена: -Трепещи! Перед тобой представитель знаменитого рода охотников на чудовищ! Я - Елена Ван Хельсинг!";
        yield return new WaitForSeconds(7);
        cam1.Priority = 100;
        cam4.Priority = 1;
        red_Hood.GetComponent<Red_Hood>().enabled = true;
        red_Hood.GetComponent<Animator>().SetBool("Idle", false);
        title.SetActive(false);
    }
}
