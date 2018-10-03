using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlatforms : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
