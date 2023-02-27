using UnityEngine;
using  UnityEngine.UI;

public class MineView : MonoBehaviour, IMineView
{
    [SerializeField] private BoomView _prefabBoomView;
    [SerializeField] private FlagView _prefabFlagView;
    [SerializeField] private float _scale = 0.5f;
    private void Awake()
    {
        transform.localScale = new Vector3(_scale, _scale,_scale);
        transform.gameObject.SetActive(false);
    }

    public float GetWidth()
    {
        return GetComponent<Image>().sprite.rect.width;
    }

    public float GetHeight()
    {
        return GetComponent<Image>().sprite.rect.height;
    }

    public void ActivateMine(Transform parent)
    {
        gameObject.SetActive(true);
        parent.GetComponent<Image>().color = Color.red;
        transform.localScale = Vector3.one * 0.7f;
    }

    public Transform GetTransform() => transform;

}
