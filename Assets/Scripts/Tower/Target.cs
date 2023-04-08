using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public event UnityAction<Target> BulletHit;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }
    public void Break()
    {
        BulletHit?.Invoke(this);
        Destroy(gameObject);
    }
}
