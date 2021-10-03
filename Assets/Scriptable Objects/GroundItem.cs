using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundItem : MonoBehaviour, ISerializationCallbackReceiver
{
    public ItemObject item;

    public void OnAfterDeserialize()
    {
    }

    public void OnBeforeSerialize()
    {
        //Debug.Log(item);
        //Debug.Log(item.uiDisplay);
        //Debug.Log(GetComponentInChildren<SpriteRenderer>());

        // Error here means your likely mising the sprite renderer on the object
        GetComponentInChildren<SpriteRenderer>().sprite = item.uiDisplay;
        //Debug.Log("sprite rendereer");
        //Debug.Log(GetComponentInChildren<SpriteRenderer>());
        EditorUtility.SetDirty(GetComponentInChildren<SpriteRenderer>());
    }
}
