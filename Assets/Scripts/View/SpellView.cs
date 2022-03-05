using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpellView : MonoBehaviour
{
    private Rigidbody2D rgb;
    [SerializeField] private float speed;
    public Transform target { get; private set; }
    [SerializeField]
    private float damage;

    public float MyDamage
    {
        get
        {
            return damage;
        }
    }

    private void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
       
    }

    public void Initialize(Transform target,float damage)
    {
        this.target = target;
        this.damage = damage;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
           
            rgb.velocity = direction.normalized * speed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "hitBox" && col.transform==target)
        {
            speed = 0;
            col.GetComponentInParent<EnemyController>().takeDamage(damage);
            GetComponent<Animator>().SetTrigger("impact");
            rgb.velocity=Vector2.zero;
            target = null;
        }
    }
}
