using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField]
    private string[] abilities;
    public int health;

    [SerializeField]
    private Sprite deadCharacter;
    private Sprite characterSprite;

    // Start is called before the first frame update
    void Start()
    {
        characterSprite = gameObject.GetComponent<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die()
    {
        characterSprite = null;
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }
}
