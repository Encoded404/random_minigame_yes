using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]

    [SerializeField] private float startingHealth;

   
    private SpriteRenderer spriteRend;
  //  public AudioSource soundEffectPlayer;

    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
   // public Text Score;



    private void Awake()
    {
     //   soundEffectPlayer = GetComponent<AudioSource>();
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {


        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
      //  soundEffectPlayer.Play();

        if (currentHealth > 0)
        {
           // anim.SetTrigger("Hurt");
            //iframes

        }
        else
        {
            if (!dead)
            {
                PlayerDeath();
            }
        }

    }
    IEnumerator waiter()
    {


        //Wait for 4 seconds
        yield return new WaitForSecondsRealtime(4);



    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

     
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1);
        }

    }
    public void PlayerDeath()
    {
        // anim.SetBool("noBlood", m_noBlood);
        //anim.SetTrigger("Death");

        // GameOverScreen.Setup(2);
        RestartLevel();
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}