using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewTestScript {

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator StaminaTestSimplePasses()
    {
        // Use the Assert class to test conditions.
        SetUpScene();
        yield return new WaitForSeconds(5f);
    }
    void SetUpScene()
    {
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Canvas1"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("CMvcam1"));
    }
}
