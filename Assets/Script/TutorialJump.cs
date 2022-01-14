using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class TutorialJump : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] Text dialogue;
    [SerializeField] CinemachineVirtualCamera cam1;
    [SerializeField] CinemachineVirtualCamera cam3;
    [SerializeField] GameObject red_Hood;
    [SerializeField] GameObject secondLesson;
    [SerializeField] Teacher teacher;

    void Start()
    {
        red_Hood.GetComponent<Animator>().SetBool("Idle", true);
        red_Hood.GetComponent<Red_Hood>().enabled = false;
        StartCoroutine(Dialogue());
    }

    IEnumerator Dialogue()
    {
        teacher.secondPos = false;
        cam3.Priority = 100; 
        cam1.Priority = 1;
        secondLesson.SetActive(false);
        yield return new WaitForSeconds(7);
        dialogue.text = "Елена: -Скажи это тому огромному человеку за экраном! И почему я не могу двигаться во время диалога?";
        yield return new WaitForSeconds(7);
        dialogue.text = "Учитель: -Ты тоже его видишь?!";
        yield return new WaitForSeconds(4);
        dialogue.text = "Учитель: -Значит слушай меня... Эм... Как мне тебя называть? Небоскреб? Почему ты такой огромный? Посмотри на себя и посмотри на нас!";
        yield return new WaitForSeconds(7);
        dialogue.text = "Учитель: -Ладно... Слушай внимательно! За мной находятся платформы, которые охраняет призрак. Его невозможно убить без специального оружия. " +
            "Поэтому придется либо обскакать его, либо получить по роже и идти дальше. Но не переживай за полученный урон. На последней платформе тебя ждет приятный бонус.";
        yield return new WaitForSeconds(15);
        dialogue.text = "Елена: -Это конечно хорошо... Но я бы предпочла иметь максимум здоровья.";
        yield return new WaitForSeconds(7);
        dialogue.text = "Учитель: -Договорись об этом со своим новым напарником.";
        yield return new WaitForSeconds(5);
        dialogue.text = "Учитель: -Что бы прыгать нажимай С!";
        yield return new WaitForSeconds(5);
        dialogue.text = "Учитель: -Удачи!";
        yield return new WaitForSeconds(2);
        cam1.Priority = 100;
        cam3.Priority = 1;
        red_Hood.GetComponent<Red_Hood>().enabled = true;
        red_Hood.GetComponent<Animator>().SetBool("Idle", false);
        title.SetActive(false);
    }
}
