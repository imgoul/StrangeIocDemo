using System.Collections;
using System.Collections.Generic;
using Assets.Demo.Scripts.model;
using Demo.Scripts.signal;
using UnityEngine;

public interface IUserService
{
    [Inject("Service")]
    ReturnUserSignal returnSignal { get; set; }
    void RequestRegister(User user);
    void RequestLogin(User user);
}