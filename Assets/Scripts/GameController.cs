﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClickTarget(); 
    }

    private void ClickTarget()
    {
        
        if (Input.GetMouseButtonDown(0)&& !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                Mathf.Infinity, 512);
            if (hit.collider != null)
            {
                if (hit.collider.tag =="enemy")
                {

                    player.target = hit.transform.GetChild(0);
                }
            }
            else
            {
                player.target = null;
            }
        }
    }
}
