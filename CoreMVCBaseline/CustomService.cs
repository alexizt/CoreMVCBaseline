using Microsoft.Extensions.Options;
using System;

namespace CoreMVCBaseline
{
    internal class CustomService : ICustomService
    {

        private readonly CustomAppSettings _settings;

        public CustomService(
            IOptions<CustomAppSettings> settings
            )
        {
            _settings = settings.Value;
        }

        public void DoSomething()
        {
            Console.WriteLine(_settings.Parameter1);
        }
    }
}