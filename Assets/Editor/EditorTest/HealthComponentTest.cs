using NUnit.Framework;
using PixelCrew.Components.Health;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponentTest
{
    GameObject go;
    HealthComponent healthComponent;

    [SetUp]
    public void init()
    {
        go = new GameObject();
        healthComponent = go.AddComponent<HealthComponent>();
    }

    [Test]
    public void HelthComponentModifyHealthTest()
    {
        healthComponent.ModifyHealth(10);

        Assert.AreEqual(0, healthComponent.Health);
    }
}
