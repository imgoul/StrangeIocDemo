using Assets.Demo.Scripts.controller;
using Assets.Demo.Scripts.model;
using Assets.Demo.Scripts.signal;
using Demo.Scripts.controller;
using Demo.Scripts.signal;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class DemoSignalsContext : MVCSContext {
    public DemoSignalsContext(MonoBehaviour view) : base(view)
    {
    }

    
    //解除默认的EventCommandBinder，重新绑定为SignalCommandBinder
    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    protected override void mapBindings()
    {
        injectionBinder.Bind<IUser>().To<User>().ToSingleton();
        injectionBinder.Bind<IUserService>().To<UserService>().ToSingleton();

        mediationBinder.Bind<UserView>().To<UserMediator>();
        
        commandBinder.Bind<UserSignal>().To<UserCommand>();
        injectionBinder.Bind<UserViewSignal>().ToSingleton();
        commandBinder.Bind<StartSignal>().To<StartCommand>().Once();

        //将信号绑定，才可以在注入的类中使用
        injectionBinder.Bind<ReturnUserSignal>().ToName("Service").ToSingleton();
        injectionBinder.Bind<ReturnUserSignal>().ToName("Command").ToSingleton();
    }

    public override IContext Start()
    {
        base.Start();
        StartSignal startSignal = (StartSignal)injectionBinder.GetInstance<StartSignal>();
        startSignal.Dispatch();
        return this;
    }
}
