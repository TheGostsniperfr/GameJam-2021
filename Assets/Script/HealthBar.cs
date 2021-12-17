using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        //initialisation de la bar de vie, couleur, value, ...
        slider.maxValue = health;
        slider.value = health;

        //gradient = dégradé
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue); //on recup la valeur du slider, on la normalise car slider va de 0 à 100 or le gradient va de 0 à 1 ( normalisedValue permet de mettre la valeur entre 0 et 1 !) 
    }
}