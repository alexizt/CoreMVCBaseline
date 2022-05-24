namespace CoreMVCBaseline.Services
{
    public interface IProtectedCookies
    {
        string Get(string key);
        void Set(string key, string value);
    }
}