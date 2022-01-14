using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class TutorialWalkAndThrow : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] Text dialogue;
    [SerializeField] CinemachineVirtualCamera cam1;
    [SerializeField] CinemachineVirtualCamera cam2;
    [SerializeField] GameObject red_Hood;

    void Start()
    {
        red_Hood.GetComponent<Animator>().SetBool("Idle", true);
        red_Hood.GetComponent<Red_Hood>().enabled = false;
        StartCoroutine(Dialogue());
    }

    IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(3);
        dialogue.text = "Елена: -Привет привет! Все в порядке. Уже соскучилась по работе! ";
        yield return new WaitForSeconds(3);
        dialogue.text = "Учитель: -Просто прекрасно! Что ж... Давай проверим не растеряла ли ты свои навыки.";
        yield return new WaitForSeconds(4);
        cam2.Priority = 100;
        dialogue.text = "Учитель: -Позади меня лежит бомба. Подберии ее и брось в мишень на краю обрыва.";
        cam1.Priority = 1;
        yield return new WaitForSeconds(4);
        cam1.Priority = 100;
        dialogue.text = "Учитель: -Эй ты! Да да, именно ты! Тот что по другую сторону монитора!" +
            " Для того что бы передвигаться используй стрелочки! Для броска используй X.";
        cam2.Priority = 1;
        yield return new WaitForSeconds(7);
        dialogue.text = "Елена: -Ты с кем разговариваешь? Мы живем в XVII веке! Какие мониторы?";
        yield return new WaitForSeconds(3);
        dialogue.text = "Учитель: -Я говорю бери бомбу и швыряй!";
        yield return new WaitForSeconds(2);
        dialogue.text = "Учитель: -...";
        yield return new WaitForSeconds(2);
        dialogue.text = "Учитель: -Не забудь! Жми Х... Бросать советую от флага...";
        yield return new WaitForSeconds(2);
        title.SetActive(false);
        red_Hood.GetComponent<Red_Hood>().enabled = true;

        red_Hood.GetComponent<Animator>().SetBool("Idle", false);
    }
}
