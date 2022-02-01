using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed;
    protected Vector2 direction;

    protected virtual void Update()
    {
        move();
    }

    private void move()
    {
        transform.Translate( direction * speed * Time.deltaTime);
        
    }
}
