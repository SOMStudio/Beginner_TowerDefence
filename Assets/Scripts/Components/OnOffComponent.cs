using UnityEngine;
using UnityEngine.Events;

public class OnOffManager : MonoBehaviour
{
    public Animator animatorRef;

    public UnityEvent onEvent;
    public UnityEvent offEvent;
    
    private bool stateOnOff;
    
    public void On()
    {
        stateOnOff = true;
        animatorRef.Play("On");
        
        onEvent.Invoke();
    }

    public void Off()
    {
        stateOnOff = false;
        animatorRef.Play("Off");
        
        offEvent.Invoke();
    }

    public void Switch()
    {
        if (stateOnOff == true)
        {
            Off();
        }
        else
        {
            On();
        }
    }
}
