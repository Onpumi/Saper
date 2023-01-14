using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

    public class EntyPoint : SerializedMonoBehaviour
    {
        [SerializeField] private List<ICompositeRoot> _roots;
        private void Awake() => _roots.ForEach(root => root.Compose());
    }