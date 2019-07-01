using Assets.Demo.Scripts.model;
using Demo.Scripts.Common;
using Demo.Scripts.signal;
using strange.extensions.command.impl;
using UnityEditor;
using UnityEngine;
using Tools = Demo.Scripts.tools.Tools;


namespace Demo.Scripts.controller
{
    public class UserCommand : Command
    {
        //注入service，与service交互
        [Inject]
        public IUserService userService { get; set; }


        /// <summary>
        /// 请求
        /// </summary>
        [Inject]
        public RequestCode requestCode { get; set; }

        /// <summary>
        /// 请求数据
        /// </summary>
        [Inject]
        public string data { get; set; }

        [Inject("Command")]
        public ReturnUserSignal returnUserSignal { get; set; }

        public override void Execute()
        {
            Retain();
            userService.returnSignal.AddListener(HandleResponse);
            Debug.Log("UserCommand收到请求，调用UserService的RequestLogin方法");
            HandleRequest();
        }


        /// <summary>
        /// 处理request
        /// </summary>
        private void HandleRequest()
        {
            switch (requestCode)
            {
                case RequestCode.Login:
                    userService.RequestLogin(Tools.UserInfoStrToUser(data));
                    break;
            }
        }

        /// <summary>
        /// 处理response
        /// </summary>
        /// <param name="code"></param>
        /// <param name="data"></param>
        private void HandleResponse(ResponseCode code, User data)
        {
            returnUserSignal.Dispatch(code, data);
        }
    }
}