using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;
using System.Windows.Input;
using Cursor=System.Windows.Forms.Cursor;
using Keyboard = System.Windows.Input.Keyboard;


namespace WPFDemo.SampleTests
{
    public static class Mouse
    {
        private const int MouseEventLeftDown = 0x0002;
        private const int MouseEventLeftUp = 0x0004;
        private const int MouseEventRightDown = 0x0008;
        private const int MouseEventRightUp = 0x00010;
        private const int VK_LCONTROL = 0xA2;

        private const int KEYDOWN = 0x0;
        private const int EXTENDEDKEY = 0x01;
        private const int KEYUP = 0x02;

        [DllImport("user32")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public static void Click(Point targetPoint)
        {
            Cursor.Position = targetPoint;
            mouse_event(MouseEventLeftDown, 0, 0, 0, 0);
            mouse_event(MouseEventLeftUp, 0, 0, 0, 0);
            Thread.Sleep(100);
        }

        public static void Flick(Point targetPointDown, Point targetPointUp, TimeSpan flickDuration)
        {
            Cursor.Position = targetPointDown;
            mouse_event(MouseEventLeftDown, 0, 0, 0, 0);
            Thread.Sleep(flickDuration);
            Cursor.Position = targetPointDown;
            mouse_event(MouseEventLeftUp, 0, 0, 0, 0);
            Thread.Sleep(100);
        }

        public static void RightClick(Point targetPoint)
        {
            Cursor.Position = targetPoint;
            mouse_event(MouseEventRightDown, 0, 0, 0, 0);
            mouse_event(MouseEventRightUp, 0, 0, 0, 0);
            Thread.Sleep(100);
        }

        public static void DragDrop(Point initialPoint, Point dropPoint)
        {
            Click(initialPoint);
            mouse_event(MouseEventLeftDown, 0, 0, 0, 0);
            Cursor.Position = dropPoint;
            mouse_event(MouseEventLeftUp, 0, 0, 0, 0);
            Thread.Sleep(100);
        }

        public static void DragCtrlDrop(Point initialPoint, Point dropPoint)
        {
            Click(initialPoint);
            mouse_event(MouseEventLeftDown, 0, 0, 0, 0);
            Cursor.Position = dropPoint;
            Thread.Sleep(100);
            keybd_event(VK_LCONTROL, 0, EXTENDEDKEY | KEYDOWN, 0);
            Thread.Sleep(100);
            mouse_event(MouseEventLeftUp, 0, 0, 0, 0);
            Thread.Sleep(100);
            keybd_event(VK_LCONTROL, 0, EXTENDEDKEY | KEYUP, 0);
            Thread.Sleep(100);
        }
    }
}