using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Common.WebService
{
    /// <summary>
    /// Contains query string of URL.
    /// </summary>
    public class UrlParams : IEnumerable, IEquatable<UrlParams>
    {
        private readonly List<(string Name, string Value)> _parametersList = new List<(string, string)>();

        public int Count => _parametersList.Count;

        public object this[string paramName]
        {
            get
            {
                return _parametersList
                    .First(x => x.Name == paramName)
                    .Value;
            }

            set => Add(paramName, value);
        }

        // For using collection initializer syntax
        #region Add
        public void Add<T>(string name, T value)
        {
            if (value == null)
                return;
            _parametersList.Add((name, value.ToString()));
        }

        public void Add<T>((string Name, T Value) param)
        {
            if (param.Value == null)
                return;
            _parametersList.Add((param.Name, param.Value.ToString()));
        }
        #endregion

        #region IEnumerable
        public IEnumerator GetEnumerator()
        {
            return _parametersList.GetEnumerator();
        }
        #endregion

        #region IEquatable
        public bool Equals(UrlParams other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return this._parametersList.All(other._parametersList.Contains);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as UrlParams);
        }

        public override int GetHashCode()
        {
            return (_parametersList != null ? _parametersList.GetHashCode() : 0);
        }
        #endregion

        public static implicit operator bool(UrlParams parameters)
        {
            return parameters != null && parameters._parametersList.Any();
        }

        public static UrlParams operator +(UrlParams parameters1, UrlParams parameters2)
        {
            parameters1._parametersList.AddRange(parameters2._parametersList);
            return parameters1;
        }

        public override string ToString()
        {
            return String.Join("&", _parametersList.Select(item => $"{item.Name}={item.Value}"));
        }
    }
}
