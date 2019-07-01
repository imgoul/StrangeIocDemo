using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using strange.extensions.command.impl;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Demo.Scripts.controller
{
    class StartCommand:Command
    {
        public override void Execute()
        {
            Debug.Log("启动框架");
        }
    }
}
