using System;
using System.Drawing;

using CoreGraphics;
using Foundation;
using UIKit;

namespace Test.iOS
{
    [Register("UIView1")]
    public class UIView1 : UIView
    {

        UIButton btn = UIButton.FromType(UIButtonType.System);
        public UIView1()
        {
            Initialize();
        }

        public UIView1(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.Green;

            btn.Frame = new CGRect(20, 200, 280, 44);
            btn.SetTitle("Click Me", UIControlState.Normal);

            AddSubview(btn);
        }

        public void SetBtn(EventHandler handler)
        {
            btn.TouchUpInside += handler;
        }
    }
}