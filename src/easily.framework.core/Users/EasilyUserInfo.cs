using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.Users
{
    public class EasilyUserInfo<T>
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public T? Id { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string? NickName { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string? Avatar {  get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string? PhoneNumber { get; set; }
    }
}
