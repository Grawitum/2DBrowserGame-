using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField]
    private TrailRenderer _trail;

    public void SetVisible(bool visible)
    {
        if (_trail) _trail.enabled = visible;
        if (_trail) _trail.Clear();
        this.gameObject.transform.GetComponent<SpriteRenderer>().enabled = visible;
    }

}
