using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour
{
    [SerializeField] Red_Hood red_Hood;
    [SerializeField] Lich lich;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(red_Hood != null)
            image.fillAmount = red_Hood.currentHealth / red_Hood.maxHealth;
        if(lich != null)
            image.fillAmount = lich.currentHealth / lich.health;
    }
}
