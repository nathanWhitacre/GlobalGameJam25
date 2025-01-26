using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool dead;
    public int health;
    public float deathTime;

    private bool active;
    private GameObject otherPlayer;

    [SerializeField] public AudioSource deathSound;
    [SerializeField] public AudioSource reviveSound;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        dead = false;
        active = false;
        reviveSound.loop = false;
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            dead = true;
        }
        if (dead && !active)
        {
            active = true;
            StartCoroutine(Ghost());
        }
    }

    private void OnTriggerStay2D(Collider2D other)   
    {
        if (other.transform.parent != null)
        {
            otherPlayer = other.transform.parent.gameObject;
        } else
        {
            otherPlayer = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        otherPlayer = null;
    }

    IEnumerator Ghost()
    {
        Physics2D.IgnoreLayerCollision(6, 6, true);
        GetComponent<CircleCollider2D>().enabled = true;

        yield return new WaitForSeconds(deathTime);
        reviveSound.Play();
        health++;
        dead = false;
        active = false;

        GameObject currOtherPlayer = otherPlayer;
        if (currOtherPlayer != null)
        {
            currOtherPlayer.gameObject.GetComponent<Health>().health = 0;
            currOtherPlayer = null;
        }

        GetComponent<CircleCollider2D>().enabled = false;
        Physics2D.IgnoreLayerCollision(6, 6, false);
    }

    public void damagePlayer()
    {
        deathSound.Play();
        health--;
    }

    public void healPlayer()
    {
        reviveSound.Play();
        health++;
    }
}
