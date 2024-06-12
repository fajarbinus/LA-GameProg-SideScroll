using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TypeTag
{
    Player,
    Trap,
    Checkpoint,
    Finish,
    Trigger,
    Enemy,
}

public class TriggerEvent : MonoBehaviour
{
    public TypeTag targetTag;

    public UnityEvent<GameObject> OnTrigger;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == targetTag.ToString())
        {
            Debug.Log(gameObject.name + "kena sama" + col.gameObject.name);
            OnTrigger?.Invoke(col.gameObject);
        }
    }
    
}
