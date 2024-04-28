using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Coroutine _coroutine;
    private void Start()
    {
        var some = "34";
        some += "42";
        Debug.Log(some);
        _coroutine = StartCoroutine(SomeCoroutine());
    }
    [ContextMenu("Kill coroutine")]
    public void KillRoutine()
    {
        StopCoroutine(_coroutine);

    }
    private IEnumerator SomeCoroutine()
    {
        var some = "34";
        some += "42";
        while (enabled)
        {
            Debug.Log(some);
            yield return AnotherCoroutine();
            Debug.Log("done");
            yield return new WaitForSeconds(1f);
        }
    }
    private IEnumerator AnotherCoroutine()
    {
        yield return new WaitForSeconds(2f);
    }
}
