using Sirenix.OdinInspector;
using UnityEngine;

public class CompositeGridCells : SerializedMonoBehaviour, ICompositeRoot
{
    [SerializeField] private GridCellsView _gridCellsView;

    public void Compose()
    {
        _gridCellsView.Compose();
    }
}
