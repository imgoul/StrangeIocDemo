using System.Collections;
using System.Collections.Generic;
using Assets.Demo.Scripts.model;
using Assets.Demo.Scripts.signal;
using Demo.Scripts.Common;
using Demo.Scripts.Dao;
using Demo.Scripts.signal;
using UnityEngine;

public class UserService : IUserService
{
    [Inject("Service")]
    public ReturnUserSignal returnSignal { get; set; }


    private UserDao userDao = new UserDao();

    public void RequestLogin(User user)
    {
        Debug.Log("UserService验证登录获取到登录请求结果，将登录请求结果发送给UserCommand");
        bool isSuccess = userDao.VertifyUser(user);
        if (isSuccess)
        {
            returnSignal.Dispatch(ResponseCode.Login, user);
        }
        else
        {
            returnSignal.Dispatch(ResponseCode.Login,null);
        }
    }

    public void RequestRegister(User user)
    {
    }
}