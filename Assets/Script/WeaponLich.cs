using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLich : MonoBehaviour
{
    [SerializeField] GameObject ghost;
    [SerializeField] GameObject dotCreatingGhosts;
    [SerializeField] GameObject target;
    GameObject currentGhost;

    private void Update()
    {
        
            if (currentGhost != null)
            {
                currentGhost.transform.position = Vector3.MoveTowards(currentGhost.transform.position, target.transform.position, Time.deltaTime * 2);
                StartCoroutine(DestroyGhost());
            }
            
            CreatingGhost();
    }

    void CreatingGhost()
    {

        if (currentGhost == null)
            currentGhost = Instantiate(ghost, dotCreatingGhosts.transform.position, Quaternion.identity);
    }

    IEnumerator DestroyGhost()
    {
        yield return new WaitForSeconds(4);
        Destroy(currentGhost);
        yield return new WaitForSeconds(5);
        StopAllCoroutines();
    }
}
