using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class EndTitle : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] Text dialogue;
    [SerializeField] CinemachineVirtualCamera cam1;
    [SerializeField] CinemachineVirtualCamera cam5;
    [SerializeField] GameObject red_Hood;
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
        cam5.Priority = 100;
        cam1.Priority = 1;
        yield return new WaitForSeconds(7);
        dialogue.text = "Елена: -Спасибо! Я уже начинаю привыкать к тебе, великан!";
        yield return new WaitForSeconds(7);
        dialogue.text = "Учитель: -Очень хорошо. Теперь перейдем к делу...";
        yield return new WaitForSeconds(7);
        dialogue.text = "Учитель: -В Кривом Лесу начали пропадать люди. Ходят слухи, что к этому причастен Лич.";
        yield return new WaitForSeconds(7);
        dialogue.text = "Елена: -Давно он не высовывался. Это странно. ";
        yield return new WaitForSeconds(5);
        dialogue.text = "Учитель: -В этом все и дело. Узнайте как можно больше и очистите лес.";
        yield return new WaitForSeconds(5);
        cam1.Priority = 100;
        cam5.Priority = 1;
        red_Hood.GetComponent<Red_Hood>().enabled = true;
        red_Hood.GetComponent<Animator>().SetBool("Idle", false);
        title.SetActive(false);
    }
}
