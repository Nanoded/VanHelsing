using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Red_Hood : MonoBehaviour
{
    #region Variables
    [Header(header: "Check Ground Settings")]
    #region
    [SerializeField] Transform circleColl;
    [SerializeField] float radius;
    [SerializeField] LayerMask layer;
    #endregion

    [Header(header: "Move Settings")]
    #region
    [SerializeField] float jumpForce;
    [SerializeField] AnimationCurve curveMove;
    float horizontal;
    #endregion

    [Header(header: "Other")]
    #region
    [SerializeField] DataStorage dataStorage;
    [SerializeField] GameObject respawn;
    [SerializeField] GameObject deadScreen;
    public float maxHealth;
    public float currentHealth;
    public int countCoin;
    #endregion

    [Header(header: "Attack")]
    #region 
    [SerializeField] GameObject bomb;
    [SerializeField] Transform startThrowing;
    [SerializeField] float forceThrowing;
    [SerializeField] Text countBomb;
    [SerializeField] GameObject weapon;
    #endregion

    #region Bools
    bool isGround = true;
    bool isJumping = false;
    bool lookRight = true;
    bool isAttack = false;
    #endregion

    Rigidbody2D rb;
    Animator anim;
    #endregion

   

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth * dataStorage.healthBuff;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        isGround = Physics2D.OverlapCircle(circleColl.position, radius, layer);

        if (currentHealth > 100)
            currentHealth = 100;

        if (currentHealth <= 0)
        {
            anim.SetBool("Dead", true);
        }
        else
        {
            Jump();
            Move();
            if (Convert.ToInt32(countBomb.text) > 0)
                Throw();
            if (isAttack == false)
                Attack();
        }
    }

    public void DestroyAfterDead()
    {
        if (gameObject != null)
            Destroy(gameObject);

        deadScreen.SetActive(true);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "DeathTrigger")
        {
            currentHealth -= 10;
            if (currentHealth > 0)
                transform.position = respawn.transform.position;
            else
                DestroyAfterDead();
        }

        if (collision.CompareTag("HealthPotion"))
        {
            currentHealth += 10;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("BombCollect"))
        {
            countBomb.text = (Convert.ToInt32(countBomb.text) + 1).ToString();
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("Coins"))
        {
            dataStorage.coins += 1;
            Destroy(collision.gameObject);
            countCoin++;
            Debug.Log("coin ++");
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        StartCoroutine(OffDamage(0.5f));
    }

    private IEnumerator OffDamage(float sec)
    {
        anim.SetBool("GetDamage", true);
        yield return new WaitForSeconds(sec);
        anim.SetBool("GetDamage", false);
    }

    #region Move Character
    void Jump()
    {
        if (isGround == true)
        {
            isJumping = false;
            anim.SetBool("Jump", false);
            if (Input.GetKeyDown(KeyCode.C))
            {
                isGround = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        else
        {
            isJumping = true;
            anim.SetBool("Jump", true);
        }
    }

    void Move()
    {
        if (Mathf.Abs(horizontal) > 0.01)
        {
            rb.velocity = new Vector2(curveMove.Evaluate(horizontal), rb.velocity.y);
            if(isJumping == false)
                anim.SetBool("Run", true);
        }
        else
            anim.SetBool("Run", false);

        if (horizontal < 0 && lookRight == true)
            FlipX();
        else if (horizontal > 0 && lookRight == false)
            FlipX();
    }

    void FlipX()
    {
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        lookRight = !lookRight;
    }    

    void Attack()
    { 
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isAttack = true;
            GetComponentInParent<Animator>().SetBool("Attack", true);
            weapon.SetActive(true);
            
            StartCoroutine(AttackTime());
        }
    }

    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(0.03f);
        weapon.SetActive(false);
        yield return new WaitForSeconds(1);
        GetComponentInParent<Animator>().SetBool("Attack", false);
        isAttack = false;
    }

    void Throw()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            anim.SetBool("Throw", true);
            GameObject currentBomb;
            currentBomb = Instantiate(bomb, startThrowing.position, Quaternion.identity);
            if(lookRight == true)
                currentBomb.GetComponent<Rigidbody2D>().velocity = new Vector2(forceThrowing * 1, currentBomb.transform.position.y);
            else
                currentBomb.GetComponent<Rigidbody2D>().velocity = new Vector2(forceThrowing * -1, currentBomb.transform.position.y);

            countBomb.text = (Convert.ToInt32(countBomb.text) - 1).ToString();
        }
    }

    void offThrow()
    {
        anim.SetBool("Throw", false);
    }
    #endregion
}
