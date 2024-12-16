using easily.framework.core.DependencyInjections;

namespace easily.framework.core.Users.Accessors
{
    public class AsyncLocalCurrentUserAccessor<T> : ICurrentUserAccessor<T>, ISingletonDependency
    {
        /// <summary>
        /// AsyncLocal存储
        /// </summary>
        private readonly AsyncLocal<EasilyUserInfo<T>?> _currentStore;

        /// <summary>
        /// 构造方法
        /// </summary>
        public AsyncLocalCurrentUserAccessor()
        {
            _currentStore = new AsyncLocal<EasilyUserInfo<T>?>();
        }

        /// <summary>
        /// 当前用户信息
        /// </summary>
        public EasilyUserInfo<T>? Current => _currentStore.Value;

        /// <summary>
        /// 设置当前用户
        /// </summary>
        /// <param name="current"></param>
        public void SetCurrentUser(EasilyUserInfo<T>? current)
        {
            _currentStore.Value = current;
        }
    }
}
