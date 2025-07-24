using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents;
    [SerializeField]public string promptMessage;


    public virtual string onLook()
    {
        // This method is intended to be called when the interactable object is looked at
        // It can be overridden in derived classes to provide specific look behavior
        return promptMessage;
    }

    public void baseInteract()
    {
        // This method is intended to be called when the interactable object is interacted with
        // It can be overridden in derived classes to provide specific interaction behavior
        if(useEvents)
            GetComponent<InteractionEvent>()?.onInteract?.Invoke();
        Interact();
    }
    protected virtual void Interact()
    {

        // This method should be overridden in derived classes to define specific interaction behavior

       
    }
   
}
