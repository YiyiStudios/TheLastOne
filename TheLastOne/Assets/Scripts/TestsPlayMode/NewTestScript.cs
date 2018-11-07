using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;


public class NewTestScript
{

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode


    [UnityTest]
    public IEnumerator TestSceneLoading()
    {
        Scene testScene = SceneManager.GetActiveScene();
        yield return SceneManager.LoadSceneAsync("Test", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Test"));
        Assert.IsTrue(SceneManager.GetActiveScene().name == "Test");
        SceneManager.UnloadSceneAsync("Test");
        yield return SceneManager.SetActiveScene(testScene);
    }
    [UnityTest]
    public IEnumerator MovementPlayerX()
    {
        Scene scene = SceneManager.GetActiveScene();
        yield return SceneManager.LoadSceneAsync("Test", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Test"));
        yield return new WaitForSeconds(2f);
        Vector2 mov = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        Assert.IsTrue(mov.x == 1);
    }
    [UnityTest]
    public IEnumerator MovementPlayerY()
    {
        Scene scene = SceneManager.GetActiveScene();
        yield return SceneManager.LoadSceneAsync("Test", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Test"));
        yield return new WaitForSeconds(2f);
        Vector2 mov = new Vector2(0, Input.GetAxisRaw("Vertical"));
        Assert.IsTrue(mov.y == 1);
    }
    [UnityTest]
    public IEnumerator MovementPlayerXYPositive()
    {
        Scene scene = SceneManager.GetActiveScene();
        yield return SceneManager.LoadSceneAsync("Test", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Test"));
        yield return new WaitForSeconds(2f);
        Vector2 mov = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Assert.IsTrue(mov == Vector2.one);
    }
    [UnityTest]
    public IEnumerator StaminaReduction()
    {
        Scene scene = SceneManager.GetActiveScene();
        yield return SceneManager.LoadSceneAsync("Test", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Test"));
        yield return new WaitForSeconds(2f);
        float reduction = 1;
        float staminabar = 0;
        staminabar = Mathf.InverseLerp(100, 0, reduction);
        Assert.IsTrue(staminabar == 0.99f);
        reduction++;
        reduction++;
        staminabar = Mathf.InverseLerp(100, 0, reduction);
        Assert.IsTrue(staminabar == 0.97f);
    }
}
