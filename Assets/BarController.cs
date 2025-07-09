using UnityEngine;
using UnityEngine.UI;


public class BarController : MonoBehaviour
{
    public Slider slider;
    public GameObject Bar;
    public GameObject Text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetMAXHealth(float x){
        slider.maxValue = x;
        slider.value = x;
    }

    public void SetHealth(float x){
        slider.value = x;
    }

    public void initializeHealth(){
        Bar.SetActive(true);
        Text.SetActive(true);
    }

    public void deactivateHealth(){
        Bar.SetActive(false);
        Text.SetActive(false);
    }

}
