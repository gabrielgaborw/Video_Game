using UnityEngine.UI;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public Text sc;
    public float score = 0;
    public float Kscore = 0;

    void Update()
    {
        score = Kscore + Time.time * 10;
        sc.text = "Score    " + score.ToString("0");
    }

    public void AddScore()
    {
        Kscore += 1000;
    }
}
