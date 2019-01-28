using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ReferenceList<T> : ScriptableObject {

    public List<T> References = new List<T>();

    public void Add(T item) {

        if(!References.Contains(item))
        References.Add(item);

    }

    public void Remove(T item)
    {
        if (References.Contains(item))
            References.Remove(item);

    }

}
