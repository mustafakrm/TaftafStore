using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message) : this(success)
        {
            Message = message;
            //Success = success; //DRY kuralından dolayı bu satırı siliyoruz bu görewvi 2. constructor'a bırakıyoruz
        }

        // 2. constructor oluşturduğumuzda overloading yapmış oluruz (yaptık)
        // ve success'ı 2 kere yazdığımızdan DRY'ı (Don't Repeat Yourself) çiğnemiş olduk
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
