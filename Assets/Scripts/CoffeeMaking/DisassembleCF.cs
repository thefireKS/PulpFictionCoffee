using UnityEngine;

public class DisassembleCF : MonoBehaviour
{
    [SerializeField] private GameObject[] coffeeMakerElements;
    [SerializeField] private WaterBase waterBase;

    private const float DOUBLE_CLICK_TIME = 0.33f;
    
    private float lastClickTime = 0;

    private void OnMouseDown()
    {
        lastClickTime = Time.time - lastClickTime;

        if (lastClickTime < DOUBLE_CLICK_TIME)
        {
            foreach (var cof in coffeeMakerElements)
            {
                cof.SetActive(true);
            }

            waterBase.spoonsOfCoffee = 0;
            waterBase.isFilledWithWater = false;
            waterBase.isSetWithSeto4ka = false;
            gameObject.SetActive(false);
        }

        lastClickTime = Time.time;
    }
}
