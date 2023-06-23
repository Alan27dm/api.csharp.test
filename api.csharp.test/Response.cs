using System;
namespace api.csharp.test
{
	namespace Response
	{
        public class commonDataStructure<T>
        {
            public int status { get; set; }
            public string msg { get; set; } = string.Empty;
            public List<T> data { get; set; } = new List<T> { };
        }

        public class UserEditRet: commonDataStructure<Request.UserEdit>
        {
            public new List<Request.UserEdit> data { get; set; } = new List<Request.UserEdit> { };
        }

    }
}