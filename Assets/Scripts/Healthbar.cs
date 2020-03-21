using UnityEngine.UI;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public Text Health;
    private float HP = 0;

    void Update()
    {
        // Displaying the health on screen
        Health.text = "HP   " + HP.ToString();
    }

    public void GetHealth(float x)
    {
        HP = x;
    }
}
