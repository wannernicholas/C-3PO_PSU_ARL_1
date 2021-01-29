using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : Command
{
    private Transform playerTransform;

    private float distance;
    private float speed;
    private Coroutine co;
    private Queue<string> coQueue;

    public void init(string name, Transform playerTransform, float distance, float speed)
    {
        base.init(name);
        this.distance = distance;
        this.speed = speed;
        this.playerTransform = playerTransform;
        coQueue = new Queue<string>();
    }

    public override void doCommand(string command)
    {
        if (co != null) //refuse to do movement command if another movement is already in process
        {
            coQueue.Enqueue(command);
            return;
        }

        switch (command.ToLower())
        {
            case "forward":
                setPlayerRotation(0f);
                break;
            case "backward":
                setPlayerRotation(180f);
                break;
            case "right":
                setPlayerRotation(90f);
                break;
            case "left":
                setPlayerRotation(270f);
                break;
            default:
                Debug.LogWarning("Movement command '" + command + "' is not recognized by this command module");
                break;
        }
        move();
    }

    private void setPlayerRotation(float yRot)
    {
        playerTransform.rotation = Quaternion.Euler(0f, yRot, 0f);
    }

    private void move()
    {
        co = EventManager.instance.StartCoroutine(waitForMove());
    }

    private IEnumerator waitForMove()
    {
        float distancedTraveled = 0f;
        while (distancedTraveled < distance)
        {
            float distanceToMove = speed * Time.deltaTime;
            distancedTraveled += distanceToMove;
            playerTransform.Translate(new Vector3(0f, 0f, distanceToMove));
            yield return new WaitForSeconds(0.05f);
        }
        co = null;
        if (coQueue.Count > 0)
        {
            doCommand(coQueue.Dequeue());
        }
    }
}