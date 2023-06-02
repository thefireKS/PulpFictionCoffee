using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ClickingSystem : MonoBehaviour
{
    [SerializeField] private CoffeeAssemble.AssembleStep stepToAction;
    [Space(5)]
    [SerializeField] private UnityEvent doOnAction;
    
    private void OnMouseUp()
    {
        if(CoffeeAssemble.instance.assembleStep != stepToAction) return;
        doOnAction?.Invoke();
    }
    
    public void NextStep()
    {
        CoffeeAssemble.instance.assembleStep++;
    }

    public void CheckForCoffeeRecipe(string NextSceneName)
    {
        SceneManager.LoadScene(CoffeeAssemble.instance.coffeeExtras == CoffeeAssemble.instance.currentRecipe
            ? NextSceneName
            : SceneManager.GetActiveScene().name);
    }
}
