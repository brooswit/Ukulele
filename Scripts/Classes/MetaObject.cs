using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MetaObject : Dispatcher {
  private static List<MetaObject> metaObjects = new List<MetaObject>();
  private static int next_id = 0;
  private int _callbackID;

  private int _id;
  public int id{
    get { return _id; }
  }

  MetaObject() {
    this._id = next_id++;
    metaObjects[this._id] = this;
    _callbackID = Broadcaster.I.On("all", this.Trigger);
  }

  ~MetaObject() {
    Broadcaster.I.Off(_callbackID);
    this.Trigger("destroy");
  }
}