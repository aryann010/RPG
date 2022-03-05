using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameService : MonoBehaviour
{
    [SerializeField] private PlayerView player;

    private NPC currentTarget;
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

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                Mathf.Infinity, 512);
            if (hit.collider != null)
            {
                if (currentTarget != null)
                {
                    currentTarget.deSelect();
                }

                currentTarget = hit.collider.GetComponent<NPC>();
               
                    //Debug.Log(player.target);
                    player.target = currentTarget.select();
                
               
            }

            else
            {
                if (currentTarget != null)
                {
                    currentTarget.deSelect();
                }

                currentTarget = null;
                player.target = null;
            }
        }
    }
}
