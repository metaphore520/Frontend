using Front_end.ApiModel;
using Front_end.Models;
using Front_end.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace Front_end.Services
{
    public static class HelperService
    {
        public static MemoryStream GetMemoryStreamFromByteArray(byte[] file)
        {

            //string fileName = "test.txt";
            //byte[] file = File.ReadAllBytes(Server.MapPath("~/Files/" + fileName));
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(file, 0, file.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return memStream;
        }
        public static MemoryStream GetMemoryStreamFromIFormFile(IFormFile formFile)
        {
            var memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);
            return memoryStream;
        }

        public static void MapCustomerPortalViewModel(CustomerPortalViewModel viewModel, PostCustomerApiModel model)
        {
            model.Customer.FatherName = viewModel.FatherName;
            model.Customer.CustomerName = viewModel.CustomerName;
            //will be added later
            if (viewModel.CustomerPhoto != null)
            {
                using (var stream = new MemoryStream())
                {
                    viewModel.CustomerPhoto.CopyTo(stream);
                    model.Customer.CustomerPhoto = stream.ToArray();
                }
            }
            if (viewModel.MaritalStatus == "MARRIED")
            {
                model.Customer.MaritalStatus = 1;
            }
            else if (viewModel.MaritalStatus == "SINGLE")
            {
                model.Customer.MaritalStatus = 2;
            }
            else if (viewModel.MaritalStatus == "OTHERS")
            {
                model.Customer.MaritalStatus = 3;
            }

            model.Customer.CountryId = viewModel.CountryId;
            model.Customer.MotherName = viewModel.MotherName;

            var result = JsonConvert.DeserializeObject<Addresses>(viewModel.AllAddress);

            foreach (var address in result.alladdress)
            {
                model.CustomerAddresses.Add(address);
            }
        }

        public static List<SelectListItem> GetDropdown(List<Country> countryList)
        {
            List<SelectListItem> dropdown = new List<SelectListItem>();
            for (int i = 0; i < countryList.Count(); i++)
            {
                dropdown.Add(new SelectListItem
                {
                    Text = countryList[i].CountryName,
                    Value = "" + countryList[i].Id
                });
            }
            return dropdown;
        }
        public static void MapCustomerPortalEditModel(CustomerPortalEditModel viewModel, PostCustomerApiModel model)
        {
            model.Customer.FatherName = viewModel.FatherName;
            model.Customer.CustomerName = viewModel.CustomerName;

            ////////////////////////////Photo Section
            if (viewModel.FileUploaded)
            {
                using (var stream = new MemoryStream())
                {
                    viewModel.CustomerPhoto.CopyTo(stream);
                    model.Customer.CustomerPhoto = stream.ToArray();
                }
            }
            else
            {
                model.Customer.CustomerPhoto = viewModel.CustomerPhotoByte;
            }

            if (viewModel.MaritalStatus == "MARRIED")
            {
                model.Customer.MaritalStatus = 1;
            }
            else if (viewModel.MaritalStatus == "SINGLE")
            {
                model.Customer.MaritalStatus = 2;
            }
            else if (viewModel.MaritalStatus == "OTHERS")
            {
                model.Customer.MaritalStatus = 3;
            }

            model.Customer.CountryId = viewModel.CountryId;
            model.Customer.MotherName = viewModel.MotherName;
            model.Customer.Id = viewModel.Id;
            var result = JsonConvert.DeserializeObject<AddressesEditModel>(viewModel.AllAddress);

            foreach (var address in result.alladdress)
            {
                model.CustomerAddresses.Add(address);
            }
            Console.WriteLine("aaa");

        }
    }
}
