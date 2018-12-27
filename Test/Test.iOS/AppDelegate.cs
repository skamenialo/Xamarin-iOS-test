using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using Test.iOS;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(AppDelegate))]
namespace Test.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, Iapp
    {
        UIViewController _root;
        List<UIViewController> _controllers;
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }

        void BuildControllers()
        {
            if(_controllers!=null)
                return;
            _controllers = new List<UIViewController>();

            var controller = new UIViewController();

            {
                controller.View.BackgroundColor = UIColor.LightGray;
                controller.Title = "Title main";

                var btn = UIButton.FromType(UIButtonType.System);
                btn.Frame = new CGRect(20, 200, 280, 44);
                btn.SetTitle("Click Me", UIControlState.Normal);

                controller.View.AddSubview(btn);

                var navigation = new UINavigationController(controller);

                btn.TouchUpInside += (sender, e) => {
                    ((UINavigationController)_controllers[0]).PushViewController(_controllers[1], true);
                };
                _controllers.Add(navigation);
            }

            controller = new UIViewController();

            {
                var view = new UIView1();
                view.SetBtn((sender, e) =>
                {
                    ((UINavigationController)_controllers[0]).PushViewController(_controllers[2], true);
                });
                controller.View = view;
                controller.Title = "Next view";
                _controllers.Add(controller);
            }

            controller = new UIViewController();

            {
                var arr = NSBundle.MainBundle.LoadNib("View1", null, null);
                var v = arr.GetItem<UIView>(0);
                
                v.Frame = controller.View.Frame;
                controller.View.AddSubview(v);
                _controllers.Add(controller);
            }
        }

        public void OpenScreen()
        {
            if(_root == null)
                _root = GetVisibleViewController();
            BuildControllers();

            _root.PresentViewController(_controllers[0], true, null);
        }

        UIViewController GetVisibleViewController()
        {
            var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            if (rootController.PresentedViewController == null)
                return rootController;
            
            return rootController.PresentedViewController;
        }
    }
}
