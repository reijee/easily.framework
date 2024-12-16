using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.Users.Accessors
{
    public interface ICurrentUserAccessor<T>
    {
        /// <summary>
        /// 当前用户
        /// </summary>
        EasilyUserInfo<T>? Current { get; }

        /// <summary>
        /// 设置当前用户
        /// </summary>
        /// <param name="current"></param>
        void SetCurrentUser (EasilyUserInfo<T>? current);
    }
}
