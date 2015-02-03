using System;
using System.Collections.Generic;
using System.Threading;
namespace proxyform
{
    class QueueItem
    {
        List<object> ObjectLists;
        static object syncList;

        internal QueueItem() {
            ObjectLists = new List<object>();
            syncList = new object();        
        }
                       
        internal void AddRange(List<object> objectList)
        {
            lock (syncList)
            {
                ObjectLists.AddRange(objectList);
            }
         }

        internal void Add(object obj)
        {
            lock (syncList) {
                ObjectLists.Add(obj);
            }          
        }

        internal void Remove(object obj) {
            lock (syncList) {
                ObjectLists.Remove(obj);
            }          
        }

        internal int IndexOf(object obj) {            
            int pos = -1;
            lock (syncList) {
                ObjectLists.IndexOf(obj);
            }        
             return pos;        
        }

        internal int Count {
            get
            {
                int obj = 0;
                lock (syncList) {
                    obj=ObjectLists.Count;
                }               
                 return obj;
            }        
        }

        internal List<object> ToList() {
            List<object> obj = null;
            lock (syncList)
            {
                obj = ObjectLists;
            }
            return obj;        
        }

        internal object this[int index] {
            get {
                object obj=null;
                lock (syncList) {
                    obj = ObjectLists[index]; 
                }
                return obj;
            }
            set 
            {
                lock (syncList) {
                    ObjectLists[index] = value;
                }
            }
        }

        internal void Clear() {
            lock(syncList){
            ObjectLists.Clear();
            }
        }
       
    }
}
