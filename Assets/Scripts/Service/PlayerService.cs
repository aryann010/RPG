using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerService 
{
    public PlayerView playerView;
    public void handleLayers()
    {
        if (playerView.Weapon == 1 && playerView.isMoving)
        {
            activateLayer("WalkWeapon");
            playerView.animator.SetFloat("horizontal", playerView.direction.x);
            playerView.animator.SetFloat("vertical", playerView.direction.y);
            playerView.stopAttack();
        }
        else if (playerView.Weapon == 1 && playerView.isFireAttack)
        {

            activateLayer("FireAttack");


        }
        else if (playerView.Weapon == 1 && playerView.isIceAttack)
        {
            activateLayer("IceAttack");

        }
        else if (playerView.Weapon == 1 && playerView.isSwordAttack)
        {
            activateLayer("SwordAttack");
        }
        else if (playerView.isMoving)
        {

            activateLayer("Walk");
            playerView.animator.SetFloat("horizontal", playerView.direction.x);
            playerView.animator.SetFloat("vertical", playerView.direction.y);
            playerView.stopAttack();
        }

        else if (playerView.Weapon == 1)
        {
            activateLayer("IdleWeapon");
        }
        else if (playerView.Weapon == 0)
        {
            activateLayer("Idle");
        }


    }

    public void activateLayer(string layername)
    {
        for (int i = 0; i < playerView.animator.layerCount; i++)
        {
            playerView.animator.SetLayerWeight(i, 0);
        }
        playerView.animator.SetLayerWeight(playerView.animator.GetLayerIndex(layername), 1);
    }
    public virtual void takeDamage(float damage)
    {
        playerView.stats.MyCurrentValue -= damage;
        if (playerView.stats.MyCurrentValue <= 0)
        {
            playerView.animator.SetTrigger("die");
        }
    }
    public void getInput()
    {
        Debug.Log("heyaaaaa");

        if (Input.GetKey(KeyCode.I))
        {

            playerView.stats.MyCurrentValue -= 10;



        }

        if (Input.GetKey(KeyCode.O))
        {

            playerView.stats.MyCurrentValue += 10;


        }

        if (Input.GetKey(KeyCode.E))
        {
            playerView.Weapon = 1;
        }

        if (Input.GetKey(KeyCode.R))
        {
            playerView.Weapon = 0;
        }



        playerView.direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            playerView.exitIndex = 0;
            playerView.direction = Vector2.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerView.exitIndex = 3;
            playerView.direction = Vector2.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerView.exitIndex = 2;
            playerView.direction = Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerView.exitIndex = 1;
            playerView.direction = Vector2.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerView.swordAttack();
        }
    }

}
