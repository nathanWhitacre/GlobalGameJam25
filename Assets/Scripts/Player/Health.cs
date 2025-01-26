using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;

    [SerializeField] private float deathTime;
    private bool active;
    private bool dead;
    [SerializeField] private GameObject otherPlayer;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        dead = false;
        active = false;
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

    /// This will increase health
    public void increaseHealth()
    {
        health++;
    }

    /// This will decrease health
    [ContextMenu("DecreaseHealth")]
    public void decreaseHealth()
    {
        health--;
    }

    private void OnTriggerStay2D(Collider2D other)   
    {
        otherPlayer = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        otherPlayer = null;
    }

    IEnumerator Ghost()
    {
        Physics2D.IgnoreLayerCollision(6, 6, true);
        yield return new WaitForSeconds(deathTime);
        health++;
        dead = false;
        active = false;

        GameObject currOtherPlayer = otherPlayer;
        if (currOtherPlayer != null)
        {
            currOtherPlayer.gameObject.GetComponent<Health>().health = 0;
            currOtherPlayer = null;
        }
        Physics2D.IgnoreLayerCollision(6, 6, false);
    }
}
