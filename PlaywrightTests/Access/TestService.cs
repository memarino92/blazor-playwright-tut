using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp.Access;

namespace PlaywrightTests.Access
{
    internal class TestService : IExampleService
    {
        public string GetMessage() => "This is a test message";
    }
}
