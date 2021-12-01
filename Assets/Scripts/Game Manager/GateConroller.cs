using UnityEngine;

public class GateConroller : MonoBehaviour
{
    public int id;

    
    void Start()
    {
        GameEventSystem.ge_instance.onDoorTrigger += OnDoorOpen;
        GameEventSystem.ge_instance.onDoorTriggerExit += OnDoorClose;
    }

    private void OnDoorOpen(int id)
    {
        if(id==this.id)
            LeanTween.moveLocalY(gameObject, 1.6f, 1f).setEaseOutQuad();
    }

    private void OnDoorClose(int id)
    {
        if(id==this.id)
            LeanTween.moveLocalY(gameObject, .2f, 1f).setEaseInQuad();
    }

    private void OnDestroy()
    {
        //Silindiği zaman null reference exception almamak için.
        GameEventSystem.ge_instance.onDoorTrigger -= OnDoorOpen;
        GameEventSystem.ge_instance.onDoorTriggerExit -= OnDoorClose;

    }

}
