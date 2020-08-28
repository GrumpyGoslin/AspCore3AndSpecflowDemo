using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore3SpecflowBehaviourTests
{
    public class Routes
    {
        public static string Create<T>() => typeof(T).Name;
    }
}
