using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.DependencyInjections
{
    /// <summary>
    /// 依赖注入特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DependencyAttribute : Attribute
    {
        public ServiceLifetime? Lifetime { get; set; }

        /// <summary>
        /// 是否为替换
        /// </summary>
        public bool IsReplace { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsTry {  get; set; }

        /// <summary>
        /// 指定的注入类型
        /// </summary>
        public Type[] RegisterTypes { get; set; } = Type.EmptyTypes;

        public DependencyAttribute()
        {

        }

        public DependencyAttribute(ServiceLifetime lifetime)
        {
            Lifetime = lifetime;
        }
    }
}
