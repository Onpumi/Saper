using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public interface ISettings
{

    public bool Exists(string key);
    public void Save<T>(string key, T saveObject);
    public T Load<T>(string key, T loadObject);
}
