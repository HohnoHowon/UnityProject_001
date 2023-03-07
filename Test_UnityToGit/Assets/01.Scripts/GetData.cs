using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetData : MonoBehaviour
{
    public Entity_Sheet1 entity_Sheet1;

    void Start()
    {
        foreach(Entity_Sheet1.Param param in entity_Sheet1.sheets[0].list)
        {
            Debug.Log(param.index + " - " + param.character + " - " + param.Hp + " - " + param.Hp);
        }   
    }
}
