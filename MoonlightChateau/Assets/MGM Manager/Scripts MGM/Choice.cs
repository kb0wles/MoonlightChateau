using UnityEngine;
using UnityEngine.SceneManagement;
public class Choice : MonoBehaviour
{
    int correct = 2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Yes()
    {
        int check = FinalChoice.Instance.getSuspectnum();
        Debug.Log(check);
        if (check == correct)
        {
            // load true ending
        }
        else if (check != correct)
        {
            // load mistake ending
        }
    }
}
