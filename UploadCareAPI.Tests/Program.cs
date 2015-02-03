using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadCareAPI;

namespace UploadCareAPI.Tests
{
    class Program
    {
        static void Main(string[] args)
        {

            var publickey = "aa6314f5cef02ea8f555";
            var privatekey = "f57e576b360f5efbb7b9";

            var ucare = new UploadCareAPI(publickey, privatekey);

            ucare.SaveToStorage();

           // ucare.Resize("cbd3a0bf-97da-45ab-b9d3-17800b4ac039", 100,100);




            // http://www.ucarecdn.com/cbd3a0bf-97da-45ab-b9d3-17800b4ac039/DSC_0460.jpg


        }
    }
}
