using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class LichDialogueAfterFight : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] Text dialogue;
    [SerializeField] CinemachineVirtualCamera cam1;
    [SerializeField] CinemachineVirtualCamera cam2;
    [SerializeField] GameObject red_Hood;
    [SerializeField] GameObject statistic;

    void Start()
    {
        red_Hood.GetComponent<Animator>().SetBool("Idle", true);
        red_Hood.GetComponent<Red_Hood>().enabled = false;
        StartCoroutine(Dialogue());
    }


    IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(5);
        dialogue.text = "Елена: -Расскажи кто надоумил тебя на захват леса?";
        yield return new WaitForSeconds(5);
        cam2.Priority = 100;
        cam1.Priority = 1;
        dialogue.text = "Лич: -Его имя нельзя называть! Все, кто посмел когда-либо сказать вслух его имя, мертвы. ";
        yield return new WaitForSeconds(7);
        dialogue.text = "Лич: -Я не хочу стать следующим. Но я могу рассказать где я его встретил.";
        yield return new WaitForSeconds(7);
        dialogue.text = "Лич: -Тебе придется обогнуть горный хребет через кладбище. Далее ты попадешь на болото. С его южного края виден заброшенный замок.";
        yield return new WaitForSeconds(7);
        dialogue.text = "Лич: -После нашего с ним разговора, он направился в ту сторону.";
        yield return new WaitForSeconds(7);
        cam1.Priority = 100;
        cam2.Priority = 1;
        dialogue.text = "Елена: -А почему я не могу обойти хребет с безопасной стороны? Зачем идти через кладбище и болото?";
        yield return new WaitForSeconds(5);
        cam2.Priority = 100;
        cam1.Priority = 1;
        dialogue.text = "Лич: -Так решил создатель.";
        yield return new WaitForSeconds(3);
        cam1.Priority = 100;
        cam2.Priority = 1;
        dialogue.text = "Елена: -Что?";
        yield return new WaitForSeconds(3);
        cam2.Priority = 100;
        cam1.Priority = 1;
        dialogue.text = "Лич: -Что?";
        yield return new WaitForSeconds(3);

        title.SetActive(false);
        gameObject.SetActive(false);
        statistic.SetActive(true);
    }
}
