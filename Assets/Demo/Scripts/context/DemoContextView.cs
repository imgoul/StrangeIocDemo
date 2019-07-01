using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using UnityEngine;

public class DemoContextView : ContextView {
    void Awake()
    {
        context=new DemoSignalsContext(this);
    }
}
