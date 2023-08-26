using FeTo.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : Singleton<SceneTransitions>
{
    int nextScene;
    Animator animator;
    const string SCENE_OUT_TRIGGER = "SceneOut";

    protected void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void LoadScene(int nextScene)
    {
        this.nextScene = nextScene;
        animator.SetTrigger(SCENE_OUT_TRIGGER);
    }

    public void DoLoadScene()
    {
        SceneManager.LoadScene(this.nextScene);
    }
}
