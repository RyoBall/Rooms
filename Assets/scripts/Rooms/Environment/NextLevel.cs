using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(gameManager.instance.currentState==gameManager.GameState.Normal)
        nextlevel();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void nextlevel()
    {
        Blacker.instance.Enter(1, 2);
        gameManager.currentlevel++;
        StartCoroutine(NextCoroutine());
    }
    IEnumerator NextCoroutine()
    {
        yield return new WaitForSeconds(2f);
        if(gameManager.currentlevel!=3)
        SceneManager.LoadScene("ReLoad");
        else
        SceneManager.LoadScene("Enter");
    }
}
