using UnityEngine;
using System;

public class GameEventSystem : MonoBehaviour
{
    //Singleton
    public static GameEventSystem ge_instance;

    //Observer Events

    private void Awake()
    {
        ge_instance = this;
    }

    //Trigger olduğu zaman
    public event Action<int> onDoorTrigger;
    public event Action<int> onDoorTriggerExit;

    public void DoorTrigger(int id)
    {
        if (onDoorTrigger != null)
        {
            onDoorTrigger(id);
        }
    }

    public void DoorTriggerExit(int id)
    {
        if (onDoorTriggerExit != null)
        {
            onDoorTriggerExit(id);
        }
    }
}
