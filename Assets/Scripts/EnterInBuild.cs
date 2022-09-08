using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterInBuild : MonoBehaviour
{
    string sceneName;
    public Vector3 position;
    public VectorValue playerStorage;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = gameObject.name;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Input.GetAxis("Vertical") > 0 && sceneName != "Exit")
            {
                playerStorage.initialValue = position;
                SceneManager.LoadScene(sceneName);
            }
            if (Input.GetAxis("Vertical") < 0 && sceneName == "Exit")
            {
                playerStorage.initialValue = position;
                SceneManager.LoadScene(0); 
            }
        }
    }
}
