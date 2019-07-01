using System.Collections;
using System.Collections.Generic;
using Assets.Demo.Scripts.model;
using Assets.Demo.Scripts.signal;
using Demo.Scripts.Common;
using Demo.Scripts.signal;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public class UserView : View
{
    //触发点击事件
    [Inject]
    public UserViewSignal signal{get;set;}
    public  InputField user;
    public InputField password;
    public Text hintText;
    private bool isShowHintInfo = false;
    private string hintInfo = null;
    public string GetUserInfo()
    {
        string str=user.text + "," + password.text;
        return str;
    }

    public void OnLoginButtonClick()
    {
        Debug.Log("点击登录");
        signal.Dispatch(RequestCode.Login);
    }

    void Update()
    {
        if (isShowHintInfo)
        {
            SetHintText(hintInfo);
        }
    }

    private void SetHintText(string hintInfo)
    {
        hintText.text = hintInfo;
    }

    public void OnLoginResponse(string hintInfo)
    {
        isShowHintInfo = true;
        this.hintInfo = hintInfo;
    }
}
