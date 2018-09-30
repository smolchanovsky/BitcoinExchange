using System;

namespace Infrastructure.WebApi.ApiClient
{
    /// <summary>
    /// Specifies the name of the web service entity.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ApiEntityAttribute : Attribute
    {
        public string ApiEntityName { get; }

        public ApiEntityAttribute(string apiEntityName)
        {
            ApiEntityName = apiEntityName;
        }
    }
}