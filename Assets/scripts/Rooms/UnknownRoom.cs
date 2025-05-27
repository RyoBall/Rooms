using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnknownRoom : MonoBehaviour, RoomPosition
{
    public Vector2 Position { get; set; }

    private void OnMouseDown()
    {
        if (RoomBase.Correc(Position.x - Player.instance.currentRoom.GetComponent<RoomBase>().Position.x) + RoomBase.Correc(Position.y - Player.instance.currentRoom.GetComponent<RoomBase>().Position.y) <= 1 && gameManager.instance.currentState == gameManager.GameState.Normal)
        {
            if (segment.instance.targetroom == null)
            {
                segment.instance.targetroom = this;
                gameManager.instance.currentState = gameManager.GameState.Rolling;
                segment.instance.UIEnter();
            }
        }
    }
}
