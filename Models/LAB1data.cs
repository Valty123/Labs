using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
namespace LAB1.Models
{
    public class LAB1Data
    {
        public string SerialNumber {get;set;}
        public string Brand {get;set;}
        public string Model {get;set;}
        public int Year {get;set;}
        public string Type {get;set;}

        public BaseModelValidationResult Validate()

             {

                 var validationResult = new BaseModelValidationResult();

                    if (string.IsNullOrWhiteSpace(SerialNumber)) validationResult.Append($"SerialNumber cannot be empty");
                    if (string.IsNullOrWhiteSpace(Brand)) validationResult.Append($"Brand cannot be empty");
                    if (!(1900<Year && Year<2020)) validationResult.Append ($"Year {Year} is out of range (1900..2020)");
                    if (string.IsNullOrWhiteSpace(Type)) validationResult.Append ($"Type cannot be empty");
                    if (!string.IsNullOrEmpty(Brand) && !char.IsUpper(Brand.FirstOrDefault())) validationResult.Append ($"Brand {Brand} should start from capital letter");
                    if (!string.IsNullOrEmpty(Model) && !char.IsUpper(Model.FirstOrDefault())) validationResult.Append ($"Model {Model} should start from capital letter");
                    return validationResult;
                }
        public override string ToString()
             {
                //return $"{Brand} {Model} from {Year}-{Type}";
                return $"{Brand} {Model} from {SerialNumber}-{Year}-{Type}";
                 }
    }

}



        
                        
    
