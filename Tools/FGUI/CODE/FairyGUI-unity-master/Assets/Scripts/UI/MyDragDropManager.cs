using DemoPack;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FairyGUI
{
    /// <summary>
    /// Helper for drag and drop.
    /// 这是一个提供特殊拖放功能的功能类。与GObject.draggable不同，拖动开始后，他使用一个替代的图标作为拖动对象。
    /// 当玩家释放鼠标/手指，目标组件会发出一个onDrop事件。
    /// </summary>
    public class MyDragDropManager
    {
        private SubstituteItem _agent;
        private object _sourceData;
        private GObject _source;

        private static MyDragDropManager _inst;
        public static MyDragDropManager inst
        {
            get
            {
                if (_inst == null)
                    _inst = new MyDragDropManager();
                return _inst;
            }
        }

        public MyDragDropManager()
        { 
            _agent = SubstituteItem.CreateInstance(); 
            _agent.gameObjectName = "DragDropAgent";
            _agent.SetHome(GRoot.inst);
            _agent.touchable = false;//important
            _agent.draggable = true;
            _agent.SetSize(150, 150);
            _agent.SetPivot(0.5f, 0.5f, true);
            _agent.sortingOrder = int.MaxValue;
            _agent.onDragEnd.Add(__dragEnd);
        }

        /// <summary>
        /// Loader object for real dragging.
        /// 用于实际拖动的Loader对象。你可以根据实际情况设置loader的大小，对齐等。
        /// </summary>
        public SubstituteItem dragAgent
        {
            get { return _agent; }
        }

        /// <summary>
        /// Is dragging?
        /// 返回当前是否正在拖动。
        /// </summary>
        public bool dragging
        {
            get { return _agent.parent != null; }
        }

        /// <summary>
        /// Start dragging.
        /// 开始拖动。
        /// </summary>
        /// <param name="icon">Icon to be used as the dragging sign.</param>
        /// <param name="sourceData">Custom data. You can get it in the onDrop event data.</param>
        /// <param name="touchPointID">Copy the touchId from InputEvent to here, if has one.</param>
        public void StartDrag(string icon, object sourceData, int touchPointID = -1)
        {
            if (_agent.parent != null)
                return;

            _sourceData = sourceData;
            _agent.icon.url = icon;
            GRoot.inst.AddChild(_agent);
            _agent.xy = GRoot.inst.GlobalToLocal(Stage.inst.GetTouchPosition(touchPointID));
            _agent.StartDrag(touchPointID);
        }

        /// <summary>
        /// Cancel dragging.
        /// 取消拖动。
        /// </summary>
        public void Cancel()
        {
            if (_agent.parent != null)
            {
                _agent.StopDrag();
                _agent.Dispose();
                _sourceData = null;
            }
        }
        

        private void __dragEnd(EventContext evt)
        {
            if (_agent.parent == null) //cancelled
                return;

            GRoot.inst.RemoveChild(_agent);

            object sourceData = _sourceData;
            GObject source = _source;
            _sourceData = null;
            _source = null;

            GObject obj = GRoot.inst.touchTarget;
            while (obj != null)
            {
                if (obj.hasEventListeners("onDrop"))
                {
                    obj.RequestFocus();
                    obj.DispatchEvent("onDrop", sourceData, source);
                    return;
                }
                obj = obj.parent;
            }
        }
    }
}