using UnityEngine;
using UnityEngine.Events;

public class DraggingSystem : MonoBehaviour
{
    [SerializeField] private CoffeeAssemble.AssembleStep stepToAction;
    [Space(5)]
    [SerializeField] private Transform defaultPosition;
    [SerializeField] private GameObject specifiedTriggerZone;
    [Space(5)]
    [SerializeField] private UnityEvent doOnAction;

    private bool actionIsDone;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void OnMouseDown()
    {
        if(CoffeeAssemble.instance.assembleStep != stepToAction) return;
        specifiedTriggerZone.SetActive(true);
    }

    private void OnMouseDrag()
    {
        if(CoffeeAssemble.instance.assembleStep != stepToAction) return;
        transform.position = GetMousePosition();
    }

    private void OnMouseUp()
    {
        if (!actionIsDone)
            transform.position = defaultPosition.position;
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != specifiedTriggerZone) return;
        actionIsDone = true;
        specifiedTriggerZone.SetActive(false);
        doOnAction.Invoke(); 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        actionIsDone = false;
    }

    public void NextStep()
    {
        CoffeeAssemble.instance.assembleStep++;
    }

    public void DoneAction()
    {
        actionIsDone = false;
        transform.position = defaultPosition.position;
    }

    public void AddMilk()
    {
        CoffeeAssemble.instance.coffeeExtras.Milk = true;
    }

    public void AddCream()
    {
        CoffeeAssemble.instance.coffeeExtras.Cream = true;
    }

    public void AddSugar()
    {
        CoffeeAssemble.instance.coffeeExtras.Sugar++;
    }
}
