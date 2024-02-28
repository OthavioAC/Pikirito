using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;
using Unity.UIWidgets.animation; 
using Unity.UIWidgets.foundation; 
using System;



public class BottomSheetTab : MonoBehaviour {
    public class MyBottomSheet : StatefulWidget
    {
        public MyBottomSheet(Key key = null) : base(key) { }

        public override State createState() => new _MyBottomSheetState();
    }

    public class _MyBottomSheetState : State<MyBottomSheet>
    {
        public override Widget build(BuildContext context)
        {
            /*
            return new BottomSheet(
             animationController: new AnimationController(vsync: , duration: new TimeSpan(0, 0, 0, 0, 200)),
             onClosing: () => { },
             builder: (BuildContext context) => new Container(
                 child: new Text("Hello, World!")
             )
         );
            */
        }
    }

}

