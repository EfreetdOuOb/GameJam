using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public PlayerController playerController;

    public BaseState(PlayerController _playerController)
    {
        playerController = _playerController;
    } 
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void OnTriggerEnter2D(Collider2D collision); 
}
public class Idle : BaseState
{

    public Idle(PlayerController _playerController) : base(_playerController)
    {
        playerController.PlayAnimation("Idle");
        playerController.Stop();
    }

    public override void Update()
    {
        if (playerController.PressArrowKey())
        {
            playerController.SetCurrentState(new Walk(playerController));
        }
        if (playerController.PressedJumpKey())
        {
            playerController.SetCurrentState(new Jump(playerController));
        }


    }

    public override void FixedUpdate()
    {

    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ÀË´ú¨ì¸I¼²: " + collision.name);

    }

}

public class Walk : BaseState
{
    public Walk(PlayerController _playerController) : base(_playerController)
    {
        playerController.PlayAnimation("Walk");
    }


    public override void Update()
    {
        if (!playerController.PressArrowKey())
        {
            playerController.SetCurrentState(new Idle(playerController));
        }
        if (playerController.PressedJumpKey())
        {
            playerController.SetCurrentState(new Jump(playerController));
        }
    }

    public override void FixedUpdate()
    {
        playerController.Move();
        playerController.Face();
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ÀË´ú¨ì¸I¼²: " + collision.name);

    }
}
public class Jump : BaseState
{
    public Jump(PlayerController _playerController) : base(_playerController)
    {
        playerController.PlayAnimation("Jump");
        playerController.Jump();
    }


    public override void Update()
    {
        if (playerController.IsAnimationDone("Jump")&&!playerController.PressArrowKey())
        {
            playerController.SetCurrentState(new Idle(playerController));
        }
        else if(playerController.IsAnimationDone("Jump") &&playerController.PressArrowKey())
        {
            playerController.SetCurrentState(new Walk(playerController));
        }
    }

    public override void FixedUpdate()
    {
        playerController.Move();
        playerController.Face();
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ÀË´ú¨ì¸I¼²: " + collision.name);

    }

}