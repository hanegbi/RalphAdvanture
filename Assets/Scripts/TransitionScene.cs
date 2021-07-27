using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{

    public Animator transAnim;
    // Start is called before the first frame update
    void Start()
    {
        transAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void LoadScene(string scene)
    {
        StartCoroutine(Transition(scene));
    }

    IEnumerator Transition(string scene)
    {
        transAnim.SetTrigger("end");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(scene);
    }
}
