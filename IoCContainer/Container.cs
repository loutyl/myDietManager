using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainer
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _iocMap = new Dictionary<Type, Type>();

        public void Register<TTypeToResolve, TResolvedType>()
        {
            if ( this._iocMap.ContainsKey(typeof(TTypeToResolve)) )
            {
                throw new Exception($"Type {typeof (TTypeToResolve).FullName} already registered.");
            }
            this._iocMap.Add(typeof(TTypeToResolve), typeof(TResolvedType));
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type typeToResolve)
        {
            // Find the registered type for typeToResolve
            if ( !_iocMap.ContainsKey(typeToResolve) )
                throw new Exception($"Can't resolve {typeToResolve.FullName}. Type is not registed.");

            var resolvedType = _iocMap[typeToResolve];

            // Try to construct the object
            // Step-1: find the constructor (ideally first constructor if multiple constructos present for the type)
            var ctorInfo = resolvedType.GetConstructors().First();

            // Step-2: find the parameters for the constructor and try to resolve those
            var paramsInfo = ctorInfo.GetParameters().ToList();

            // Step-3: using reflection invoke constructor to create the object
            var retObject = ctorInfo.Invoke(paramsInfo.Select(param => param.ParameterType).Select(t => Resolve(t)).ToArray());

            return retObject;
        }
    }
}
