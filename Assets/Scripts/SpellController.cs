using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    private Rigidbody2D rgb;
    [SerializeField] private float speed;
    private Transform target;

    private void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("target").transform;
    }

    private void FixedUpdate()
    {
        Vector2 direction = target.position - transform.position;
        rgb.velocity = direction.normalized * speed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
