using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace API.Tests
{
    public class Mocker<TObject>
    {
        private readonly Dictionary<object, object> _dependencies = new Dictionary<object,object>();
        private TObject _object;

        public TObject Object
        {
            get
            {
                if (_object == null)
                {
                    _object = Factory();
                }

                return _object;
            }
        }

        private Func<TObject> Factory
        {
            get
            {
                return () =>
                {
                    var targetType = typeof(TObject);
                    var constructor = targetType.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Single();

                    var dependencies = constructor
                        .GetParameters()
                        .Select(paramInfo => Obtain(paramInfo.ParameterType, () => Create(paramInfo.ParameterType)))
                        .Select(mock => mock.Object);

                    return (TObject)Activator.CreateInstance(typeof(TObject), dependencies.ToArray());
                };
            }
        }

        public Mock<TDependency> Obtain<TDependency>()
            where TDependency : class
        {
            return (Mock<TDependency>)Obtain(typeof(TDependency), () => new Mock<TDependency>());
        }

        private Mock Obtain(Type type, Func<Mock> factory)
        {
            if (!_dependencies.ContainsKey(type))
            {
                var dependency = factory();
                _dependencies.Add(type, dependency);
            }

            return (Mock)_dependencies[type];
        }

        private Mock Create(Type type)
        {
            var mockType = typeof(Mock<>);
            var genericMockType = mockType.MakeGenericType(type);
            var genericMock = (Mock)Activator.CreateInstance(genericMockType);
            return genericMock;
        }
    }
}
