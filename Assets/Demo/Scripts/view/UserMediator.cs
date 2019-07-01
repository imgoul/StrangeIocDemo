using System.Collections;
using System.Collections.Generic;
using Assets.Demo.Scripts.model;
using Assets.Demo.Scripts.signal;
using Demo.Scripts.Common;
using Demo.Scripts.signal;
using strange.extensions.mediation.impl;
using UnityEngine;

public class UserMediator : Mediator {
    [Inject]//与view层交互接口
    public UserView userView { get; set; }

    [Inject]//与controller层交互接口
    public UserSignal userSignal { get; set; }

    [Inject("Command")]//请求登录响应回调信号
    public ReturnUserSignal returnUserSignal { get; set; }
    
    /// <summary>
    /// 实例化时调用
    /// </summary>
    public override void OnRegister()
    {
        userView.signal.AddListener(HandleRequest);
        returnUserSignal.AddListener(HandleResponse);
    }
    
    private void HandleRequest(RequestCode code)
    {
        switch (code)
        {
            case RequestCode.Login:
                OnLoginBtnClick();
                break;
        }
    }

    private void HandleResponse(ResponseCode code,User data)
    {
        switch (code)
        {
            case ResponseCode.Login:
                OnLoginResponse(data);
                break;
        }
    }
    public override void OnRemove()
    {
        userView.signal.RemoveListener(HandleRequest);
        returnUserSignal.RemoveListener(HandleResponse);
    }

    /// <summary>
    /// 登录请求
    /// </summary>
    private void OnLoginBtnClick()
    {
        Debug.Log("UserMediator收到Login请求,将请求转发至UserCommand");
        userSignal.Dispatch(RequestCode.Login,userView.GetUserInfo());
    }

    /// <summary>
    /// 登录响应函数
    /// </summary>
    /// <param name="data"></param>
    private void OnLoginResponse(User data)
    {
        Debug.Log("UserMediator收到登录请求结果，掉用UserView中的方法，显示登录结果");
        if (data!=null)
        {
            userView.OnLoginResponse("登录成功");
        }
        else
        {
            userView.OnLoginResponse("登录失败");
        }
    }
}
