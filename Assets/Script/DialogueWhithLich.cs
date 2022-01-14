using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class DialogueWhithLich : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] Text dialogue;
    [SerializeField] CinemachineVirtualCamera cam1;
    [SerializeField] CinemachineVirtualCamera cam2;
    [SerializeField] CinemachineVirtualCamera cam3;
    [SerializeField] GameObject red_Hood;
    [SerializeField] GameObject block;
    [SerializeField] GameObject lichInfo;
    [SerializeField] Lich lich;
    [SerializeField] WeaponLich weaponLich;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Red_Hood")
        {
            block.SetActive(true);
            red_Hood.GetComponent<Animator>().SetBool("Idle", true);
            red_Hood.GetComponent<Red_Hood>().enabled = false;
            StartCoroutine(Dialogue());
        }
    }


    IEnumerator Dialogue()
    {
        cam2.Priority = 100;
        cam1.Priority = 1;
        title.SetActive(true);
        yield return new WaitForSeconds(3);
        dialogue.text = "Елена: -А вот и Лич собственной персоной";
        yield return new WaitForSeconds(5);
        dialogue.text = "Лич: -Эй ты! Ты и твой друг гигант! Проваливайте, а не то пожалеете!";
        yield return new WaitForSeconds(7);
        dialogue.text = "Лич: -Я - Великий Король Лич! Я самый могущественный в этом лесу! Страшитесь меня!";
        yield return new WaitForSeconds(7);
        cam1.Priority = 100;
        cam2.Priority = 1;
        dialogue.text = "Елена: -Ну вот... Каждый раз одно и то же... Давай рассказывай почему ты здесь? Без поддержки ты бы не рискнул возвращаться в лес.";
        yield return new WaitForSeconds(5);
        cam2.Priority = 100;
        cam1.Priority = 1;
        dialogue.text = "Лич: -Ты права! Но я не собираюсь тебе ничего говорить! Катись к чертям, Ван Хельсинг!";
        yield return new WaitForSeconds(5);
        cam1.Priority = 100;
        cam2.Priority = 1;
        dialogue.text = "Елена: -Ну всё! Ты огребаешь!";
        yield return new WaitForSeconds(3);
        cam3.Priority = 100;
        cam2.Priority = 1;
        cam1.Priority = 1;


        red_Hood.GetComponent<Red_Hood>().enabled = true;
        red_Hood.GetComponent<Animator>().SetBool("Idle", false);
        title.SetActive(false);
        lichInfo.SetActive(true);
        lich.enabled = true;
        weaponLich.enabled = true;
        gameObject.SetActive(false);
    }
}
