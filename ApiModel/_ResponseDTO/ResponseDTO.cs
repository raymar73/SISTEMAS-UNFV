using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ApiModel._ResponseDTO
{
    public class ResponseDTO
    {
        public int status { get; set; }
        public string description { get; set; }
        public object objModel { get; set; }
        public string token { get; set; }
        public object objPaginated { get; set; }

        public ResponseDTO Success(ResponseDTO obj, object objModel)
        {
            obj.description = "Transaction Sucessfully";
            obj.status = 1;
            obj.objModel = objModel;
            obj.token = token;
            return obj;
        }

        public ResponseDTO Failed(ResponseDTO obj, string e)
        {

            obj.description = e;
            obj.status = 0;
            return obj;
        }

        /// <summary>
        /// Method for sending custom success messages
        /// </summary>
        /// <param name="objModel"></param>
        /// <param name="message"></param>
        public void SuccessPersonalizedMessage(object objModel, string message)
        {
            status = 1;
            description = message;
            this.objModel = objModel;

        }

        /// <summary>
        /// Method for validate that there are no empty or null fields
        /// </summary>
        public bool ValidateFields(object objModel)
        {
            foreach (PropertyInfo propertyInfo in objModel.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string))
                {
                    string value = (string)propertyInfo.GetValue(objModel);
                    if (string.IsNullOrEmpty(value))
                    {
                        status = 0;
                        description = "Esta enviando uno o m?s datos vacios";
                        return false;
                    }
                }
            }
            return true;
        }

        public ModelStateDictionary FailedPersonalizedMessage(ResponseDTO responseDto)
        {
            throw new NotImplementedException();
        }
    }

    public class ModelStateDictionary
    {
    }
}
