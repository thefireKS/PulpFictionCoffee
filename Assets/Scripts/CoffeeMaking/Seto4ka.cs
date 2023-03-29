using UnityEngine;

public class Seto4ka : MonoBehaviour
{
    [SerializeField] private WaterBase waterBase;
    [SerializeField] private Sprite waterBaseWithSeto4ka;

    [SerializeField] private SpriteRenderer WaterBaseSpriteRenderer;
    private void OnMouseDown()
    {
        if (!waterBase.isFilledWithWater) return;
        WaterBaseSpriteRenderer.sprite = waterBaseWithSeto4ka;
        waterBase.isSetWithSeto4ka = true;
        gameObject.SetActive(false);
    }
}
