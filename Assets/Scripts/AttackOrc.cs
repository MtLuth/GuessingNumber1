using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackOrc : MonoBehaviour
{
    public Text orcTalk;
    public GameObject orcBubble;
    public GameObject princeBubble;
    private Rigidbody2D rb;
    private float velocity = 0f;
    private bool canmove = true;
    private Animator animator;
    private Animator orcAnimator;
    public GameObject orc;
    private bool orcDeath = false;
    private GameManager gameManager;
    public GameObject princessWin;
    public GameObject princess;
    private AudioSource orcSound;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        orcAnimator = orc.GetComponent<Animator>();
        orcSound = orc.GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        orcDeath = false;
        Debug.Log(orcDeath);
    }
    private void Update()
    {
        rb.velocity = new Vector2(velocity * 1, rb.velocity.y);
        if (orcTalk.text == "Nooooooo!" && canmove)
        {
            GameObject.Destroy(princeBubble);
            velocity = 3f;
            animator.SetBool("Run", true);
        }
        if (rb.transform.position.x >= 0f && !orcDeath)
        {
            canmove = false;
            velocity = 0f;
            animator.SetBool("Atk", true);
        }
        if (orcDeath != false)
        {
            StartCoroutine(gameManager.WinState(orcDeath));
        }
    }
    IEnumerator WinState()
    {
        yield return new WaitForSeconds(3f);
        gameManager.WinState(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Orc"))
        {
            GameObject.Destroy(orcBubble);
            GameObject.Destroy(princess);
            orcSound.Play();
            princessWin.SetActive(true);
            orcDeath = true;
            orcAnimator.SetTrigger("Dead");
            animator.SetBool("Run", false);
            animator.SetBool("Atk", false);
        }
    }
}
