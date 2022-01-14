using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Transform[] backImages;
    [SerializeField] float[] coeff;

    int backArrayCount;

    void Start()
    {
        backArrayCount = backImages.Length;       
    }

    
    void Update()
    {
        for(int i = 0; i < backArrayCount; i++)
        {
            backImages[i].position = new Vector3(transform.position.x * coeff[i], backImages[i].position.y, backImages[i].position.z);
        }
    }
}
