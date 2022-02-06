using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    private Rigidbody2D rgb;
    [SerializeField] private float speed;
    public Transform target { get; set; }

    private void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
       
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
            GetComponent<Animator>().SetTrigger("impact");
            rgb.velocity=Vector2.zero;
            target = null;
        }
    }
}
