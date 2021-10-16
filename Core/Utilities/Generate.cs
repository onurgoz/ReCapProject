using Core.Utilities.Results;
using System;

namespace Core.Utilities
{
    public static class Generate
    {
        public static IDataResult<string> GenerateGuid()
        {
            return new SuccessDataResult<string>(Guid.NewGuid().ToString());
        }
    }
}
