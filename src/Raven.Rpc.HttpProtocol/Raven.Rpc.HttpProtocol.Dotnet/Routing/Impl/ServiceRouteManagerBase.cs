using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.Routing.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ServiceRouteManagerBase : IServiceRouteManager
    {
        private EventHandler<ServiceRouteEventArgs> _created;
        private EventHandler<ServiceRouteEventArgs> _removed;
        private EventHandler<ServiceRouteChangedEventArgs> _changed;
        
        /// <summary>
        /// 服务路由被创建。
        /// </summary>
        public event EventHandler<ServiceRouteEventArgs> Created
        {
            add { _created += value; }
            remove { _created -= value; }
        }

        /// <summary>
        /// 服务路由被删除。
        /// </summary>
        public event EventHandler<ServiceRouteEventArgs> Removed
        {
            add { _removed += value; }
            remove { _removed -= value; }
        }

        /// <summary>
        /// 服务路由被修改。
        /// </summary>
        public event EventHandler<ServiceRouteChangedEventArgs> Changed
        {
            add { _changed += value; }
            remove { _changed -= value; }
        }

        /// <summary>
        /// 获取所有可用的服务路由信息。
        /// </summary>
        /// <returns>服务路由集合。</returns>
        public abstract Task<IEnumerable<ServiceRoute>> GetRoutesAsync();

        /// <summary>
        /// 清空所有的服务路由。
        /// </summary>
        /// <returns>一个任务。</returns>
        public abstract Task ClearAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="routes"></param>
        /// <returns></returns>
        public abstract Task SetRoutesAsync(IEnumerable<ServiceRoute> routes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected void OnCreated(params ServiceRouteEventArgs[] args)
        {
            if (_created == null)
                return;

            foreach (var arg in args)
                _created(this, arg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected void OnChanged(params ServiceRouteChangedEventArgs[] args)
        {
            if (_changed == null)
                return;

            foreach (var arg in args)
                _changed(this, arg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected void OnRemoved(params ServiceRouteEventArgs[] args)
        {
            if (_removed == null)
                return;

            foreach (var arg in args)
                _removed(this, arg);
        }

    }
}
