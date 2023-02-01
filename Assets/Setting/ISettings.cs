using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public interface ISettings
{
    public void Save( bool value );
    public void Load();
}
